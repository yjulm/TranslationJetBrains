namespace TranslationJetBrains
{
    partial class Frm_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dlg_FileOpen = new System.Windows.Forms.OpenFileDialog();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.txt_OpenTxt = new System.Windows.Forms.RichTextBox();
            this.btn_trans = new System.Windows.Forms.Button();
            this.btn_SaveFile = new System.Windows.Forms.Button();
            this.pgb_fileProgress = new System.Windows.Forms.ProgressBar();
            this.pgb_lineProgress = new System.Windows.Forms.ProgressBar();
            this.lb_totalProgress = new System.Windows.Forms.Label();
            this.lb_localProgress = new System.Windows.Forms.Label();
            this.cmb_trasnType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dlg_FileOpen
            // 
            this.dlg_FileOpen.FileName = "openFileDialog1";
            // 
            // txt_FileName
            // 
            this.txt_FileName.BackColor = System.Drawing.SystemColors.Control;
            this.txt_FileName.Location = new System.Drawing.Point(13, 13);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.ReadOnly = true;
            this.txt_FileName.Size = new System.Drawing.Size(551, 21);
            this.txt_FileName.TabIndex = 0;
            this.txt_FileName.WordWrap = false;
            // 
            // btn_openFile
            // 
            this.btn_openFile.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_openFile.Location = new System.Drawing.Point(570, 12);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(75, 23);
            this.btn_openFile.TabIndex = 1;
            this.btn_openFile.Text = "解压";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // txt_OpenTxt
            // 
            this.txt_OpenTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_OpenTxt.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_OpenTxt.Location = new System.Drawing.Point(12, 50);
            this.txt_OpenTxt.Name = "txt_OpenTxt";
            this.txt_OpenTxt.ReadOnly = true;
            this.txt_OpenTxt.Size = new System.Drawing.Size(633, 119);
            this.txt_OpenTxt.TabIndex = 2;
            this.txt_OpenTxt.Text = "\n\t此软件适用于 IntelliJ IDEA、PhpStorm、WebStorm、PyCharm、RubyMine 等JetBrains系列软件\n\t如果自动查找失" +
    "败，请点击解压按钮找到安装目录lib文件夹下的 resources_en.jar 文件\n\t点击翻译，等待汉化完毕！！！";
            this.txt_OpenTxt.WordWrap = false;
            // 
            // btn_trans
            // 
            this.btn_trans.Enabled = false;
            this.btn_trans.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_trans.Location = new System.Drawing.Point(489, 231);
            this.btn_trans.Name = "btn_trans";
            this.btn_trans.Size = new System.Drawing.Size(75, 23);
            this.btn_trans.TabIndex = 4;
            this.btn_trans.Text = "翻译";
            this.btn_trans.UseVisualStyleBackColor = true;
            this.btn_trans.Click += new System.EventHandler(this.btn_trans_Click);
            // 
            // btn_SaveFile
            // 
            this.btn_SaveFile.Enabled = false;
            this.btn_SaveFile.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SaveFile.Location = new System.Drawing.Point(570, 231);
            this.btn_SaveFile.Name = "btn_SaveFile";
            this.btn_SaveFile.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveFile.TabIndex = 5;
            this.btn_SaveFile.Text = "保存";
            this.btn_SaveFile.UseVisualStyleBackColor = true;
            this.btn_SaveFile.Click += new System.EventHandler(this.btn_SaveFile_Click);
            // 
            // pgb_fileProgress
            // 
            this.pgb_fileProgress.Location = new System.Drawing.Point(84, 204);
            this.pgb_fileProgress.Name = "pgb_fileProgress";
            this.pgb_fileProgress.Size = new System.Drawing.Size(561, 21);
            this.pgb_fileProgress.TabIndex = 6;
            // 
            // pgb_lineProgress
            // 
            this.pgb_lineProgress.Location = new System.Drawing.Point(84, 175);
            this.pgb_lineProgress.Name = "pgb_lineProgress";
            this.pgb_lineProgress.Size = new System.Drawing.Size(561, 23);
            this.pgb_lineProgress.TabIndex = 7;
            // 
            // lb_totalProgress
            // 
            this.lb_totalProgress.AutoSize = true;
            this.lb_totalProgress.Location = new System.Drawing.Point(11, 181);
            this.lb_totalProgress.Name = "lb_totalProgress";
            this.lb_totalProgress.Size = new System.Drawing.Size(65, 12);
            this.lb_totalProgress.TabIndex = 8;
            this.lb_totalProgress.Text = "当前进度：";
            // 
            // lb_localProgress
            // 
            this.lb_localProgress.AutoSize = true;
            this.lb_localProgress.Location = new System.Drawing.Point(11, 208);
            this.lb_localProgress.Name = "lb_localProgress";
            this.lb_localProgress.Size = new System.Drawing.Size(65, 12);
            this.lb_localProgress.TabIndex = 9;
            this.lb_localProgress.Text = "完整进度：";
            // 
            // cmb_trasnType
            // 
            this.cmb_trasnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_trasnType.FormattingEnabled = true;
            this.cmb_trasnType.Items.AddRange(new object[] {
            "Google",
            "Baidu"});
            this.cmb_trasnType.Location = new System.Drawing.Point(84, 231);
            this.cmb_trasnType.Name = "cmb_trasnType";
            this.cmb_trasnType.Size = new System.Drawing.Size(121, 20);
            this.cmb_trasnType.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "翻译方式：";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 264);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_trasnType);
            this.Controls.Add(this.lb_localProgress);
            this.Controls.Add(this.lb_totalProgress);
            this.Controls.Add(this.pgb_lineProgress);
            this.Controls.Add(this.pgb_fileProgress);
            this.Controls.Add(this.btn_SaveFile);
            this.Controls.Add(this.btn_trans);
            this.Controls.Add(this.txt_OpenTxt);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.txt_FileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JetBrains Translate";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlg_FileOpen;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Button btn_openFile;
        private System.Windows.Forms.RichTextBox txt_OpenTxt;
        private System.Windows.Forms.Button btn_trans;
        private System.Windows.Forms.Button btn_SaveFile;
        private System.Windows.Forms.ProgressBar pgb_fileProgress;
        private System.Windows.Forms.ProgressBar pgb_lineProgress;
        private System.Windows.Forms.Label lb_totalProgress;
        private System.Windows.Forms.Label lb_localProgress;
        private System.Windows.Forms.ComboBox cmb_trasnType;
        private System.Windows.Forms.Label label1;
    }
}

