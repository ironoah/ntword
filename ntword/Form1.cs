using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ntword
{
    public partial class Form1 : Form
    {
        // 外部ファイル名
        string EJWORD_FILE = "ejword.json";

        List<EJDic> m_dic = new List<EJDic>();
        bool m_ejToggle = false;
        int m_thisIndex = -1;
        //string m_thiskey = "";

        public Form1()
        {
            InitializeComponent();

            lblMessage.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //m_dic["CA"] = "California";
            //m_dic["TX"] = "Texas";
            //m_dic["instruction"] = "指示";
            readWordListFromTsvFile();

            Init();
        }

        private void Init()
        {
            m_thisIndex = this.GetRandomKey();
            txtWord.Text = m_dic[m_thisIndex].eword;
            txtJapanese.Text = "";
            //SetCheck(chk1, m_dic[m_thisIndex]);
            chk1.Checked = false;
            m_ejToggle = false;
            btnBack.Enabled = false;

            //debug
            lblMessage.Text = m_dic[m_thisIndex].eword + " : " + m_dic[m_thisIndex].jdesc + " : " + m_dic[m_thisIndex].finish_flag.ToString();

        }
        private void SetCheck(CheckBox _chk1, EJDic eJDic)
        {
            if (eJDic == null)
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
            try
            {
                if (m_ejToggle)
                {
                    // E
                    m_thisIndex = this.GetRandomKey();
                    //m_thiskey = this.GetRandomKey();
                    txtWord.Text = m_dic[m_thisIndex].eword;
                    txtJapanese.Text = "";
                    chk1.Checked = false;
                    btnBack.Enabled = false;
                }
                else
                {
                    // J
                    //txtJapanese.Text = m_dic[m_thiskey];
                    //txtJapanese.Text = SearchByWord(m_dic, m_thiskey);
                    txtJapanese.Text = m_dic[m_thisIndex].jdesc;
                    SetCheck(chk1, m_dic[m_thisIndex]);
                    btnBack.Enabled = true;
                }
                m_ejToggle = m_ejToggle ? false : true; // 反転
                                                        //debug
                                                        //lblMessage.Text = m_dic[m_thisIndex].eword + " : " + m_dic[m_thisIndex].jdesc + " : " + m_dic[m_thisIndex].finish_flag.ToString();

            }
            catch (Exception ex)
            {

            }
        }

        private string SearchByWord(List<EJDic> m_dic, string thiskey)
        {
            foreach (var oneWord in m_dic)
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

        private int GetRandomKey()
        {
            Random rnd = new Random();
            // Generate random indexes for pet names.
            var aaa = rnd.Next(m_dic.Count);
            //MessageBox.Show(aaa.ToString());
            return aaa;

            //int t = 0;
            //foreach (string s in m_dic.Keys)
            //{
            //    if (t == mIndex) return s;
            //    t++;
            //}
            //            return "Nothing";

            //return m_dic[m_thisIndex].eword;
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
            string jsonFilePath = EJWORD_FILE;

            using (var ms = new FileStream(jsonFilePath, FileMode.Open))
            {
                var serializer = new DataContractJsonSerializer(typeof(List<EJDic>));
                m_dic = (List<EJDic>)serializer.ReadObject(ms);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //［Ctrl］+［S］が押されたらキャッチする
            if (e.KeyData == (Keys.S | Keys.Control))
            {
                // 画面の情報を保存する
                m_dic[m_thisIndex].jdesc = txtJapanese.Text;

                // シリアライズ(クラスオブジェクト→jsonファイル)
                string jsonFilePathOut = EJWORD_FILE;

                //using (var stream = new MemoryStream())
                //using (var fs = new FileStream(jsonFilePathOut, FileMode.Create))
                //using (var sw = new StreamWriter(fs))
                //{
                //    var serializer = new DataContractJsonSerializer(typeof(List<EJDic>));
                //    serializer.WriteObject(stream, m_dic);
                //    var str2write = Encoding.UTF8.GetString(stream.ToArray());
                //    sw.Write(str2write);
                //}

                using (var stream = new MemoryStream())
                using (var fs = new FileStream(jsonFilePathOut, FileMode.Create))
                using (var sw = new StreamWriter(fs))
                {
                    PushCulture(CultureInfo.InvariantCulture);

                    try
                    {
                        using (var writer =
                            JsonReaderWriterFactory.CreateJsonWriter(
                            stream, Encoding.UTF8, true, true, "  "))
                        {
                            var serializer = new DataContractJsonSerializer(typeof(List<EJDic>), Settings);
                            serializer.WriteObject(writer, m_dic);
                            writer.Flush();
                            var str2write = Encoding.UTF8.GetString(stream.ToArray());
                            sw.Write(str2write);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("ObjectToJson Error (inner) : " + ex.ToString());
                        throw;
                    }
                    finally
                    {
                        PopCulture();
                    }
                }

                lblMessage.Text = "保存しました";
            }
        }

        private void chk1_Click(object sender, EventArgs e)
        {
            m_dic[m_thisIndex].finish_flag = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtWord.Text = "";
            txtJapanese.Text = "";
            chk1.Checked = false;

            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtWord.Text == "") {
                MessageBox.Show("English is Empty.");
                return;
            }

            // 既に存在している場合は終了
            if(SearchByWord(m_dic, txtWord.Text) != "")
            {
                MessageBox.Show("This word already exists.");
                return;
            }

            m_dic.Add(new EJDic { eword=txtWord.Text, jdesc=txtJapanese.Text, finish_flag=false});

            txtWord.Text = "";
            txtJapanese.Text = "";
            chk1.Checked = false;

            btnAdd.Enabled = false;
            lblMessage.Text = "新しい単語を登録しました";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;

            Init();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("Delete this word [ "+ m_dic[m_thisIndex].eword + " ]？",
                "Confirm",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                //Console.WriteLine("「はい」が選択されました");
                m_dic.RemoveAt(m_thisIndex);

                Init();
            }
            else if (result == DialogResult.No)
            {
                //「いいえ」が選択された時
                //Console.WriteLine("「いいえ」が選択されました");
            }
            else if (result == DialogResult.Cancel)
            {
                //「キャンセル」が選択された時
                //Console.WriteLine("「キャンセル」が選択されました");
            }

            
        }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////
        /// </summary>
        private static readonly DataContractJsonSerializerSettings Settings =
    new DataContractJsonSerializerSettings
    {
        UseSimpleDictionaryFormat = true
    };

        private static CultureInfo _cultureStorage = null;

        private static void PushCulture(CultureInfo culture)
        {
            if (_cultureStorage != null)
                throw new ApplicationException("PushCulture : double pushed!");
            _cultureStorage = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private static void PopCulture()
        {
            if (_cultureStorage == null)
                throw new ApplicationException("PopCulture : double popped!");
            Thread.CurrentThread.CurrentCulture = _cultureStorage;
            _cultureStorage = null;
        }
    }
}
