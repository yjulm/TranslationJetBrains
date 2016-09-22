using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranslationJetBrains
{
    public partial class Frm_Main : Form
    {
        private string[] fileList { get; set; }
        private string tempPath { get; set; }
        private string rootPath { get; set; }

        public Frm_Main()
        {
            InitializeComponent();
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            List<SoftwareInfo> list = await Task.Factory.StartNew<List<SoftwareInfo>>(Software.GetInstallSoftwareInfo);
            if (list.Count > 0)
            {
                Frm_Selected frm = new Frm_Selected(list);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.SelectedOver += frm_SelectedOver;
                frm.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("没有发现目标软件，请手动选择安装目录lib文件夹下的 resources_en.jar 文件。是否继续？", "是否继续?", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.OK)
                {
                    btn_openFile_Click(null, null);
                }
            }

            cmb_trasnType.SelectedItem = cmb_trasnType.Items[0];
        }

        /// <summary>
        /// 得到选择的安装路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void frm_SelectedOver(object sender, EventArgs e)
        {
            string installPath = sender as string;
            txt_FileName.Text = installPath;
            await ExtractFile(installPath);

            btn_openFile.Enabled = false;
            btn_trans.Enabled = true;
            txt_OpenTxt.Clear();
            foreach (string s in fileList)
            {
                txt_OpenTxt.AppendText(s + "\n");
            }
        }

        private async void btn_openFile_Click(object sender, EventArgs e)
        {
            dlg_FileOpen.Filter = "Jar|resources_en.jar";
            dlg_FileOpen.Multiselect = false;
            dlg_FileOpen.FileName = null;
            dlg_FileOpen.Title = "打开";

            if (dlg_FileOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txt_FileName.Text = dlg_FileOpen.FileName;
                await ExtractFile(dlg_FileOpen.FileName);

                btn_openFile.Enabled = false;
                btn_trans.Enabled = true;
                txt_OpenTxt.Clear();
                foreach (string s in fileList)
                {
                    txt_OpenTxt.AppendText(s + "\n");
                }
            }
        }

        private async void btn_trans_Click(object sender, EventArgs e)
        {
            txt_OpenTxt.Clear();
            translateType trasnType = cmb_trasnType.Text == "Google" ? translateType.Google : translateType.Baidu;

            string[] carList = { @"\n", "@", "$", "=", "\"", "{", "}", "(", ")", "'", ":", "_", "?", "!", "<", ">", "|", "&", ":", @"\", "+", "-", "*", "/", "%" };
            int charNum = 0;
            int num = -1;
            string subStr = string.Empty;
            string chars = string.Empty;
            string str = string.Empty;
            string[] lines;
            List<string> newLines;
            string mesFileName = string.Empty;

            btn_trans.Enabled = false;
            btn_SaveFile.Enabled = false;
            btn_openFile.Enabled = false;

            this.ActiveControl = txt_OpenTxt;       // 设定活动控件（给予焦点）
            pgb_fileProgress.Maximum = fileList.Length;
            pgb_fileProgress.Value = 0;

            foreach (string file in fileList)       //迭代文件列表
            {
                txt_OpenTxt.Clear();

                newLines = new List<string>();      //新的内容行数组
                mesFileName = new FileInfo(file).Name;   //取得当前的文件名称
                lines = File.ReadAllLines(file);       //将文件内容分行读入数组

                if (lines.Length == 0) break;

                pgb_lineProgress.Maximum = lines.Length;
                pgb_lineProgress.Value = 0;
                foreach (string line in lines)      //迭代分行内容数组
                {
                    charNum = 0;

                    num = line.IndexOf("=");
                    if (num >= 0)  //有等号
                    {
                        subStr = line.Substring(num + 1);  //取得等号后有效部分
                        foreach (string s in carList)  //迭代特殊符号数组
                        {
                            if (subStr.IndexOf(s) >= 0)
                            {
                                charNum += 1;    //记录特殊符号的个数
                                chars = s;   //记住符号
                            }
                        }
                        try
                        {
                            if (charNum > 0)   //有特殊符号
                            {
                                if (charNum == 1)
                                {
                                    switch (chars)
                                    {
                                        case "_":
                                            str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr.Replace("_", ""), trasnType) + "\n";
                                            break;

                                        case @"\n":
                                            str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr.Replace(@"\n", " "), trasnType) + "\n";
                                            break;

                                        case ":":
                                            str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr, trasnType) + "\n";
                                            break;

                                        case "&":
                                            str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr, trasnType) + "\n";
                                            break;

                                        case "/":
                                            str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr, trasnType) + "\n";
                                            break;

                                        case "-":
                                            str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr, trasnType) + "\n";
                                            break;

                                        case "?":
                                            str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr, trasnType) + "\n";
                                            break;

                                        case "'":
                                            str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr, trasnType) + "\n";
                                            break;

                                        default:
                                            str = line;
                                            break;
                                    }
                                    newLines.Add(str);
                                    txt_OpenTxt.AppendText(str);
                                    continue;
                                }

                                newLines.Add(line);  //如果存在其他或者多个特殊符号不执行翻译直接写入数组
                                txt_OpenTxt.AppendText(line + "\n");
                                continue;
                            }
                            else   //没有特殊符号，翻译后拼接行
                            {
                                str = line.Substring(0, num + 1) + await Translation.BeginTranslationAsync(subStr, trasnType) + "\n";
                                newLines.Add(str);
                                txt_OpenTxt.AppendText(str);
                            }
                        }
                        catch (System.Net.WebException ex)
                        {
                            MessageBox.Show(ex.Message);
                            btn_trans.Enabled = true;
                            return;
                        }
                    }
                    else        //如果没有等号直接写入数组
                    {
                        newLines.Add(line);
                        txt_OpenTxt.AppendText(line + "\n");
                    }

                    pgb_lineProgress.Value += 1;
                }
                pgb_fileProgress.Value += 1;
                //当迭代完成后保存文本到新文件

                string savePath = rootPath + @"\JetBrainsTransMesTmp\messages\";
                if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);  //重建新的messages目录
                if (File.Exists(savePath + mesFileName)) File.Delete(savePath + mesFileName);
                File.WriteAllLines(savePath + mesFileName, newLines, Encoding.UTF8);//将翻译后的所有文本写入到文件;
            }

            btn_openFile.Enabled = true;
            btn_SaveFile.Enabled = true;
        }

        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            //if (!File.Exists(rootPath + @"\resources_en.jar.bak")) new FileInfo(rootPath + @"\resources_en.jar").CopyTo(rootPath + @"\resources_en.jar.bak");
            new DirectoryInfo(rootPath + @"\JetBrainsTrasnTemp\messages\").Delete(true);
            Directory.Move(rootPath + @"\JetBrainsTransMesTmp\messages\", rootPath + @"\JetBrainsTrasnTemp\messages\");
            ZipTool.Compress(rootPath + @"\JetBrainsTrasnTemp\", rootPath + @"\resources_cn.jar");
            new DirectoryInfo(rootPath + @"\JetBrainsTrasnTemp").Delete(true);
            new DirectoryInfo(rootPath + @"\JetBrainsTransMesTmp").Delete(true);
            if (MessageBox.Show("汉化完毕！") == System.Windows.Forms.DialogResult.OK) Application.Exit();
        }

        /// <summary>
        /// 解压文件并得到文件列表
        /// </summary>
        /// <param name="fromPath"></param>
        /// <returns></returns>
        private async Task ExtractFile(string fromPath)
        {
            if (!fromPath.IsNullOrEmptyOrSpace())
            {
                rootPath = Path.GetDirectoryName(fromPath);         //取得根目录
                tempPath = rootPath + @"\JetBrainsTrasnTemp\";           //缓存处理目录
                if (Directory.Exists(tempPath)) Directory.Delete(tempPath, true);
                Directory.CreateDirectory(tempPath);   //创建一个目录

                await Task.Run(() =>            // 等待解压文件完成
                {
                    ZipTool.Extract(fromPath, tempPath);
                });

                fileList = Directory.GetFiles(tempPath + @"messages\");     //取得目录下所有文件的文件名
            }
        }
    }
}