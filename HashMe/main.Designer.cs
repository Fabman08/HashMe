namespace com.prjteam.HashMe
{
    partial class Main
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cbAlgo = new System.Windows.Forms.ComboBox();
            this.lblSalt = new System.Windows.Forms.Label();
            this.tbSalt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbEncFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbPosStart = new System.Windows.Forms.RadioButton();
            this.rbPosEnd = new System.Windows.Forms.RadioButton();
            this.cbEncTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxInput = new System.Windows.Forms.GroupBox();
            this.chAdd = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTemplate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxOutput = new System.Windows.Forms.GroupBox();
            this.btnSaveTmpl = new System.Windows.Forms.Button();
            this.groupBoxTemplate = new System.Windows.Forms.GroupBox();
            this.btnChew = new System.Windows.Forms.Button();
            this.btnDelTempl = new System.Windows.Forms.Button();
            this.btnEditTmpl = new System.Windows.Forms.Button();
            this.groupBoxImport = new System.Windows.Forms.GroupBox();
            this.btExport = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbImport = new System.Windows.Forms.TextBox();
            this.groupBoxInput.SuspendLayout();
            this.groupBoxOutput.SuspendLayout();
            this.groupBoxTemplate.SuspendLayout();
            this.groupBoxImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(103, 29);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(203, 20);
            this.tbInput.TabIndex = 2;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(62, 33);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(37, 13);
            this.lblInput.TabIndex = 1;
            this.lblInput.Text = "Value:";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(92, 19);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(94, 23);
            this.btnCalculate.TabIndex = 10;
            this.btnCalculate.Text = "Hash Now";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculateClick);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(388, 19);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(94, 23);
            this.btnClean.TabIndex = 11;
            this.btnClean.Text = "Clean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.BtnCleanClick);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(219, 45);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(134, 23);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(6, 87);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(566, 60);
            this.lblResult.TabIndex = 9;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(365, 33);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(53, 13);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Algorithm:";
            // 
            // cbAlgo
            // 
            this.cbAlgo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbAlgo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAlgo.FormattingEnabled = true;
            this.cbAlgo.Location = new System.Drawing.Point(424, 29);
            this.cbAlgo.Name = "cbAlgo";
            this.cbAlgo.Size = new System.Drawing.Size(121, 21);
            this.cbAlgo.TabIndex = 3;
            this.cbAlgo.SelectedIndexChanged += new System.EventHandler(this.CbAlgoSelectedIndexChanged);
            // 
            // lblSalt
            // 
            this.lblSalt.AutoSize = true;
            this.lblSalt.Location = new System.Drawing.Point(71, 59);
            this.lblSalt.Name = "lblSalt";
            this.lblSalt.Size = new System.Drawing.Size(28, 13);
            this.lblSalt.TabIndex = 12;
            this.lblSalt.Text = "Salt:";
            // 
            // tbSalt
            // 
            this.tbSalt.Location = new System.Drawing.Point(103, 56);
            this.tbSalt.Name = "tbSalt";
            this.tbSalt.Size = new System.Drawing.Size(203, 20);
            this.tbSalt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Encryption format:";
            // 
            // cbEncFormat
            // 
            this.cbEncFormat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbEncFormat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEncFormat.FormattingEnabled = true;
            this.cbEncFormat.Location = new System.Drawing.Point(424, 56);
            this.cbEncFormat.Name = "cbEncFormat";
            this.cbEncFormat.Size = new System.Drawing.Size(121, 21);
            this.cbEncFormat.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Salt position:";
            // 
            // rbPosStart
            // 
            this.rbPosStart.AutoSize = true;
            this.rbPosStart.Location = new System.Drawing.Point(103, 86);
            this.rbPosStart.Name = "rbPosStart";
            this.rbPosStart.Size = new System.Drawing.Size(51, 17);
            this.rbPosStart.TabIndex = 6;
            this.rbPosStart.TabStop = true;
            this.rbPosStart.Text = "Head";
            this.rbPosStart.UseVisualStyleBackColor = true;
            // 
            // rbPosEnd
            // 
            this.rbPosEnd.AutoSize = true;
            this.rbPosEnd.Location = new System.Drawing.Point(184, 86);
            this.rbPosEnd.Name = "rbPosEnd";
            this.rbPosEnd.Size = new System.Drawing.Size(42, 17);
            this.rbPosEnd.TabIndex = 7;
            this.rbPosEnd.TabStop = true;
            this.rbPosEnd.Text = "Tail";
            this.rbPosEnd.UseVisualStyleBackColor = true;
            // 
            // cbEncTypes
            // 
            this.cbEncTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbEncTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbEncTypes.FormattingEnabled = true;
            this.cbEncTypes.Location = new System.Drawing.Point(424, 83);
            this.cbEncTypes.Name = "cbEncTypes";
            this.cbEncTypes.Size = new System.Drawing.Size(121, 21);
            this.cbEncTypes.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Encoding types:";
            // 
            // groupBoxInput
            // 
            this.groupBoxInput.Controls.Add(this.chAdd);
            this.groupBoxInput.Controls.Add(this.label4);
            this.groupBoxInput.Controls.Add(this.tbInput);
            this.groupBoxInput.Controls.Add(this.label3);
            this.groupBoxInput.Controls.Add(this.label1);
            this.groupBoxInput.Controls.Add(this.lblInput);
            this.groupBoxInput.Controls.Add(this.cbEncFormat);
            this.groupBoxInput.Controls.Add(this.cbEncTypes);
            this.groupBoxInput.Controls.Add(this.tbSalt);
            this.groupBoxInput.Controls.Add(this.lblType);
            this.groupBoxInput.Controls.Add(this.label2);
            this.groupBoxInput.Controls.Add(this.rbPosEnd);
            this.groupBoxInput.Controls.Add(this.lblSalt);
            this.groupBoxInput.Controls.Add(this.cbAlgo);
            this.groupBoxInput.Controls.Add(this.rbPosStart);
            this.groupBoxInput.Location = new System.Drawing.Point(12, 140);
            this.groupBoxInput.Name = "groupBoxInput";
            this.groupBoxInput.Size = new System.Drawing.Size(578, 140);
            this.groupBoxInput.TabIndex = 22;
            this.groupBoxInput.TabStop = false;
            this.groupBoxInput.Text = "Input";
            // 
            // chAdd
            // 
            this.chAdd.AutoSize = true;
            this.chAdd.Location = new System.Drawing.Point(103, 109);
            this.chAdd.Name = "chAdd";
            this.chAdd.Size = new System.Drawing.Size(72, 17);
            this.chAdd.TabIndex = 9;
            this.chAdd.Text = "Of course";
            this.chAdd.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Add salt to hash:";
            // 
            // cbTemplate
            // 
            this.cbTemplate.FormattingEnabled = true;
            this.cbTemplate.Location = new System.Drawing.Point(97, 30);
            this.cbTemplate.Name = "cbTemplate";
            this.cbTemplate.Size = new System.Drawing.Size(121, 21);
            this.cbTemplate.TabIndex = 1;
            this.cbTemplate.SelectedIndexChanged += new System.EventHandler(this.CbTemplateSelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Load Template:";
            // 
            // groupBoxOutput
            // 
            this.groupBoxOutput.Controls.Add(this.btnClean);
            this.groupBoxOutput.Controls.Add(this.btnCopy);
            this.groupBoxOutput.Controls.Add(this.btnCalculate);
            this.groupBoxOutput.Controls.Add(this.lblResult);
            this.groupBoxOutput.Location = new System.Drawing.Point(12, 286);
            this.groupBoxOutput.Name = "groupBoxOutput";
            this.groupBoxOutput.Size = new System.Drawing.Size(578, 162);
            this.groupBoxOutput.TabIndex = 23;
            this.groupBoxOutput.TabStop = false;
            this.groupBoxOutput.Text = "Output";
            // 
            // btnSaveTmpl
            // 
            this.btnSaveTmpl.Location = new System.Drawing.Point(368, 19);
            this.btnSaveTmpl.Name = "btnSaveTmpl";
            this.btnSaveTmpl.Size = new System.Drawing.Size(134, 23);
            this.btnSaveTmpl.TabIndex = 13;
            this.btnSaveTmpl.Text = "Save Template";
            this.btnSaveTmpl.UseVisualStyleBackColor = true;
            this.btnSaveTmpl.Click += new System.EventHandler(this.BtnSaveTmplClick);
            // 
            // groupBoxTemplate
            // 
            this.groupBoxTemplate.Controls.Add(this.btnChew);
            this.groupBoxTemplate.Controls.Add(this.btnDelTempl);
            this.groupBoxTemplate.Controls.Add(this.btnEditTmpl);
            this.groupBoxTemplate.Controls.Add(this.btnSaveTmpl);
            this.groupBoxTemplate.Controls.Add(this.cbTemplate);
            this.groupBoxTemplate.Controls.Add(this.label5);
            this.groupBoxTemplate.Location = new System.Drawing.Point(12, 13);
            this.groupBoxTemplate.Name = "groupBoxTemplate";
            this.groupBoxTemplate.Size = new System.Drawing.Size(578, 110);
            this.groupBoxTemplate.TabIndex = 25;
            this.groupBoxTemplate.TabStop = false;
            this.groupBoxTemplate.Text = "Template";
            // 
            // btnChew
            // 
            this.btnChew.Cursor = System.Windows.Forms.Cursors.No;
            this.btnChew.Image = ((System.Drawing.Image)(resources.GetObject("btnChew.Image")));
            this.btnChew.Location = new System.Drawing.Point(16, 60);
            this.btnChew.Name = "btnChew";
            this.btnChew.Size = new System.Drawing.Size(40, 44);
            this.btnChew.TabIndex = 25;
            this.btnChew.UseVisualStyleBackColor = true;
            this.btnChew.Click += new System.EventHandler(this.BtnChewClick);
            // 
            // btnDelTempl
            // 
            this.btnDelTempl.Enabled = false;
            this.btnDelTempl.Location = new System.Drawing.Point(368, 78);
            this.btnDelTempl.Name = "btnDelTempl";
            this.btnDelTempl.Size = new System.Drawing.Size(134, 23);
            this.btnDelTempl.TabIndex = 24;
            this.btnDelTempl.Text = "Delete Template";
            this.btnDelTempl.UseVisualStyleBackColor = true;
            this.btnDelTempl.Click += new System.EventHandler(this.BtnDelTemplClick);
            // 
            // btnEditTmpl
            // 
            this.btnEditTmpl.Enabled = false;
            this.btnEditTmpl.Location = new System.Drawing.Point(368, 48);
            this.btnEditTmpl.Name = "btnEditTmpl";
            this.btnEditTmpl.Size = new System.Drawing.Size(134, 23);
            this.btnEditTmpl.TabIndex = 23;
            this.btnEditTmpl.Text = "Edit Template";
            this.btnEditTmpl.UseVisualStyleBackColor = true;
            this.btnEditTmpl.Click += new System.EventHandler(this.BtnEditTmplClick);
            // 
            // groupBoxImport
            // 
            this.groupBoxImport.Controls.Add(this.btExport);
            this.groupBoxImport.Controls.Add(this.btnBrowse);
            this.groupBoxImport.Controls.Add(this.tbImport);
            this.groupBoxImport.Location = new System.Drawing.Point(12, 454);
            this.groupBoxImport.Name = "groupBoxImport";
            this.groupBoxImport.Size = new System.Drawing.Size(578, 64);
            this.groupBoxImport.TabIndex = 26;
            this.groupBoxImport.TabStop = false;
            this.groupBoxImport.Text = "Import-Export";
            // 
            // btExport
            // 
            this.btExport.Location = new System.Drawing.Point(447, 23);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(75, 23);
            this.btExport.TabIndex = 2;
            this.btExport.Text = "Export";
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.BtExportClick);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(317, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowseClick);
            // 
            // tbImport
            // 
            this.tbImport.Enabled = false;
            this.tbImport.Location = new System.Drawing.Point(16, 23);
            this.tbImport.Name = "tbImport";
            this.tbImport.Size = new System.Drawing.Size(270, 20);
            this.tbImport.TabIndex = 0;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 533);
            this.Controls.Add(this.groupBoxImport);
            this.Controls.Add(this.groupBoxTemplate);
            this.Controls.Add(this.groupBoxOutput);
            this.Controls.Add(this.groupBoxInput);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hash Me!";
            this.groupBoxInput.ResumeLayout(false);
            this.groupBoxInput.PerformLayout();
            this.groupBoxOutput.ResumeLayout(false);
            this.groupBoxTemplate.ResumeLayout(false);
            this.groupBoxTemplate.PerformLayout();
            this.groupBoxImport.ResumeLayout(false);
            this.groupBoxImport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbAlgo;
        private System.Windows.Forms.Label lblSalt;
        private System.Windows.Forms.TextBox tbSalt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbEncFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbPosStart;
        private System.Windows.Forms.RadioButton rbPosEnd;
        private System.Windows.Forms.ComboBox cbEncTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxOutput;
        private System.Windows.Forms.CheckBox chAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTemplate;
        private System.Windows.Forms.Button btnSaveTmpl;
        private System.Windows.Forms.GroupBox groupBoxTemplate;
        private System.Windows.Forms.Button btnEditTmpl;
        private System.Windows.Forms.Button btnDelTempl;
        private System.Windows.Forms.Button btnChew;
        private System.Windows.Forms.GroupBox groupBoxImport;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbImport;
        private System.Windows.Forms.Button btExport;       
    }
}

