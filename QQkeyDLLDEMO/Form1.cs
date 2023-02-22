using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QQkeyDLLDEMO
{
    public partial class Form1 : Form
    {

        string DLLpath = Path.Combine(Application.StartupPath, @"BigJB.dll");
        public Form1()
        {
            if (!File.Exists(DLLpath))
            {
                File.WriteAllBytes(DLLpath, Properties.Resources.QQkeyDll);
            }
            InitializeComponent();
        }
        [DllImport("BigJB.dll", EntryPoint = "GetClientUin")]
        static extern string GetClientUin(int pid);
        [DllImport("BigJB.dll", EntryPoint = "GetCookies")]
        static extern string GetCookies(int qqnum, string qqkey);
        [DllImport("BigJB.dll", EntryPoint = "GetClientKey")]
        static extern string GetClientKey(int pid);
        [DllImport("BigJB.dll", EntryPoint = "GetClientName")]
        static extern string GetClientName(long qqnum, int pid);
        [DllImport("BigJB.dll", EntryPoint = "GetHttpKey")]
        static extern string GetHttpKey(int pid);
        public static int GetTIMpid()
        {
            if (System.Diagnostics.Process.GetProcessesByName("QQ").ToList().Count > 0)
            {
                Process[] all = Process.GetProcessesByName("QQ");
                int pid = all[0].Id;
                return pid;
            }
            else
            {
                if (System.Diagnostics.Process.GetProcessesByName("TIM").ToList().Count > 0)
                {
                    Process[] all = Process.GetProcessesByName("TIM");
                    int pid = all[0].Id;
                    return pid;
                }
                else
                {
                    int pid = -1;
                    return pid;
                    MessageBox.Show("未开启QQ或TIM");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("By sysR@M\n QQ号:"+GetClientUin(7072)+" QQ名:"+GetClientName(Convert.ToInt32(GetClientUin(7072)),7072)+"\nQQClientKey:"+GetClientKey(7072)+"\nQQHttpKey:"+GetHttpKey(7072));
            //MessageBox.Show(GetOnepid("TIM.exe").ToString());
            String QQnum = GetClientUin(GetTIMpid());
            MessageBox.Show("QQ号:" + QQnum);
            if (checkBox1.Checked)
            {
                textBox1.Text = QQnum;
            }
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("QQ名:" + GetClientName(long.Parse(GetClientUin(GetTIMpid())), GetTIMpid()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String CK = GetClientKey(GetTIMpid());
            MessageBox.Show("ClientKey:" + CK);
            if (checkBox1.Checked) {
                textBox3.Text = CK;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String HK = GetHttpKey(GetTIMpid());
            MessageBox.Show("HttpKey:" + HK);
            if (checkBox1.Checked)
            {
                textBox2.Text = HK;
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ssl.ptlogin2.qq.com/jump?ptlang=2052&clientuin=" + textBox1.Text + "&clientkey=" + textBox3.Text + "&u1=https:%2F%2Fuser.qzone.qq.com%2F2377295471%2Finfocenter&source=panelstar");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ssl.ptlogin2.qq.com/jump?clientuin=" + textBox1.Text + "&clientkey=" + textBox2.Text + "&keyindex=9&u1=https://mail.qq.com/cgi-bin/login?vt=passport&vm=wpt&ft=ptlogin");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
