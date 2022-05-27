using System;
using System.Collections.Generic;
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

            m_thiskey = this.GetRandomKey();
            chk1.Text = m_thiskey;
            m_ejToggle = false;
            btnBack.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (m_ejToggle)
            {
                // E
                m_thiskey = this.GetRandomKey();
                chk1.Text = m_thiskey;
                btnBack.Enabled = false;
            }
            else
            {
                // J
                chk1.Text = m_dic[m_thiskey];
                btnBack.Enabled = true;
            }
            m_ejToggle = m_ejToggle ? false : true; // 反転
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            chk1.Text = m_thiskey;
            btnBack.Enabled = false;
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

    }
}
