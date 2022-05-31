using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ntword
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> m_dic = new Dictionary<string, string>();
        bool m_ejToggle = false;
        string m_thiskey = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_dic["CA"] = "California";
            m_dic["TX"] = "Texas";
            m_dic["instruction"] = "指示";
            readWordListFromTsvFile();

            m_thiskey = this.GetRandomKey();
            txtWord.Text = m_thiskey;
            m_ejToggle = false;
            btnBack.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_ejToggle)
            {
                // E
                m_thiskey = this.GetRandomKey();
                txtWord.Text = m_thiskey;
                txtJapanese.Text = "";
                btnBack.Enabled = false;
            }
            else
            {
                // J
                txtJapanese.Text = m_dic[m_thiskey];
                btnBack.Enabled = true;
            }
            m_ejToggle = m_ejToggle ? false : true; // 反転
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //txtWord.Text = m_thiskey;
            //txtJapanese.Text = "";
            //btnBack.Enabled = false;
        }

        private string GetRandomKey()
        {
            Random rnd = new Random();
            // Generate random indexes for pet names.
            int mIndex = rnd.Next(m_dic.Count);

            int t = 0;
            foreach (string s in m_dic.Keys)
            {
                if (t == mIndex) return s;
                t++;
            }

            return "Nothing";
        }

        private void readWordListFromTsvFile()
        {
            StreamReader sr = new StreamReader("wordlist.tsv", Encoding.GetEncoding("Shift_JIS"));
            try
            {
                while (sr.EndOfStream == false)
                {
                    string line = sr.ReadLine();
                    //string[] fields = line.Split(',');
                    string[] fields = line.Split('\t'); //TSVファイルの場合

                    //for (int i = 0; i < fields.Length; i++)
                    //{
                    //    m_dic[fields[i]]
                    //    textBox1.Text += fields[i] + "\r\n";
                    //}
                    //textBox1.Text += "------\r\n";
                    m_dic[fields[0]] = fields[1];
                }
            }
            finally
            {
                sr.Close();
            }
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            // 覚えたので
        }
    }
}
