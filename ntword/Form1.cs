using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;

namespace ntword
{
    public partial class Form1 : Form
    {
        List<EJDic> m_dic = new List<EJDic>();
        bool m_ejToggle = false;
        int m_thisIndex = -1;
        string m_thiskey = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //m_dic["CA"] = "California";
            //m_dic["TX"] = "Texas";
            //m_dic["instruction"] = "指示";
            readWordListFromTsvFile();

            m_thiskey = this.GetRandomKey();
            txtWord.Text = m_thiskey;
            txtJapanese.Text = SearchByWord(m_dic, m_thiskey);
            SetCheck(chk1, m_dic[m_thisIndex]);
            m_ejToggle = false;
            btnBack.Enabled = false;
        }

        private void SetCheck(CheckBox _chk1, EJDic eJDic)
        {
            if(eJDic == null)
            {
                _chk1.Checked = false;
                return;
            }

            if (eJDic.finish_flag)
            {
                _chk1.Checked = true;
            }
            else
            {
                _chk1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_ejToggle)
            {
                // E
                m_thiskey = this.GetRandomKey();
                txtWord.Text = m_thiskey;
                txtJapanese.Text = "";
                SetCheck(chk1, m_dic[m_thisIndex]);
                btnBack.Enabled = false;
            }
            else
            {
                // J
                //txtJapanese.Text = m_dic[m_thiskey];
                txtJapanese.Text = SearchByWord(m_dic, m_thiskey);
                SetCheck(chk1, m_dic[m_thisIndex]);
                btnBack.Enabled = true;
            }
            m_ejToggle = m_ejToggle ? false : true; // 反転
        }

        private string SearchByWord(List<EJDic> m_dic, string thiskey)
        {
            foreach(var oneWord in m_dic)
            {
                if (oneWord.eword == thiskey)
                {
                    return oneWord.jdesc;
                }
            }

            return "";
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
            m_thisIndex = rnd.Next(m_dic.Count);

            //int t = 0;
            //foreach (string s in m_dic.Keys)
            //{
            //    if (t == mIndex) return s;
            //    t++;
            //}
            //            return "Nothing";
            
            return m_dic[m_thisIndex].eword;
        }

        private void readWordListFromTsvFile()
        {
            //StreamReader sr = new StreamReader("wordlist.tsv", Encoding.GetEncoding("Shift_JIS"));
            //try
            //{
            //    while (sr.EndOfStream == false)
            //    {
            //        string line = sr.ReadLine();
            //        //string[] fields = line.Split(',');
            //        string[] fields = line.Split('\t'); //TSVファイルの場合

            //        m_dic.Add(new EJDic { eword= fields[0], jdesc= fields[1], finish_flag=false });
            //        //m_dic[fields[0]] = fields[1];
            //    }
            //}
            //finally
            //{
            //    sr.Close();
            //}

            // デシリアライズ(jsonファイル→クラスオブジェクト)
            string jsonFilePath = @"TestData.json";

            using (var ms = new FileStream(jsonFilePath, FileMode.Open))
            {
                var serializer = new DataContractJsonSerializer(typeof(List<EJDic>));
                m_dic = (List<EJDic>)serializer.ReadObject(ms);
            }
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            // 覚えたので
            m_dic[m_thisIndex].finish_flag = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //［Ctrl］+［S］が押されたらキャッチする
            if (e.KeyData == (Keys.S | Keys.Control))
            {
                // シリアライズ(クラスオブジェクト→jsonファイル)
                string jsonFilePathOut = @"TestData.json";

                using (var stream = new MemoryStream())
                using (var fs = new FileStream(jsonFilePathOut, FileMode.Create))
                using (var sw = new StreamWriter(fs))
                {
                    var serializer = new DataContractJsonSerializer(typeof(List<EJDic>));
                    serializer.WriteObject(stream, m_dic);
                    var str2write = Encoding.UTF8.GetString(stream.ToArray());
                    sw.Write(str2write);
                }

                lblMessage.Text = "保存しました";
            }
        }
    }
}
