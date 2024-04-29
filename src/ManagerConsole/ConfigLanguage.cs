using LogMJ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleMJ
{
    internal class ConfigLanguage
    {
        public static string Main { get; set; }
        public static string TextInWhite { get; set; }
        public static string MaxLength { get; set; }
        public static string MaxLength2 { get; set; }
        public static string MinLength { get; set; }
        public static string NoIsCheck { get; set; }
        public static string LowAccount { get; set; }
        public static string FaliedEmail { get; set; }
        public static string Success { get; set; }
        public static string FaliedSignUp { get; set; }
        public static string NoIsPass { get; set; }
        public static string MaxNumber { get; set; }
        public static string BadNick { get; set; }
        public static string BadUser { get; set; }
        public static string ErrorSignUp { get; set; }
        private static string Path { get; } = @"ConfigLanguage.xml";

        public static CLogger Logger { get; set; } = new CLogger("Console.log");
        public static XmlDocument Doc { get; set; } = new XmlDocument();

        public ConfigLanguage()
        {
        }

        public static void XmlConfigPor()
        {
            Doc.Load(Path);

            XmlElement Main = Doc.CreateElement("WindowSignUpPor");
            Main.SetAttribute("Close", "Você quer entrar?".EncriptarMD5());

            XmlElement Text = Doc.CreateElement("TextInWhite");
            Text.SetAttribute("Value", "Por favor, certifique-se de preencher todos os campos.".EncriptarMD5());

            XmlElement MaxLength = Doc.CreateElement("MaxLength");
            MaxLength.SetAttribute("Value", "Os caracteres máximos permitidos são 28.".EncriptarMD5());

            XmlElement MaxLength2 = Doc.CreateElement("MaxLength2");
            MaxLength2.SetAttribute("Value", "Os caracteres máximos permitidos são 40.".EncriptarMD5());

            XmlElement MinLength = Doc.CreateElement("MinLength");
            MinLength.SetAttribute("Value", "Os caracteres mínimos permitidos são 4.".EncriptarMD5());

            XmlElement NoIsCheck = Doc.CreateElement("NoIsCheck");
            NoIsCheck.SetAttribute("Value", "Por favor, aceite os termos e condições.".EncriptarMD5());

            XmlElement LowAccount = Doc.CreateElement("LowAccount");
            LowAccount.SetAttribute("Value", "As informações da conta devem ter pelo menos 6 caracteres.".EncriptarMD5());

            XmlElement FaliedEmail = Doc.CreateElement("FaliedEmail");
            FaliedEmail.SetAttribute("Value", "Por favor, não se esqueça de colocar um email válido.".EncriptarMD5());

            XmlElement Success = Doc.CreateElement("Success");
            Success.SetAttribute("Value", "Conta registrada corretamente.".EncriptarMD5());

            XmlElement FaliedSignUp = Doc.CreateElement("FaliedSignUp");
            FaliedSignUp.SetAttribute("Value", "A conta não pôde ser registrada.".EncriptarMD5());

            XmlElement NoIsPass = Doc.CreateElement("NoIsPass");
            NoIsPass.SetAttribute("Value", "Por favor, certifique-se de que as senhas coincidam.".EncriptarMD5());

            XmlElement MaxNumber = Doc.CreateElement("MaxNumber");
            MaxNumber.SetAttribute("Value", "Você atingiu o número máximo de inscrições por semana.".EncriptarMD5());

            XmlElement BadNick = Doc.CreateElement("BadNick");
            BadNick.SetAttribute("Value", "Your nickname placed is not allowed, try another.".EncriptarMD5());

            XmlElement BadUser = Doc.CreateElement("BadUser");
            BadUser.SetAttribute("Value", "Uso de caracteres não é permitido.".EncriptarMD5());

            XmlElement ErrorSignUp = Doc.CreateElement("ErrorSignUp");
            ErrorSignUp.SetAttribute("Value", "Por favor, evite modificar 'SigUpAccountsForWeek'.".EncriptarMD5());

            Main.AppendChild(Text);
            Main.AppendChild(MaxLength);
            Main.AppendChild(MaxLength2);
            Main.AppendChild(MinLength);
            Main.AppendChild(NoIsCheck);
            Main.AppendChild(LowAccount);
            Main.AppendChild(FaliedEmail);
            Main.AppendChild(Success);
            Main.AppendChild(FaliedSignUp);
            Main.AppendChild(NoIsPass);
            Main.AppendChild(MaxNumber);
            Main.AppendChild(BadNick);
            Main.AppendChild(BadUser);
            Main.AppendChild(ErrorSignUp);

            Doc.DocumentElement.AppendChild(Main);

            Doc.Save(Path);
        }

        public static void XmlConfigEng()
        {
            Doc.Load(Path);

            XmlElement Main = Doc.CreateElement("WindowSignUpEng");
            Main.SetAttribute("Close", "Do you want to log in?".EncriptarMD5());

            XmlElement Text = Doc.CreateElement("TextInWhite");
            Text.SetAttribute("Value", "Please, be sure to fill in all the fields.".EncriptarMD5());

            XmlElement MaxLength = Doc.CreateElement("MaxLength");
            MaxLength.SetAttribute("Value", "The maximum allowed characters are 28.".EncriptarMD5());

            XmlElement MaxLength2 = Doc.CreateElement("MaxLength2");
            MaxLength2.SetAttribute("Value", "The maximum allowed characters are 40.".EncriptarMD5());

            XmlElement MinLength = Doc.CreateElement("MinLength");
            MinLength.SetAttribute("Value", "The minimum allowed characters are 4.".EncriptarMD5());

            XmlElement NoIsCheck = Doc.CreateElement("NoIsCheck");
            NoIsCheck.SetAttribute("Value", "Please accept the terms and conditions.".EncriptarMD5());

            XmlElement LowAccount = Doc.CreateElement("LowAccount");
            LowAccount.SetAttribute("Value", "Account information must be at least 6 characters long.".EncriptarMD5());

            XmlElement FaliedEmail = Doc.CreateElement("FaliedEmail");
            FaliedEmail.SetAttribute("Value", "Please do not forget to put a valid email.".EncriptarMD5());

            XmlElement Success = Doc.CreateElement("Success");
            Success.SetAttribute("Value", "Account registered correctly.".EncriptarMD5());

            XmlElement FaliedSignUp = Doc.CreateElement("FaliedSignUp");
            FaliedSignUp.SetAttribute("Value", "The account could not be registered.".EncriptarMD5());

            XmlElement NoIsPass = Doc.CreateElement("NoIsPass");
            NoIsPass.SetAttribute("Value", "Please, make sure the passwords match.".EncriptarMD5());

            XmlElement MaxNumber = Doc.CreateElement("MaxNumber");
            MaxNumber.SetAttribute("Value", "You reached the maximum number of registrations per week.".EncriptarMD5());

            XmlElement BadNick = Doc.CreateElement("BadNick");
            BadNick.SetAttribute("Value", "Your nickname placed is not allowed, try another.".EncriptarMD5());

            XmlElement BadUser = Doc.CreateElement("BadUser");
            BadUser.SetAttribute("Value", "Use of characters is not allowed.".EncriptarMD5());

            XmlElement ErrorSignUp = Doc.CreateElement("ErrorSignUp");
            ErrorSignUp.SetAttribute("Value", "Please avoid modifying 'SigUpAccountsForWeek'.".EncriptarMD5());

            Main.AppendChild(Text);
            Main.AppendChild(MaxLength);
            Main.AppendChild(MaxLength2);
            Main.AppendChild(MinLength);
            Main.AppendChild(NoIsCheck);
            Main.AppendChild(LowAccount);
            Main.AppendChild(FaliedEmail);
            Main.AppendChild(Success);
            Main.AppendChild(FaliedSignUp);
            Main.AppendChild(NoIsPass);
            Main.AppendChild(MaxNumber);
            Main.AppendChild(BadNick);
            Main.AppendChild(BadUser);
            Main.AppendChild(ErrorSignUp);

            Doc.DocumentElement.AppendChild(Main);

            Doc.Save(Path);
        }

        internal class Load
        {
            public Load() { }

            public static void LanguageEng()
            {
                XDocument _Doc = XDocument.Load(Path);

                if (File.Exists(Path))
                {
                    foreach (XElement _ConfigLanguage in _Doc.Descendants("WindowSignUpEng"))
                    {
                        Main = _ConfigLanguage.Attribute("Close").Value.DesencriptarMD5();
                        TextInWhite = _ConfigLanguage.Element("TextInWhite").Attribute("Value").Value.DesencriptarMD5();
                        MaxLength = _ConfigLanguage.Element("MaxLength").Attribute("Value").Value.DesencriptarMD5();
                        MaxLength2 = _ConfigLanguage.Element("MaxLength2").Attribute("Value").Value.DesencriptarMD5();
                        MinLength = _ConfigLanguage.Element("MinLength").Attribute("Value").Value.DesencriptarMD5();
                        NoIsCheck = _ConfigLanguage.Element("NoIsCheck").Attribute("Value").Value.DesencriptarMD5();
                        LowAccount = _ConfigLanguage.Element("LowAccount").Attribute("Value").Value.DesencriptarMD5();
                        FaliedEmail = _ConfigLanguage.Element("FaliedEmail").Attribute("Value").Value.DesencriptarMD5();
                        Success = _ConfigLanguage.Element("Success").Attribute("Value").Value.DesencriptarMD5();
                        FaliedSignUp = _ConfigLanguage.Element("FaliedSignUp").Attribute("Value").Value.DesencriptarMD5();
                        NoIsPass = _ConfigLanguage.Element("NoIsPass").Attribute("Value").Value.DesencriptarMD5();
                        MaxNumber = _ConfigLanguage.Element("MaxNumber").Attribute("Value").Value.DesencriptarMD5();
                        BadNick = _ConfigLanguage.Element("BadNick").Attribute("Value").Value.DesencriptarMD5();
                        BadUser = _ConfigLanguage.Element("BadUser").Attribute("Value").Value.DesencriptarMD5();
                        ErrorSignUp = _ConfigLanguage.Element("ErrorSignUp").Attribute("Value").Value.DesencriptarMD5();

                        Logger.InfoMsg("Window: {0}", Main);
                        Logger.InfoMsg("TextInWhite: {0}", TextInWhite);
                        Logger.InfoMsg("MaxLength: {0}", MaxLength);
                        Logger.InfoMsg("MaxLength2: {0}", MaxLength2);
                        Logger.InfoMsg("MinLength: {0}", MinLength);
                        Logger.InfoMsg("NoIsCheck: {0}", NoIsCheck);
                        Logger.InfoMsg("LowAccount: {0}", LowAccount);
                        Logger.InfoMsg("FaliedEmail: {0}", FaliedEmail);
                        Logger.InfoMsg("Success: {0}", Success);
                        Logger.InfoMsg("FaliedSignUp: {0}", FaliedSignUp);
                        Logger.InfoMsg("NoIsPass: {0}", NoIsPass);
                        Logger.InfoMsg("MaxNumber: {0}", MaxNumber);
                        Logger.InfoMsg("BadNick: {0}", BadNick);
                        Logger.InfoMsg("BadUser: {0}", BadUser);
                        Logger.InfoMsg("ErrorSignUp: {0}", ErrorSignUp);
                    }

                    foreach (XElement _WindowInterFace in _Doc.Descendants("WindowInterFaceEng"))
                    {
                        WindowInterFace.LabelPw = _WindowInterFace.Element("LabelPw").Attribute("Value").Value.DesencriptarMD5();
                        WindowInterFace.LabelPw2 = _WindowInterFace.Element("LabelPw2").Attribute("Value").Value.DesencriptarMD5();
                        WindowInterFace.LabelEmail = _WindowInterFace.Element("LabelEmail").Attribute("Value").Value.DesencriptarMD5();
                        WindowInterFace.LabelCheck = _WindowInterFace.Element("LabelCheck").Attribute("Value").Value.DesencriptarMD5();

                        Logger.InfoMsg("LabelPw: {0}", WindowInterFace.LabelPw);
                        Logger.InfoMsg("LabelPw2: {0}", WindowInterFace.LabelPw2);
                        Logger.InfoMsg("LabelEmail: {0}", WindowInterFace.LabelEmail);
                        Logger.InfoMsg("LabelCheck: {0}", WindowInterFace.LabelCheck);
                    }
                }
            }

            public static void LanguagePor()
            {
                XDocument _Doc = XDocument.Load(Path);

                if (File.Exists(Path))
                {
                    foreach (XElement _ConfigLanguage in _Doc.Descendants("WindowSignUpPor"))
                    {
                        Main = _ConfigLanguage.Attribute("Close").Value.DesencriptarMD5();
                        TextInWhite = _ConfigLanguage.Element("TextInWhite").Attribute("Value").Value.DesencriptarMD5();
                        MaxLength = _ConfigLanguage.Element("MaxLength").Attribute("Value").Value.DesencriptarMD5();
                        MaxLength2 = _ConfigLanguage.Element("MaxLength2").Attribute("Value").Value.DesencriptarMD5();
                        MinLength = _ConfigLanguage.Element("MinLength").Attribute("Value").Value.DesencriptarMD5();
                        NoIsCheck = _ConfigLanguage.Element("NoIsCheck").Attribute("Value").Value.DesencriptarMD5();
                        LowAccount = _ConfigLanguage.Element("LowAccount").Attribute("Value").Value.DesencriptarMD5();
                        FaliedEmail = _ConfigLanguage.Element("FaliedEmail").Attribute("Value").Value.DesencriptarMD5();
                        Success = _ConfigLanguage.Element("Success").Attribute("Value").Value.DesencriptarMD5();
                        FaliedSignUp = _ConfigLanguage.Element("FaliedSignUp").Attribute("Value").Value.DesencriptarMD5();
                        NoIsPass = _ConfigLanguage.Element("NoIsPass").Attribute("Value").Value.DesencriptarMD5();
                        MaxNumber = _ConfigLanguage.Element("MaxNumber").Attribute("Value").Value.DesencriptarMD5();
                        BadNick = _ConfigLanguage.Element("BadNick").Attribute("Value").Value.DesencriptarMD5();
                        BadUser = _ConfigLanguage.Element("BadUser").Attribute("Value").Value.DesencriptarMD5();
                        ErrorSignUp = _ConfigLanguage.Element("ErrorSignUp").Attribute("Value").Value.DesencriptarMD5();

                        Logger.InfoMsg("Window: {0}", Main);
                        Logger.InfoMsg("TextInWhite: {0}", TextInWhite);
                        Logger.InfoMsg("MaxLength: {0}", MaxLength);
                        Logger.InfoMsg("MaxLength2: {0}", MaxLength2);
                        Logger.InfoMsg("MinLength: {0}", MinLength);
                        Logger.InfoMsg("NoIsCheck: {0}", NoIsCheck);
                        Logger.InfoMsg("LowAccount: {0}", LowAccount);
                        Logger.InfoMsg("FaliedEmail: {0}", FaliedEmail);
                        Logger.InfoMsg("Success: {0}", Success);
                        Logger.InfoMsg("FaliedSignUp: {0}", FaliedSignUp);
                        Logger.InfoMsg("NoIsPass: {0}", NoIsPass);
                        Logger.InfoMsg("MaxNumber: {0}", MaxNumber);
                        Logger.InfoMsg("BadNick: {0}", BadNick);
                        Logger.InfoMsg("BadUser: {0}", BadUser);
                        Logger.InfoMsg("ErrorSignUp: {0}", ErrorSignUp);
                    }

                    foreach (XElement _WindowInterFace in _Doc.Descendants("WindowInterFacePor"))
                    {
                        WindowInterFace.LabelUser = _WindowInterFace.Element("LabelUser").Attribute("Value").Value.DesencriptarMD5();
                        WindowInterFace.LabelPw = _WindowInterFace.Element("LabelPw").Attribute("Value").Value.DesencriptarMD5();
                        WindowInterFace.LabelPw2 = _WindowInterFace.Element("LabelPw2").Attribute("Value").Value.DesencriptarMD5();
                        WindowInterFace.LabelEmail = _WindowInterFace.Element("LabelEmail").Attribute("Value").Value.DesencriptarMD5();
                        WindowInterFace.LabelCheck = _WindowInterFace.Element("LabelCheck").Attribute("Value").Value.DesencriptarMD5();

                        Logger.InfoMsg("LabelUser: {0}", WindowInterFace.LabelUser);
                        Logger.InfoMsg("LabelPw: {0}", WindowInterFace.LabelPw);
                        Logger.InfoMsg("LabelPw2: {0}", WindowInterFace.LabelPw2);
                        Logger.InfoMsg("LabelEmail: {0}", WindowInterFace.LabelEmail);
                        Logger.InfoMsg("LabelCheck: {0}", WindowInterFace.LabelCheck);
                    }
                }
            }
        }

        internal class WindowInterFace
        {
            public static string LabelUser { get; set; }
            public static string LabelPw { get; set; }
            public static string LabelPw2 { get; set; }
            public static string LabelEmail { get; set; }
            public static string LabelCheck { get; set; }

            public WindowInterFace() { }

            public static void XmlConfigPor()
            {
                Doc.Load(Path);

                XmlElement Main = Doc.CreateElement("WindowInterFacePor");
                // Main.SetAttribute("Close", "Do you want to log in?".EncriptarMD5());

                XmlElement LabelUser = Doc.CreateElement("LabelUser");
                LabelUser.SetAttribute("Value", "Nome Usuário:".EncriptarMD5());

                //XmlElement LabelNick = Doc.CreateElement("LabelNick");
                //LabelNick.SetAttribute("Value", "The minimum allowed characters are 4.".EncriptarMD5());

                XmlElement LabelPw = Doc.CreateElement("LabelPw");
                LabelPw.SetAttribute("Value", "Senha:".EncriptarMD5());

                XmlElement LabelPw2 = Doc.CreateElement("LabelPw2");
                LabelPw2.SetAttribute("Value", "R. Senha:".EncriptarMD5());

                XmlElement LabelEmail = Doc.CreateElement("LabelEmail");
                LabelEmail.SetAttribute("Value", "Mail:".EncriptarMD5());

                XmlElement LabelCheck = Doc.CreateElement("LabelCheck");
                LabelCheck.SetAttribute("Value", "Eu aceito os termos e condições.".EncriptarMD5());

                Main.AppendChild(LabelUser);
                //Main.AppendChild(LabelNick);
                Main.AppendChild(LabelPw);
                Main.AppendChild(LabelPw2);
                Main.AppendChild(LabelEmail);
                Main.AppendChild(LabelCheck);

                Doc.DocumentElement.AppendChild(Main);

                Doc.Save(Path);
            }

            public static void XmlConfigEng()
            {
                Doc.Load(Path);

                XmlElement Main = Doc.CreateElement("WindowInterFaceEng");
                // Main.SetAttribute("Close", "Do you want to log in?".EncriptarMD5());

                //XmlElement LabelUser = Doc.CreateElement("LabelUser");
                //LabelUser.SetAttribute("Value", "Nome Usuário:".EncriptarMD5());

                //XmlElement LabelNick = Doc.CreateElement("LabelNick");
                //LabelNick.SetAttribute("Value", "The minimum allowed characters are 4.".EncriptarMD5());

                XmlElement LabelPw = Doc.CreateElement("LabelPw");
                LabelPw.SetAttribute("Value", "Password:".EncriptarMD5());

                XmlElement LabelPw2 = Doc.CreateElement("LabelPw2");
                LabelPw2.SetAttribute("Value", "R. Password:".EncriptarMD5());

                XmlElement LabelEmail = Doc.CreateElement("LabelEmail");
                LabelEmail.SetAttribute("Value", "Mail:".EncriptarMD5());

                XmlElement LabelCheck = Doc.CreateElement("LabelCheck");
                LabelCheck.SetAttribute("Value", "I accept the terms and conditions.".EncriptarMD5());

                //Main.AppendChild(LabelUser);
                //Main.AppendChild(LabelNick);
                Main.AppendChild(LabelPw);
                Main.AppendChild(LabelPw2);
                Main.AppendChild(LabelEmail);
                Main.AppendChild(LabelCheck);

                Doc.DocumentElement.AppendChild(Main);

                Doc.Save(Path);
            }
        }
    }
}
