namespace TranslationJetBrains
{
    partial class Frm_Selected
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Selected = new System.Windows.Forms.Button();
            this.btn_Canceled = new System.Windows.Forms.Button();
            this.cmb_SoftwareList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Selected
            // 
            this.btn_Selected.Location = new System.Drawing.Point(13, 48);
            this.btn_Selected.Name = "btn_Selected";
            this.btn_Selected.Size = new System.Drawing.Size(75, 23);
            this.btn_Selected.TabIndex = 1;
            this.btn_Selected.Text = "确定";
            this.btn_Selected.UseVisualStyleBackColor = true;
            this.btn_Selected.Click += new System.EventHandler(this.btn_Selected_Click);
            // 
            // btn_Canceled
            // 
            this.btn_Canceled.Location = new System.Drawing.Point(300, 48);
            this.btn_Canceled.Name = "btn_Canceled";
            this.btn_Canceled.Size = new System.Drawing.Size(75, 23);
            this.btn_Canceled.TabIndex = 2;
            this.btn_Canceled.Text = "取消";
            this.btn_Canceled.UseVisualStyleBackColor = true;
            this.btn_Canceled.Click += new System.EventHandler(this.btn_Canceled_Click);
            // 
            // cmb_SoftwareList
            // 
            this.cmb_SoftwareList.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_SoftwareList.FormattingEnabled = true;
            this.cmb_SoftwareList.Location = new System.Drawing.Point(13, 12);
            this.cmb_SoftwareList.Name = "cmb_SoftwareList";
            this.cmb_SoftwareList.Size = new System.Drawing.Size(362, 19);
            this.cmb_SoftwareList.TabIndex = 3;
            // 
            // Selected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 81);
            this.ControlBox = false;
            this.Controls.Add(this.cmb_SoftwareList);
            this.Controls.Add(this.btn_Canceled);
            this.Controls.Add(this.btn_Selected);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Selected";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请选择目标软件";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Selected;
        private System.Windows.Forms.Button btn_Canceled;
        private System.Windows.Forms.ComboBox cmb_SoftwareList;

    }
}