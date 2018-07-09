using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using com.prjteam.HashMe.DTO;
using com.prjteam.HashMe.Exc;
using com.prjteam.HashMe.Properties;
using com.prjteam.HashUtil;

namespace com.prjteam.HashMe
{
	public partial class Main : Form
	{        
		private List<DtoTemplate> _templList;
	    readonly Assembly _assembly = Assembly.GetExecutingAssembly();

		public Main()
		{
			InitializeComponent();
			InitToolTip();
            InitTemplate();
			InitComboBox();
		}

		private void InitToolTip()
		{
			ToolTip ttC = new ToolTip();
			ttC.SetToolTip(btnChew, "Chewie!");
			ttC.AutomaticDelay = 100;                        
		}

		private void InitTemplate()
		{			
			cbTemplate.Items.Clear();
			_templList = Program.LoadTemplate();
			foreach (DtoTemplate dtoTmpl in _templList)
				cbTemplate.Items.Insert(dtoTmpl.Index, dtoTmpl.Name);			
		}
		
		private void InitComboBox()
		{

			try
			{
                Program.GetEnumList(cbEncFormat, typeof(StringUtil.ENCRYPTION_FORMAT));
                Program.GetEnumList(cbEncTypes, typeof(StringUtil.ENCODING_TYPES));
                Program.GetEnumList(cbAlgo, typeof(StringUtil.HASH_ALGORITHM));								
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);                
			}
		}        

		private void BtnCalculateClick(object sender, EventArgs e)
		{
			          						
            try
            {
                lblResult.Text = Program.CalculateHash(tbInput.Text, cbAlgo.Text, cbEncFormat.Text, rbPosStart.Checked, rbPosEnd.Checked, cbEncTypes.Text, tbSalt.Text,chAdd.Checked);
               
                btnCopy.Enabled = true;

            }
            catch (GenericFieldException ufex)
            {
                MessageBox.Show(ufex.CustomMessage, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}

		private void BtnCleanClick(object sender, EventArgs e)
		{
			try
			{                
				lblResult.Text = string.Empty;
				tbInput.Text = string.Empty;
				tbSalt.Text = string.Empty;
				cbAlgo.Text = string.Empty;
				cbEncFormat.Text = string.Empty;
				cbEncTypes.Text = string.Empty;
				rbPosEnd.Checked = false;
				rbPosStart.Checked = false;
				cbTemplate.Text = string.Empty;
				chAdd.Checked = false;

				tbSalt.Enabled = true;
				cbAlgo.Enabled = true;
				cbEncFormat.Enabled = true;
				cbEncTypes.Enabled = true;
				rbPosEnd.Enabled = true;
				rbPosStart.Enabled = true;
				chAdd.Enabled = true;
				btnCopy.Enabled = false;

				btnEditTmpl.Enabled = false;
				btnDelTempl.Enabled = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}            
		}

		private void BtnCopyClick(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetText(lblResult.Text);

				MessageBox.Show(Resources.Main_BtnCopyClick_Copied_to_the_Clipboard, Resources.Main_BtnCopyClick_Copied, MessageBoxButtons.OK, MessageBoxIcon.Information);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void CbTemplateSelectedIndexChanged(object sender, EventArgs e)
		{
		    try 
			{	        
				DtoTemplate tmplSelected = _templList.ElementAt(cbTemplate.SelectedIndex);

				cbAlgo.Text = tmplSelected.HashAlgorithm.ToString();
				tbSalt.Text = tmplSelected.Salt;
				cbEncFormat.Text = tmplSelected.EncryptionFormat.ToString();
				
				if (tmplSelected.SaltPosition == StringUtil.SALT_POSITION.Head)                                    
				{
					rbPosEnd.Checked = false;
					rbPosStart.Checked = true;
				}
				else
				{
					rbPosEnd.Checked = true;
					rbPosStart.Checked = false;
				}

				cbEncTypes.Text = tmplSelected.EncodingType.ToString();
				chAdd.Checked = tmplSelected.SaltToHash;
				
				cbAlgo.Enabled = tmplSelected.Editable;
				tbSalt.Enabled = tmplSelected.Editable;
				cbEncFormat.Enabled = tmplSelected.Editable;
				rbPosStart.Enabled = tmplSelected.Editable;
				rbPosEnd.Enabled = tmplSelected.Editable;
				cbEncTypes.Enabled = tmplSelected.Editable;
				chAdd.Enabled = tmplSelected.Editable;
				btnEditTmpl.Enabled = true;
				btnDelTempl.Enabled = true;
																						
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}            
		}

		private void BtnSaveTmplClick(object sender, EventArgs e)
		{
		    try
			{
                Program.SaveTemplate(cbTemplate.Items.Count, cbTemplate.SelectedIndex, cbTemplate.Text,cbAlgo.Text,cbEncFormat.Text,rbPosStart.Checked,rbPosEnd.Checked,cbEncTypes.Text,tbSalt.Text,chAdd.Checked);
                
				int currentTemplate = (cbTemplate.SelectedIndex == -1 ? cbTemplate.Items.Count : cbTemplate.SelectedIndex);
				InitTemplate();
				cbTemplate.SelectedIndex = currentTemplate;
			}
            catch (GenericFieldException ufex)
            {
                MessageBox.Show(ufex.CustomMessage, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnEditTmplClick(object sender, EventArgs e)
		{
			tbSalt.Enabled = true;
			cbAlgo.Enabled = true;
			cbEncFormat.Enabled = true;
			cbEncTypes.Enabled = true;
			rbPosEnd.Enabled = true;
			rbPosStart.Enabled = true;
			chAdd.Enabled = true;            
		}

		private void BtnDelTemplClick(object sender, EventArgs e)
		{                        
			if (cbTemplate.SelectedIndex == -1)
			{
				MessageBox.Show(Resources.Main_BtnDelTemplClick_No_template_selected_, Resources.Main_BtnDelTemplClick_Delete, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult res = MessageBox.Show(Resources.Main_BtnDelTemplClick_Do_you_want_to_delete_this_Template, Resources.Main_BtnDelTemplClick_Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (res.Equals(DialogResult.Yes))
			{
				Program.DeleteTemplate(cbTemplate.SelectedIndex);
				InitTemplate();
				BtnCleanClick(null, null);
			}            
		}       

		private void BtnChewClick(object sender, EventArgs e)
		{           
			try
			{                
				Stream s = _assembly.GetManifestResourceStream("com.prjteam.HashMe.Media.CHEWIE1.wav");
				SoundPlayer player = new SoundPlayer(s);
				player.Play();            
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}            
		}		

        private void CbAlgoSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringUtil.HASH_ALGORITHM hashAlg;
                Enum.TryParse(cbAlgo.Text, out hashAlg);
                                
                if (hashAlg == StringUtil.HASH_ALGORITHM.Md5)
                {
                    tbSalt.Enabled = false;
                    rbPosStart.Enabled = false;
                    rbPosEnd.Enabled = false;
                    chAdd.Enabled = false;
                    cbEncFormat.Enabled = false;
                    cbEncTypes.Enabled = false;
                }
                else
                {
                    tbSalt.Enabled = true;
                    rbPosStart.Enabled = true;
                    rbPosEnd.Enabled = true;
                    chAdd.Enabled = true;
                    cbEncFormat.Enabled = true;
                    cbEncTypes.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void BtnBrowseClick(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = Resources.Main_BtnBrowseClick_Select_text_file;
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = Resources.Main_BtnBrowseClick_txt_files____txt____txt_csv_files____csv____csv;
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                tbImport.Text = fdlg.FileName;
            }
        }

        private void BtExportClick(object sender, EventArgs e)
        {
            
            try
            {

                Program.ImportFileToHash(tbImport.Text, cbAlgo.Text, cbEncFormat.Text, rbPosStart.Checked, rbPosEnd.Checked, cbEncTypes.Text, tbSalt.Text, chAdd.Checked);
                                                                                
            }
                catch (GenericFieldException ufex)
            {
                MessageBox.Show(ufex.CustomMessage, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Main_InitComboBox_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		
	}
}