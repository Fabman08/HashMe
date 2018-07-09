using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using com.prjteam.HashMe.DTO;
using com.prjteam.HashMe.Exc;
using com.prjteam.HashMe.Properties;
using com.prjteam.HashUtil;

namespace com.prjteam.HashMe
{
    static class Program
    {
        private static readonly string TemplateFile = Application.StartupPath + @"\Template\template.xml";
        private static XDocument _xDocument;
        private static string _plainText;
        private static StringUtil.HASH_ALGORITHM _hashAlgorithm;
        private static StringUtil.ENCRYPTION_FORMAT _encryptionFormat;
        private static StringUtil.SALT_POSITION _saltPosition;
        private static StringUtil.ENCODING_TYPES _encodingType;
        private static byte[] _salt;
        private static bool _addSaltToHash;

        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        #region Private function

        private static void SetBaseData(string text, string textField, string cbAlgo, string cbEncFormat, bool rbPosStartChecked, bool rbPosEndChecked, string cbEncTypes, string tbSalt, bool addSalt)
        {
            _plainText = GetText(text,textField);
            _hashAlgorithm = GetHashAlgorithm(cbAlgo);
            _encryptionFormat = GetEncryptionFormat(_hashAlgorithm, cbEncFormat);
            _saltPosition = GetSaltPosition(rbPosStartChecked, rbPosEndChecked, _hashAlgorithm);
            _encodingType = GetEncodingType(cbEncTypes, _hashAlgorithm);
            _salt = GetSaltByte(tbSalt, _encodingType);
            _addSaltToHash = addSalt;
        }

        private static void ResetBaseData()
        {
            _plainText = string.Empty;
            _hashAlgorithm = StringUtil.HASH_ALGORITHM.Unselected;
            _encryptionFormat = StringUtil.ENCRYPTION_FORMAT.Unselected;
            _encodingType = StringUtil.ENCODING_TYPES.Unselected;
        }

        private static bool IsDataEditable()
        {
            DialogResult res = MessageBox.Show(Resources.Program_IsDataEditable_Do_you_want_to_keep_data_editable, Resources.Program_IsDataEditable_Saving_Template, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return res.Equals(DialogResult.Yes);
        }

        private static string GetOutputFileName(string inputFile)
        {
            string filePath = inputFile.Replace(Path.GetFileName(inputFile), "");
            string fileName = Path.GetFileNameWithoutExtension(inputFile);
            string fileExtension = Path.GetExtension(inputFile);
            
            return filePath + fileName + ".hashed" + fileExtension;

        }

        private static void SaveXmlTemplate(int selectedIndex, DtoTemplate dtoTemplate, int totTemplate)
        {
            XElement xElementTemplate;

            if (selectedIndex != -1) //--- Saving Edited Template
            {
                xElementTemplate = _xDocument.Descendants("TEMPLATE").FirstOrDefault(c => c.Attribute("index").Value.Equals(dtoTemplate.Index.ToString(CultureInfo.InvariantCulture)));
                if (xElementTemplate != null)
                {
                    xElementTemplate.SetElementValue("NAME", dtoTemplate.Name);
                    xElementTemplate.SetElementValue("SALT", dtoTemplate.Salt);
                    xElementTemplate.SetElementValue("SALT_POSITION", dtoTemplate.SaltPosition);
                    xElementTemplate.SetElementValue("SALT_ADD", dtoTemplate.SaltToHash.ToString());
                    xElementTemplate.SetElementValue("ALGORITHM", ((int)dtoTemplate.HashAlgorithm).ToString(CultureInfo.InvariantCulture));
                    xElementTemplate.SetElementValue("ENCRYPTION_FORMAT", ((int)dtoTemplate.EncryptionFormat).ToString(CultureInfo.InvariantCulture));
                    xElementTemplate.SetElementValue("ENCODING_TYPE", ((int)dtoTemplate.EncodingType).ToString(CultureInfo.InvariantCulture));
                    xElementTemplate.SetElementValue("EDITABLE", dtoTemplate.Editable.ToString());
                }
            }
            else //--- Saving New Template
            {
                xElementTemplate = new XElement("TEMPLATE",
                    new XElement("NAME", dtoTemplate.Name),
                    new XElement("SALT", dtoTemplate.Salt),
                    new XElement("SALT_POSITION", dtoTemplate.SaltPosition),
                    new XElement("SALT_ADD", dtoTemplate.SaltToHash.ToString()),
                    new XElement("ALGORITHM", ((int)dtoTemplate.HashAlgorithm).ToString(CultureInfo.InvariantCulture)),
                    new XElement("ENCRYPTION_FORMAT", ((int)dtoTemplate.EncryptionFormat).ToString(CultureInfo.InvariantCulture)),
                    new XElement("ENCODING_TYPE", ((int)dtoTemplate.EncodingType).ToString(CultureInfo.InvariantCulture)),
                    new XElement("EDITABLE", dtoTemplate.Editable.ToString()));

                xElementTemplate.SetAttributeValue("index", totTemplate.ToString(CultureInfo.InvariantCulture));

                var xElement = _xDocument.Element("root");
                if (xElement != null) xElement.Add(xElementTemplate);
            }

            _xDocument.Save(TemplateFile);
        }

        private static string SaveHashedFile(string tbImport)
        {
            string fileOutputName = GetOutputFileName(tbImport);
            
            if (File.Exists(tbImport))
            {                
                StreamReader sReader = new StreamReader(tbImport);
                StreamWriter sWriter = new StreamWriter(fileOutputName);

                while (!sReader.EndOfStream)
                {
                    string plainPwd = sReader.ReadLine();
                    string hashedPwd = StringHashing.ComputeHash(plainPwd, _hashAlgorithm, _salt, _encryptionFormat, _encodingType, _saltPosition, _addSaltToHash);

                    sWriter.WriteLine(plainPwd + ";" + hashedPwd);

                }

                sWriter.Close();
                sReader.Close();

            }

            return fileOutputName;

        }


        #endregion

        #region Template Manager

        public static List<DtoTemplate> LoadTemplate()
        {
            int counter = 0;
            List<DtoTemplate> templList = new List<DtoTemplate>();

            try
            {
                if (!File.Exists(TemplateFile))
                {
                    MessageBox.Show(Resources.Program_LoadTemplate_Warning__Template_file_not_found__Please_check + TemplateFile, Resources.Program_LoadTemplate_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return templList;
                }

                _xDocument = XDocument.Load(TemplateFile);

                var templates = from tmpl in _xDocument.Descendants("TEMPLATE")
                                orderby (int)tmpl.Attribute("index")
                                select new
                                {
                                    Name = tmpl.Element("NAME").Value,
                                    Salt = tmpl.Element("SALT").Value,
                                    SaltPosition = tmpl.Element("SALT_POSITION").Value,
                                    SaltAdd = tmpl.Element("SALT_ADD").Value,
                                    Algorithm = tmpl.Element("ALGORITHM").Value,
                                    EncryptionFormat = tmpl.Element("ENCRYPTION_FORMAT").Value,
                                    EncodingType = tmpl.Element("ENCODING_TYPE").Value,
                                    Editable = tmpl.Element("EDITABLE").Value
                                };

                foreach (var tmpl in templates)
                {
                    StringUtil.HASH_ALGORITHM hashAlgorithm;
                    if (!Enum.TryParse(tmpl.Algorithm, out hashAlgorithm))
                        throw new Exception();

                    StringUtil.ENCRYPTION_FORMAT encryptionFormat;
                    if (!Enum.TryParse(tmpl.EncryptionFormat, out encryptionFormat))
                        throw new Exception();

                    StringUtil.ENCODING_TYPES encodingType;
                    if (!Enum.TryParse(tmpl.EncodingType, out encodingType))
                        throw new Exception();

                    StringUtil.SALT_POSITION saltPosition;
                    if (!Enum.TryParse(tmpl.SaltPosition, out saltPosition))
                        throw new Exception();


                    DtoTemplate dtoTmpl = new DtoTemplate(counter, tmpl.Name, tmpl.Salt, saltPosition, Convert.ToBoolean(tmpl.SaltAdd), hashAlgorithm, encryptionFormat, encodingType, Convert.ToBoolean(tmpl.Editable));

                    templList.Add(dtoTmpl);

                    counter++;
                }

            }
            catch (Exception)
            {
                MessageBox.Show(Resources.Program_LoadTemplate_Warning__XML_Template_file_corrupted__Check_syntax, Resources.Program_LoadTemplate_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return templList;

        }

        public static void SaveTemplate(int totTemplate, int selectedIndex, string cbTemplate, string cbAlgo, string cbEncFormat, bool rbPosStartChecked, bool rbPosEndChecked, string cbEncTypes, string tbSalt, bool addSalt)
        {                        
            ResetBaseData();

            SetBaseData(cbTemplate, "Template name", cbAlgo, cbEncFormat, rbPosStartChecked, rbPosEndChecked, cbEncTypes, tbSalt, addSalt);

            DtoTemplate dtoTemplate = new DtoTemplate(selectedIndex, _plainText, tbSalt, _saltPosition, _addSaltToHash, _hashAlgorithm, _encryptionFormat, _encodingType, IsDataEditable());

            SaveXmlTemplate(selectedIndex, dtoTemplate, totTemplate);

            MessageBox.Show(Resources.Program_SaveTemplate_Template_saved, Resources.Program_SaveTemplate_Saving, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
          
        public static void DeleteTemplate(int idTemplate)
        {
            try
            {
                _xDocument.Descendants("TEMPLATE").Where(x => (int)x.Attribute("index") == idTemplate).Remove();

                _xDocument.Save(TemplateFile);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Program_LoadTemplate_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Init Enums

        public static void GetEnumList(ComboBox comboBoxSource, Type enumValues)
        {
            Array arrayValues = Enum.GetValues(enumValues);

            foreach (string valueDescription in from int val in arrayValues select Enum.GetName(enumValues, val))
            {
                comboBoxSource.Items.Add(valueDescription);
            }
        }

        #endregion

        #region Check data

        public static string GetText(string strInput, string fieldname)
        {
            if (string.IsNullOrEmpty(strInput) || string.IsNullOrWhiteSpace(strInput))
                throw new GenericFieldException(string.Format("Please fill {0} field", fieldname));

            return strInput;
        }

        public static StringUtil.HASH_ALGORITHM GetHashAlgorithm(string cbAlgo)
        {
            StringUtil.HASH_ALGORITHM hashAlg;

            if (string.IsNullOrWhiteSpace(cbAlgo))
                throw new GenericFieldException("Please fill Algorithm field");

            Enum.TryParse(cbAlgo, out hashAlg);

            return hashAlg;
        }

        public static StringUtil.ENCRYPTION_FORMAT GetEncryptionFormat(StringUtil.HASH_ALGORITHM hashAlgorithm, string cbEncFormat)
        {
            StringUtil.ENCRYPTION_FORMAT encFormat;

            if ((string.IsNullOrWhiteSpace(cbEncFormat)) && (hashAlgorithm != StringUtil.HASH_ALGORITHM.Md5))
                throw new GenericFieldException("Please fill Hash Encryption Format field");

            Enum.TryParse(cbEncFormat, out encFormat);

            return encFormat;
        }

        public static StringUtil.SALT_POSITION GetSaltPosition(bool isRbPosStartChecked, bool isRbPosEndChecked, StringUtil.HASH_ALGORITHM hashAlgorithm)
        {

            if (((!isRbPosStartChecked) && (!isRbPosEndChecked)) && (hashAlgorithm != StringUtil.HASH_ALGORITHM.Md5))
                throw new GenericFieldException("Please select Salt Position");

            return (isRbPosStartChecked ? StringUtil.SALT_POSITION.Head : StringUtil.SALT_POSITION.Tail);
        }

        public static StringUtil.ENCODING_TYPES GetEncodingType(string cbEncTypes, StringUtil.HASH_ALGORITHM hashAlgorithm)
        {
            StringUtil.ENCODING_TYPES encodingType;

            if ((string.IsNullOrWhiteSpace(cbEncTypes)) && (hashAlgorithm != StringUtil.HASH_ALGORITHM.Md5))
                throw new GenericFieldException("Please fill Encoding Type field");

            Enum.TryParse(cbEncTypes, out encodingType);

            return encodingType;
        }

        public static byte[] GetSaltByte(string tbSalt, StringUtil.ENCODING_TYPES encodingType)
        {
            return !string.IsNullOrWhiteSpace(tbSalt) ? StringUtil.GetEncoder(encodingType).GetBytes(tbSalt) : StringHashing.GenerateRandomSalt();
        }

        #endregion

        #region Do Activities

        public static string CalculateHash(string tbInput, string cbAlgo, string cbEncFormat, bool rbPosStartChecked, bool rbPosEndChecked, string cbEncTypes, string tbSalt, bool addSalt)
        {
            ResetBaseData();

            SetBaseData(tbInput, "Input Value", cbAlgo, cbEncFormat, rbPosStartChecked, rbPosEndChecked, cbEncTypes, tbSalt, addSalt);

            return StringHashing.ComputeHash(_plainText, _hashAlgorithm, _salt, _encryptionFormat, _encodingType, _saltPosition, _addSaltToHash);
        }

        public static void ImportFileToHash(string tbImport, string cbAlgo, string cbEncFormat, bool rbPosStartChecked, bool rbPosEndChecked, string cbEncTypes, string tbSalt, bool addSalt)
        {
            ResetBaseData();

            SetBaseData(tbImport, "Import Value", cbAlgo, cbEncFormat, rbPosStartChecked, rbPosEndChecked, cbEncTypes, tbSalt, addSalt);

            string outputFileName = SaveHashedFile(tbImport);

            MessageBox.Show(string.Format("{0} created",outputFileName));
        }

        #endregion

        

    }


}
