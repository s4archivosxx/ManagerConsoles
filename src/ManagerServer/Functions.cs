
using CLog;
using Extensions;
using JLib.Extensions;
using JLib.Management;
using JLib.Registration.Interfaces;
using JLib.Security.Cryptography;
using ManagerServer.Attributes;
using ManagerServer.Complements;
using ManagerServer.Resource;
using ManagerServer.Resource.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ManagerServer
{
    internal class Functions
    {
        private readonly IServiceRegistry _serviceRegistry;
        private readonly IClog _logger;
        private readonly Translator _translator;
        private readonly XmlCache _xmlCache;

        public Functions(IServiceRegistry serviceRegistry, ILogger logger, Translator translator, XmlCache xmlCache)
        {
            _serviceRegistry = serviceRegistry;
            _logger = logger.Context(nameof(Functions));
            _translator = translator;
            _xmlCache = xmlCache;
        }

        [Function("Salir de la aplicación.", 0)]
        public virtual void Exit() => Environment.Exit(0);

        [Function("Obtener la extension correcta de una imagen.", 8)]
        public virtual void ExtensionOfImage()
        {
            _logger.NewLine();
            _logger.Information("============================================");
            _logger.Information(":: EXTENSION DE IMAGEN ::");
            _logger.Information("============================================");
            _logger.NewLine();

            _logger.Consultation("Ingresar ruta del directorio: ");
            var path = _logger.ReadLine();
            foreach (var filePath in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
            {
                if (Path.GetExtension(filePath) == ".scn")
                    continue;

                if (Path.GetExtension(filePath) == ".seq")
                    continue;

                var extension = BitmapExtensions.GetImageFormat(File.ReadAllBytes(filePath));
                var name = Path.GetFileName(filePath);
                _logger.Information("Name: {name}, Extension: {ex}", name, extension);
            }
            Program.ContinueOrExit();
        }

        [Function("Obtener Token de archivos.", 7)]
        public virtual void TokenSHA1File()
        {
            _logger.NewLine();
            _logger.Information("============================================");
            _logger.Information("TOKEN DE ARCHIVOS :: SHA1 :SC");
            _logger.Information("============================================");
            _logger.NewLine();

            _logger.Consultation("Ingresar ruta del directorio: ");
            var path = _logger.ReadLine();
            foreach (var file in Directory.GetFiles(path))
            {
                var data = File.ReadAllBytes(file);
                var sha1 = ToSHA1(data, 5);
                _logger.Information("Name: {name} - Token: {token}", Path.GetFileName(file), sha1);
            }
            Program.ContinueOrExit();

            string ToSHA1(byte[] @this, int lenght)
            {
                SHA1 sha1 = SHA1.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha1.ComputeHash(@this);
                for (int i = 0; i < stream.Length; i++)
                {
                    if (i >= lenght)
                        break;

                    sb.AppendFormat("{0:x2}", stream[i]);
                }
                return sb.ToString();
            }
        }

        [Function("Ocultar código de script (js/php)", 6)]
        public virtual void HideScriptCode()
        {
            _logger.NewLine();
            _logger.Information("============================================");
            _logger.Information("Ocultar código de scripts (js/php):SC");
            _logger.Information("============================================");
            _logger.NewLine();

            const int stringLimit = 150;
            List<string> stringLines = new List<string>();
            _logger.Consultation("Ingrese la ruta del script: ");
            string input = _logger.ReadLine();
            if (!File.Exists(input))
            {
                _logger.Exit();
                return;
            }

            string line = string.Empty;
            string fileName = Path.GetFileName(input);
            _logger.Information("Iniciando lectura de script: {name}", fileName);
            string folderExtension = Path.GetExtension(input)
                .Replace(".", "");
            string output = Path.Combine(Program._baseDirectory, "converts",
                folderExtension, fileName);

            string[] fileLines = File.ReadAllLines(input);
            _logger.Information("Iniciando conversión...");
            for (int i = 0; i < fileLines.Length; i++)
            {
                string fileLine = fileLines[i].Trim();
                if (!fileLine.StartsWith("SELECT *", StringComparison.CurrentCultureIgnoreCase) && fileLine.StartsWith("*"))
                    continue;

                resetLine();

                if (!fileLine.Contains("://") && fileLine.Contains("//"))
                {
                    string[] lines = fileLine.Split('/');
                    if (lines.Length < 1)
                        continue;

                    if (!string.IsNullOrEmpty(lines[0]) && !string.IsNullOrWhiteSpace(lines[0]))
                        line += lines[0];

                    continue;
                }

                line += fileLine;
                if (line.Contains("<?php"))
                    line += " ";
            }
            stringLines.Add(line);
            _logger.Information("Guardando nuevo script...");
            File.WriteAllLines(output, stringLines.ToArray());
            stringLines.Clear();

            void resetLine()
            {
                if (line.Length >= stringLimit)
                {
                    stringLines.Add(line);
                    line = string.Empty;
                }
            }

            _logger.Debug("Ok");

            Program.ContinueOrExit();
        }

        [Function("Ocultar código de scripts (js/php)", 5)]
        public virtual void HideScriptsCode()
        {
            _logger.NewLine();
            _logger.Information("============================================");
            _logger.Information("Ocultar código de scripts (js/php):SC");
            _logger.Information("============================================");
            _logger.NewLine();

            const int stringLimit = 150;
            List<string> stringLines = new List<string>();
            _logger.Consultation("Ingrese la ruta madre: ");
            string directory = _logger.ReadLine();
            if (!Directory.Exists(directory))
            {
                _logger.Exit();
                return;
            }

            _logger.Consultation("Ingrese la extensión que desea buscar: ");
            string pattern = _logger.ReadLine();

            foreach (var input in Directory.GetFiles(directory, pattern, SearchOption.TopDirectoryOnly))
            {
                string line = string.Empty;
                string fileName = Path.GetFileName(input);
                _logger.Information("Iniciando lectura de script: {name}", fileName);
                string folderExtension = Path.GetExtension(input)
                    .Replace(".", "");
                string output = Path.Combine(Program._baseDirectory, "converts",
                    folderExtension, fileName);

                string[] fileLines = File.ReadAllLines(input);
                _logger.Information("Iniciando conversión...");
                for (int i = 0; i < fileLines.Length; i++)
                {
                    string fileLine = fileLines[i].Trim();
                    if (!fileLine.StartsWith("SELECT *", StringComparison.CurrentCultureIgnoreCase) && fileLine.StartsWith("*"))
                        continue;

                    resetLine();

                    if (!fileLine.Contains("://") && fileLine.Contains("//"))
                    {
                        string[] lines = fileLine.Split('/');
                        if (lines.Length < 1)
                            continue;

                        if (!string.IsNullOrEmpty(lines[0]) && !string.IsNullOrWhiteSpace(lines[0]))
                            line += lines[0];

                        continue;
                    }

                    line += fileLine;
                    if (line.Contains("<?php"))
                        line += " ";
                }
                stringLines.Add(line);
                _logger.Information("Guardando nuevo script...");
                File.WriteAllLines(output, stringLines.ToArray());
                stringLines.Clear();

                void resetLine()
                {
                    if (line.Length >= stringLimit)
                    {
                        stringLines.Add(line);
                        line = string.Empty;
                    }
                }
            }

            _logger.Debug("Ok");

            Program.ContinueOrExit();
        }

        [Function("Números aleatorio.", 4)]
        public void NumberRandoms()
        {
            _logger.NewLine();
            _logger.Information("============================================");
            _logger.Information("NUMEROS ALEATORIOS:SC");
            _logger.Information("============================================");
            _logger.NewLine();

            _logger.Consultation("Ingrese rango [x,y o x-y]: ");
            string inputS = _logger.ReadLine();
            if (!inputS.Contains("-") && !inputS.Contains(","))
            {
                _logger.Information("Rango incorrecto.");
                Program.ContinueOrExit();
                return;
            }

            string[] range = inputS.Split('-', ',');
            if (!int.TryParse(range[0], out var x))
                x = 0;

            if (!int.TryParse(range[1], out var y))
                y = 0;

            var ran = new Random();
            for (var i = 0; i < 5; i++)
                _logger.Information("Number: {value}", ran.Next(x, y));

            Program.ContinueOrExit();
        }

        #region Leer archivos de s4league
        //[Function("Leer archivos de s4league.", 12)]
        //public async Task<bool> S4LeagueReadFiles()
        //{
        //    _logger.NewLine();
        //    _logger.Information("============================================");
        //    _logger.Information("LEER ARCHIVOS DE S4LEAGUE:SC");
        //    _logger.Information("============================================");
        //    _logger.NewLine();

        //    _logger.Consultation("Ingresa la ruta de la carpeta del juego: ");
        //    var folderPath = _logger.ReadLine();
        //    if (string.IsNullOrEmpty(folderPath) || 
        //        !Directory.Exists(folderPath))
        //    {
        //        _logger.Error("No se pudo encuentrar la carpeta del juego.");
        //        return true;
        //    }

        //    var resourcePath = Path.Combine(folderPath, "resource.s4hd");
        //    if (!File.Exists(resourcePath))
        //    {
        //        _logger.Error("No se pudo encontrar el archivo resource.s4hd");
        //        return true;
        //    }

        //    var s4Zip = S4Zip.OpenZip(resourcePath);
        //    var invalidFiles = new List<S4EntryInfo>();
        //    foreach (var entry in s4Zip.Values.Where(x => x.FullName.Contains(".dds")))
        //    {
        //        try
        //        {
        //            var entryBytes = entry.GetData();
        //            var bitmapImage = entryBytes.GetImageFormat();
        //            switch (bitmapImage)
        //            {
        //                case ImageFormat.bmp:
        //                case ImageFormat.gif:
        //                case ImageFormat.jpg:
        //                case ImageFormat.png:
        //                case ImageFormat.tiff:
        //                    _logger.Information("Posible formato correcto {format} del archivo {filename}", bitmapImage, entry.Name);
        //                    var entryInfo = new S4EntryInfo(entry.FileName, entry.FullName, "." + bitmapImage.ToString(), entryBytes);
        //                    if (!invalidFiles.Contains(entryInfo))
        //                        invalidFiles.Add(entryInfo);
        //                    break;

        //                default:
        //                    break;
        //            }
        //        }
        //        catch
        //        {
        //            continue;
        //        }
        //    }

        //    _logger.Information("Archivos con formato erróneo: {filescount}", invalidFiles.Count);
        //    _logger.Consultation("¿Deseas extraer los archivos? Y/N: ");
        //    var result = _logger.ReadLine();
        //    if (!string.IsNullOrEmpty(result) && result.Equals("y", StringComparison.OrdinalIgnoreCase))
        //    {
        //        foreach (var entry in invalidFiles)
        //        {
        //            var ouput = Path.Combine(Program._baseDirectory, entry.FullName);
        //            ouput = ouput.Replace(@"/", @"\");

        //            if (!Directory.Exists(Path.GetDirectoryName(ouput)))
        //                Directory.CreateDirectory(Path.GetDirectoryName(ouput));
        //            File.WriteAllBytes(ouput, entry.FileBytes);
        //        }
        //        _logger.Debug("Extracción de archivos con éxito.");
        //    }

        //    return true;
        //}
        #endregion

        [Function("Encriptar contraseña a SHA1.", 3)]
        public void EncryptPasswordAcc()
        {
            _logger.NewLine();
            _logger.Information("============================================");
            _logger.Information("[ENCRIPTAR CONTRASEÑA : S4LEAGUE S9]");
            _logger.Information("============================================");
            _logger.NewLine();

            try
            {
                #region FucnOld
                //for (var i = 1; i < 1; i++)
                //{
                //    var acc = await Instance.ActionsDb.GetAccountAsync((ulong)i);

                //    if (acc != null)
                //    {
                //        if (!string.IsNullOrEmpty(acc.Password2))
                //        {
                //            s_logger.Debug("Encriptando contraseña a...{0} : {1}", acc.Username, acc.Id);

                //            var bytes = new byte[16];
                //            using (var rng = new RNGCryptoServiceProvider())
                //                rng.GetBytes(bytes);

                //            var salt = Hash.GetString<SHA1CryptoServiceProvider>(bytes);
                //            var password = Hash.GetString<SHA1CryptoServiceProvider>(acc.Password2 + "+" + salt);

                //            await Instance.ActionsDb.UpdatePasswordAcc(acc.Id, password, salt);
                //            s_logger.Debug("Contraseña encriptada correctamente");
                //        }
                //    }
                //}
                #endregion

                _logger.Consultation("Ingresar usuario: ");
                var username = _logger.ReadLine();
                _logger.Consultation("Ingresar contraseña: ");
                var password = _logger.ReadLine();
                if (password != "")
                {
                    var random = new Random();
                    var bytes = new byte[16];
                    random.NextBytes(bytes);
                    var salt = EncryptText.ToSHA1(bytes);
                    var passwordEncrypt = EncryptText.ToSHA1(password + "+" + salt);
                    var token = EncryptText.ToSHA1($"<{username}+{passwordEncrypt}+united2019>");
                    _logger.Information("Normal Text: {0}\n\t\t\t\tPassword: {1}\n\t\t\t\tSalt: {2}", password, passwordEncrypt, salt);
                    _logger.Information("Token: {0}", token);
                    System.Windows.Forms.Clipboard.SetText($"{username}		{passwordEncrypt}	{salt}	0	{token}");
                }
                else
                {
                    _logger.Information("El texto no puede ser nulo.");
                }
            }
            catch (Exception ex)
            {
                _logger.Information(ex.Message);
            }
            finally
            {
                Program.ContinueOrExit();
            }
        }

        [Function("Desinstalar un juego.", 2)]
        public void UnnistallGame()
        {
            var di = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            _logger.Consultation("Escriba el nombre de la carpeta madre donde se encuentran los archivos: ");
            string name = _logger.ReadLine();
            try
            {
                foreach (var fi in di.GetFiles(name))
                {
                    _logger.Information("Elinimando archivos...{0}", fi.Name);
                    fi.Delete();
                }

                foreach (var fi in di.GetDirectories(name))
                {
                    _logger.Information("Elinimando carpetas...{0}", fi.Name);
                    fi.Delete(true);
                }
            }
            catch (Exception ex)
            {
                _logger.Warning(ex.Message);
            }
            finally
            {
                Program.ContinueOrExit();
            }
        }

        [Function("Encriptar texto a RNG.", 1)]
        public void GetEncryptText()
        {
            _logger.Consultation("Ingrese el texto que desea encriptar: ");
            string value = _logger.ReadLine();

            var newSalt = new byte[24];
            using (var csprng = new RNGCryptoServiceProvider())
                csprng.GetBytes(newSalt);

            var hash = new Rfc2898DeriveBytes(value, newSalt, 24000).GetBytes(24);
            string salt = Convert.ToBase64String(newSalt);
            string valueE = Convert.ToBase64String(hash);

            _logger.Information("Normal: {0}", value);
            _logger.Information("Encrypt: {0}", valueE);
            _logger.Information("Salt: {0}", salt);
            Program.ContinueOrExit();
        }
    }
}
