using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GetCommandLine.Objects;

namespace GetCommandLine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ApplicationObj> appList = GetAPPItems();
            listBox2.Items.Clear();
            appList.ForEach(i =>
            {
                listBox2.Items.Add(i.FileName);
            });
            listBox3.Items.Clear();
            appList.ForEach(i =>
            {
                listBox3.Items.Add(i.Parameter);
            });
        }

        private List<ApplicationObj> GetAPPItems()
        {
            List<ApplicationObj> result = null;
            Regex fileRegex = new Regex(@"^.*?[.]\w{3}", RegexOptions.Singleline);
            Regex paramRegex = new Regex(@"[/].*", RegexOptions.Singleline);
            Regex msiFileRegex = new Regex(@"(?<=\/i\s).*[.]msi", RegexOptions.IgnoreCase | RegexOptions.Singleline);

            if (listBox1.Items.Count != 0)
            {
                result = new List<ApplicationObj>();
                foreach (var item in listBox1.Items)
                {
                    Match fileNameMatch = fileRegex.Match(item.ToString());
                    if (fileNameMatch.Success)
                    {
                        bool msiFlag = false;
                        string fileName = fileNameMatch.Value;
                        string parameter = string.Empty;
                        Match paramMatch = paramRegex.Match(item.ToString());

                        if ("msiexec.exe".Equals(fileNameMatch.Value, StringComparison.InvariantCultureIgnoreCase))
                        {
                            fileNameMatch = msiFileRegex.Match(item.ToString());
                            if (fileNameMatch.Success)
                            {
                                fileName = fileNameMatch.Value;
                            }
                            msiFlag = true;
                        }

                        if (paramMatch.Success)
                        {
                            parameter = paramMatch.Value;
                        }

                        result.Add(new ApplicationObj()
                        {
                            FileName = fileName,
                            IsMSIPackage = msiFlag,
                            Parameter = parameter,
                            IsEnable = true
                        });
                    }
                }
            }

            return result;
        }
    }
}
