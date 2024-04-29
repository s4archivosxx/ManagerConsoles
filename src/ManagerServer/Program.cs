using CLog;
using JLib.Extensions;
using JLib.IO.Ini;
using JLib.Management;
using JLib.Registration;
using JLib.Registration.Interfaces;
using JLib.Security.Cryptography;
using ManagerServer.Complements;
using ManagerServer.Resource;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ManagerServer
{
    internal class Program
    {
        private static IServiceRegistry _serviceRegistry;
        private static IClog _logger;
        private static IDictionary<int, JFunctionInfo> _functions;
        public static string _baseDirectory;

        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = "ManagerServer.exe";
            Console.CancelKeyPress += Console_CancelKeyPress;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //var localKey = UserComputer.MachineInterFace.ToHashSHA256();
            var serviceRegistry = LoadServiceRegistry();
            _serviceRegistry = serviceRegistry;

            _logger = _serviceRegistry.GetRequiredType<ILogger>();

            //if (args.Any(x => x.Equals("-key:give", StringComparison.InvariantCulture)))
            //{
            //    _logger.Information("Your Hash: {key}", localKey);
            //    _logger.ReadLine();
            //    return;
            //}

            var ini = _serviceRegistry.GetRequiredType<IniFile>();
            //if (!ini.KeyExists("KeyHash", "CONFIG"))
            //{
            //    ini.Write("KeyHash", "", "CONFIG");
            //    _logger.Exit();
            //    return;
            //}

            //var keyHash = ini.Read("KeyHash", "CONFIG");
            //if (string.IsNullOrEmpty(keyHash) || 
            //    !keyHash.Equals(localKey))
            //{
            //    _logger.Exit();
            //    return;
            //}

            LoadFunctions();

            _serviceRegistry.GetRequiredType<Translator>()
                .DefaultLanguage();

            var xml = _serviceRegistry.GetRequiredType<XmlCache>();
            //xml.PreCache();

            CommandTable();
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            _serviceRegistry.GetRequiredType<Translator>()?.Dispose();
            Console.Clear();
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            _logger?.Warning(ex.InnerException.Message);
        }

        private static void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            var ex = (Exception)e.Exception;
            _logger?.Warning(ex.InnerException.Message);
        }

        private static IServiceRegistry LoadServiceRegistry()
        {
            var registry = new ServiceRegistry()
                .AddContract<ILogger>("Console.log", nameof(Program), false)
                .AddContract<IniFile>(AppDomain.CurrentDomain.BaseDirectory, "Config")
                .AddContract<Translator>()
                .AddContract<XmlCache>()
                .AddContract<Functions>();
            return registry;
        }

        private static void LoadFunctions()
        {
            _functions = new ConcurrentDictionary<int, JFunctionInfo>();

            var type = typeof(Functions).GetTypeInfo();
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                var attribute = method.GetCustomAttribute<Attributes.FunctionAttribute>();
                if (attribute == null)
                    continue;

                _functions.Add(attribute.Number, new JFunctionInfo(attribute.Name, attribute.Number, method));
            }
        }

        private static async Task<bool> StartFunction(string k)
        {
            try
            {
                if (string.IsNullOrEmpty(k))
                    return false;

                if (!_functions.TryGetValue(byte.Parse(k), out var info))
                    return false;

                info.MethodFunc?.Invoke(_serviceRegistry.GetRequiredType<Functions>(), info.MethodFunc.GetParameters());
                return true;
            }
            catch (Exception ex)
            {
                _logger.Warning(ex.InnerException.Message);
            }
            return false;
        }

        public static void ContinueOrExit()
        {
            _logger.Consultation("¿Desea continuar?, si/no: ");
            var result = _logger.ReadLine();
            if (result.StartsWith("s", StringComparison.CurrentCultureIgnoreCase))
                CommandTable();
            else
                _logger.Exit();
        }

        public static async void CommandTable()
        {
            _logger.NewLine();
            _logger.Command("=====================");
            _logger.Command("LISTA DE COMANDOS");
            _logger.Command("=====================");
            _logger.NewLine();

            _functions.Values.OrderBy(x => x.Number)
                .ToList()
                .ForEach(x => _logger.Command("{0}.{1}", x.Number, x.Name));

            _logger.Consultation("Escriba el número del comando para continuar: ");
            var num = _logger.ReadLine();

            var method = await StartFunction(num);
            if (!method)
                _logger.Warning("Función finalizada con error.");
            // CommandTable();
            _logger.Wait();
        }
    }
}
