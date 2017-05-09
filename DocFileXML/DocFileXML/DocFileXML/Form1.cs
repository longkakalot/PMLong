using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace DocFileXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fileName = "";
        string[] giatri = new string[100];
        XmlNodeList nodelist ;
        string xml1, xml2, xml3;
        string xml4="";
        string[] abc;
        string abcd = "";

        public string MoFileXML()
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                fileName = oFile.FileName;
                return fileName;
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Đường dẫn tới file xml.


            // Tạo một đối tượng TextReader mới
            //XmlTextReader xtr = new XmlTextReader(fileName);

            //while (xtr.Read())
            //{
            //    if (xtr.NodeType == XmlNodeType.Element)
            //    {
            //        for (int i = 0; i < xtr.AttributeCount; i++)
            //        {
            //            listBox1.Items.Add(xtr.GetAttribute(i));

            //            MessageBox.Show(xtr.Name);
            //            if (xtr.Name=="GIAMDINHHS")
            //            {
            //                MessageBox.Show(xtr.Name + "abc");
            //                listBox1.Items.Clear();

            //            }
            //        }
            //    }

            //}
            string fxml = MoFileXML();
            //làm sạch listbox
            listBox1.Items.Clear();
            //mở tài liệu XML
            XmlDocument doc = new XmlDocument();
            doc.Load(fxml);
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
        //đưa dữ liệu từ listbox qua mảng
        public string[] get()
        {
            string[] arr = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                arr[i] = listBox1.Items[i].ToString();
            }
            return arr;
        }

        public void DocFileXML()
        {
            string fxml = MoFileXML();
            FileStream fs = new FileStream(fxml, FileMode.Open);
            XmlTextReader xtr = new XmlTextReader(fs);
            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element)
                {
                    for (int i = 0; i < xtr.AttributeCount; i++)
                    {
                        MessageBox.Show(xtr.GetAttribute(i));
                        listBox1.Items.Add(xtr.GetAttribute(i));
                    }
                }
            }
        }

        public void noidungXML()
        {
            XmlNodeList nl;
            string fxml = MoFileXML();
            XmlDocument doc = new XmlDocument();
            doc.Load(fxml);
            nl = doc.GetElementsByTagName("FILEHOSO");
            MessageBox.Show(nl.Count.ToString());
            MessageBox.Show(nl[1].InnerText);

        }
        
        public void getfileXML()
        {
            textBox1.Text = nodelist.Count.ToString();
            string hoso = nodelist[listBox1.SelectedIndex].InnerText;
            //MessageBox.Show(hoso);
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
                xml2 = xml21.Substring(4, vtxml3-4);
                richTextBox2.Text = xml2;
            }
            if (vitrixml3 > 0 && vitrixml4 > 0)
            {
                string xml31 = hoso.Substring(vitrixml3 + 4);
                int vtxml4 = xml31.IndexOf("XML4");               
                xml3 = xml31.Substring(4, vtxml4-4);
                richTextBox3.Text = xml3;
            }
            if (vitrixml3 > 0 && vitrixml4 == -1)
            {
                string xml31 = hoso.Substring(vitrixml3);
                int vtxml4 = xml31.Length;
                //MessageBox.Show(vtxml4.ToString());
                //MessageBox.Show(xml31);
                xml3 = xml31.Substring(4, vtxml4-4);
                richTextBox3.Text = xml3;
            }           
            if (vitrixml4 > 0)
            {
                string xml41 = hoso.Substring(vitrixml4);
                int vtxml4 = xml41.Length;
                xml4 = xml41.Substring(4, vtxml4-4);
                //richTextBox7.Text = xml4;
                //MessageBox.Show(vtxml4.ToString());
            }
        }        

        public void chuyendoiXML()
        {
            richTextBox4.Text = "";
            richTextBox5.Text = "";
            richTextBox6.Text = "";
            richTextBox7.Text = "";
            richTextBox4.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml1));
            richTextBox5.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml2));
            richTextBox6.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml3));
            richTextBox7.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml4));            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //mở tài liệu XML
            //XmlDocument doc = new XmlDocument();
            //doc.Load("book.xml");

            ////Create an XmlNamespaceManager for resolving namespaces.
            //XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            //nsmgr.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
            
            ////Select and display the value of all the ISBN attributes.            
            //XmlElement root = doc.DocumentElement;
            //nodeList2 = root.SelectNodes("/GIAMDINHHS/THONGTINHOSO/DANHSACHHOSO/HOSO/FILEHOSO/NOIDUNGFILE", nsmgr);
            //foreach (XmlNode isbn in nodeList2)
            //{
            //    listBox2.Items.Add(isbn.Name);                
            //}
            getfileXML();
            chuyendoiXML();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //richTextBox2.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml1));
            listBox1.Focus();
            listBox1.SelectedIndex = int.Parse(textBox1.Text)-1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DocFileXML();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox4.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(richTextBox1.Text));
            richTextBox5.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(richTextBox2.Text));
            richTextBox6.Text = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(richTextBox3.Text));
        }

        private void mớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }
    }
}
