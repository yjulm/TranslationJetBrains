using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TranslationJetBrains
{
    public partial class Frm_Selected : Form
    {
        private List<SoftwareInfo> softwareList;

        public event EventHandler SelectedOver;

        internal Frm_Selected(List<SoftwareInfo> list)
        {
            InitializeComponent();      // 初始化页面控件

            softwareList = list;
            list.ForEach((x) =>
            {
                cmb_SoftwareList.Items.Add(x.displayName);
            });
            cmb_SoftwareList.SelectedItem = cmb_SoftwareList.Items[0];
        }

        private void btn_Selected_Click(object sender, EventArgs e)
        {
            string softwareName = cmb_SoftwareList.Text as string;
            if (!SelectedOver.IsNullOrEmptyOrSpace())
            {
                string path = softwareList.First((x) => { return x.displayName == softwareName; }).installLocation;
                SelectedOver(path, EventArgs.Empty);       // 利用事件将选择的路径传入主页面
            }
            this.Close();
        }

        private void btn_Canceled_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}