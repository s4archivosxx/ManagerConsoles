using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Speech.Recognition;
using ManagerProgram.Resource;
using JLib.Console;
using System.Linq;

namespace ManagerProgram
{
    internal class Program
    {
        private static CLog logger;
        private static XmlCache xmlCache;
        private static string s_voiceText = null;
        private static IReadOnlyDictionary<int, CProgram> _keys;
        // private static SpeechRecognitionEngine s_listen = new SpeechRecognitionEngine();

        private static void Main() => new Program().Starting();

        internal void Starting()
        {
            Console.Title = "ManagerPrograms";
            CLog.Initializate("Console.log");
            logger = CLog.Logger.SetSourceContext("MAIN");
            // Recognition();
            xmlCache = new XmlCache();
            xmlCache.PreCache();
            _keys = xmlCache.GetConfigApp();
            CachingList();
        }

        internal void CachingList()
        {
            logger.InfoMsg("UserPC: {0}", Environment.MachineName);
            logger.InfoMsg("Fecha: {0}", DateTime.Now);
            logger.InfoMsg("Versión: {0}", Assembly.GetEntryAssembly().GetName().Version);
            logger.NewLine();

            logger.Message("===========================");
            logger.Message("LISTA DE PROGRAMAS");
            logger.Message("===========================");
            logger.NewLine();

            foreach (var funcs in _keys.Values)
                logger.CmdMsg("{0}.{1}", funcs.Number, funcs.Name);

            StartFunc();
        }

        // internal void Recognition()
        // {
        //    s_listen.SetInputToDefaultAudioDevice();
        //    s_listen.LoadGrammarAsync(new DictationGrammar());
        //    s_listen.SpeechRecognized += (s, e) => Recognized(e);
        //    s_listen.RecognizeAsync(RecognizeMode.Multiple);
        // }

        internal void StartFunc()
        {
            logger.NewLine();
            logger.Consultation("Escriba o pronuncié el indice del programa a ejecutar: ", false);
            string text = logger.ReadLine();
            ReadProgram(text, true);
            logger.Wait();
        }

        internal void ReadProgram(string text, bool voicenull)
        {
            if (voicenull)
                s_voiceText = null;

            try
            {
                var fuc = (s_voiceText ?? text).ToLower();
                var cof2 = _keys.Values.FirstOrDefault(f => f.Number.ToString() == fuc);

                if (cof2 != null)
                {
                    logger.NewLine();
                    logger.DebugMsg("Ejecutando {0}...", true, cof2.Name);
                    StartProgram(cof2.Url, cof2.ParamsS);
                    logger.Beep();
                    System.Threading.Thread.Sleep(750);
                    RestartList();
                }
                else
                {
                    logger.NewLine();
                    logger.WarnMsg("Verifique si existe el id[{0}] en su archivo de configuración.", fuc);
                    RestartList();
                }
            }
            catch (Exception ex)
            {
                logger.WarnMsg(ex.Message);
                RestartList();
            }
        }

        internal void StartProgram(string url, string args)
        {
            try
            {
                using (var p = new Process())
                {
                    p.StartInfo.FileName = url;
                    p.StartInfo.Arguments = args;
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                logger.WarnMsg(ex.Message);
            }
        }

        internal void RestartList()
        {
            logger.DebugMsg("Restaurando lista...");
            logger.NewLine();
            System.Threading.Thread.Sleep(500);
            logger.Beep();
            logger.Beep();
            Console.Clear();
            CachingList();
        }

        //internal void Recognized(SpeechRecognizedEventArgs e)
        //{
        //    foreach (RecognizedWordUnit word in e.Result.Words)
        //        s_voiceText = word.Text;

        //    switch (s_voiceText)
        //    {
        //        case "uno":
        //            ReadProgram("1", true);
        //            break;

        //        case "dos":
        //            ReadProgram("2", true);
        //            break;

        //        case "tres":
        //            ReadProgram("3", true);
        //            break;

        //        case "cuatro":
        //            ReadProgram("4", true);
        //            break;

        //        case "cinco":
        //            ReadProgram("5", true);
        //            break;

        //        case "seis":
        //            ReadProgram("6", true);
        //            break;

        //        case "siete":
        //            ReadProgram("7", true);
        //            break;

        //        case "ocho":
        //            ReadProgram("8", true);
        //            break;

        //        case "nueve":
        //            ReadProgram("9", true);
        //            break;

        //        case "diez":
        //            ReadProgram("10", true);
        //            break;

        //        case "once":
        //            ReadProgram("11", true);
        //            break;

        //        case "doce":
        //            ReadProgram("12", true);
        //            break;

        //        case "trece":
        //            ReadProgram("13", true);
        //            break;

        //        case "catorce":
        //            ReadProgram("14", true);
        //            break;

        //        case "quince":
        //            ReadProgram("15", true);
        //            break;

        //        case "dieziseis":
        //            ReadProgram("16", true);
        //            break;

        //        case "diezisiete":
        //            ReadProgram("17", true);
        //            break;

        //        case "dieziocho":
        //            ReadProgram("18", true);
        //            break;

        //        case "diezinueve":
        //            ReadProgram("19", true);
        //            break;

        //        case "veinte":
        //            ReadProgram("20", true);
        //            break;
        //    }
        //}
    }
}
