using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DocFileXML
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string fileName = "";
        string[] giatri = new string[100];
        XmlNodeList nodelist;
        string xml1, xml2, xml3;
        string xml4 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                fileName = oFile.FileName;
            }
            //làm sạch listbox
            listBox1.Items.Clear();
            //mở tài liệu XML
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            //đưa tất cả các nút tìm được qua tên tag
            //vào nodelist

            nodelist = doc.GetElementsByTagName("HOSO");
            //đi lần lượt qua từng node cuaa nodelist
            //và đưa nó vào listbox
            foreach (XmlNode node in nodelist)
            {
                listBox1.Items.Add(node.Name);
            }
        }

        public void getfileXML()
        {
            label9.Text = nodelist.Count.ToString();
            string hoso = nodelist[listBox1.SelectedIndex].InnerText;
            int chieudaichuoi = hoso.Length;
            int vitrixml1 = hoso.IndexOf("XML1");
            int vitrixml2 = hoso.IndexOf("XML2");
            int vitrixml3 = hoso.IndexOf("XML3");
            int vitrixml4 = hoso.IndexOf("XML4");
            //MessageBox.Show(vitrixml1.ToString());
            if (vitrixml1 == 0 && vitrixml2 > 0)
            {
                xml1 = hoso.Substring(vitrixml1 + 4, vitrixml2 - 4);
                richTextBox1.Text = xml1;
            }

            if (vitrixml1 == 0 && vitrixml2 == -1)
            {
                string xml31 = hoso.Substring(vitrixml3);
                int vtxml4 = xml31.Length;
                //MessageBox.Show(vtxml4.ToString());
                //MessageBox.Show(xml31);
                xml3 = xml31.Substring(4, vtxml4 - 4);
                richTextBox3.Text = xml3;
            }
            if (vitrixml2 > 0 && vitrixml3 > 0)
            {
                string xml21 = hoso.Substring(vitrixml2);
                int vtxml3 = xml21.IndexOf("XML3");
                xml2 = xml21.Substring(4, vtxml3 - 4);
                richTextBox2.Text = xml2;
            }
            if (vitrixml3 > 0 && vitrixml4 > 0)
            {
                string xml31 = hoso.Substring(vitrixml3 + 4);
                int vtxml4 = xml31.IndexOf("XML4");
                xml3 = xml31.Substring(4, vtxml4 - 4);
                richTextBox3.Text = xml3;
            }
            if (vitrixml3 > 0 && vitrixml4 == -1)
            {
                string xml31 = hoso.Substring(vitrixml3);
                int vtxml4 = xml31.Length;
                //MessageBox.Show(vtxml4.ToString());
                //MessageBox.Show(xml31);
                xml3 = xml31.Substring(4, vtxml4 - 4);
                richTextBox3.Text = xml3;
            }
            if (vitrixml4 > 0)
            {
                string xml41 = hoso.Substring(vitrixml4);
                int vtxml4 = xml41.Length;
                xml4 = xml41.Substring(4, vtxml4 - 4);
                //richTextBox7.Text = xml4;
                //MessageBox.Show(vtxml4.ToString());
            }
        }

        public void chuyendoiXML()
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
            richTextBox1.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml1));
            richTextBox2.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml2));
            richTextBox3.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml3));
            richTextBox4.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml4));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getfileXML();
            chuyendoiXML();
        }

        //public static string Base64Decode(string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}

        //public static string DecodeBase64(this System.Text.Encoding encoding, string encodedText)
        //{
        //    if (encodedText == null)
        //    {
        //        return null;
        //    }

        //    byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
        //    return encoding.GetString(textAsBytes);
        //}
       // System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(base64EncodedData));

        private void button3_Click(object sender, EventArgs e)
        {           
            richTextBox5.Text = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(richTextBox1.Text));
            richTextBox6.Text = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(richTextBox2.Text));
            richTextBox7.Text = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(richTextBox3.Text));
            richTextBox8.Text = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(richTextBox4.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Focus();
            listBox1.SelectedIndex = int.Parse(textBox1.Text) - 1;
        }
    }
}
