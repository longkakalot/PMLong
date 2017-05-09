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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        XmlDocument doc = new XmlDocument();
        string xml1, xml2, xml3, xml4;
        string sxml1, sxml2, sxml3, sxml4;

        public void duyetXML()
        {
            string fileName = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                fileName = oFile.FileName;
            }
            doc.Load(fileName);
            XmlNodeList nlHOSO = doc.GetElementsByTagName("HOSO");
            foreach(XmlNode a in nlHOSO)
            {
                listBox1.Items.Add(a.Name);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            duyetXML();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                fileName = oFile.FileName;
            }
            doc.Load(fileName);            
            XmlNodeList nodesHOSO = doc.GetElementsByTagName("HOSO");
            XmlNodeList nodesFILEHOSO = doc.GetElementsByTagName("FILEHOSO");

            foreach (XmlNode a in nodesHOSO)
            {
                listBox1.Items.Add(a.InnerText);
                //string ab = a.InnerText;
                //MessageBox.Show(ab);
            }
        }

        public string[] get()
        {
            string[] arr = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                arr[i] = listBox1.Items[i].ToString();
                //MessageBox.Show(arr[i]);
            }
            return arr;
        }

        public string decodeBase64(string s)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));
        }
               

        public void TachFileXML(string hoso)
        {
            string a = hoso.Contains("XML1").ToString();
            int vitrixml1 = hoso.IndexOf("XML1");
            //MessageBox.Show(vitrixml1.ToString());
            int vitrixml2 = hoso.IndexOf("XML2");
           // MessageBox.Show(vitrixml2.ToString());
            int vitrixml3 = hoso.IndexOf("XML3");
            //MessageBox.Show(vitrixml3.ToString());
            int vitrixml4 = hoso.IndexOf("XML4");
            //MessageBox.Show(vitrixml4.ToString());            
            //MessageBox.Show(vitrixml1.ToString());
            if (vitrixml1 == 0 && vitrixml2 > 0 && a == "True")
            {
                string abcxml1 =  hoso.Substring(vitrixml1 + 4, vitrixml2 - 4);
                //MessageBox.Show(abcxml1);
                sxml1 = "XML1";                
                xml1 = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(abcxml1));
                //MessageBox.Show(xml1);
            }

            if (vitrixml1 == 0 && vitrixml2 == -1)
            {
                string xml31 = hoso.Substring(vitrixml3);
                int vtxml4 = xml31.Length;
                //MessageBox.Show(vtxml4.ToString());
                //MessageBox.Show(xml31);
                //xml3 = xml31.Substring(4, vtxml4 - 4);
                xml3 = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml31.Substring(4, vtxml4 - 4)));
            }
            if (vitrixml2 > 0 && vitrixml3 > 0)
            {
                string xml21 = hoso.Substring(vitrixml2);
                int vtxml3 = xml21.IndexOf("XML3");
                //xml2 = xml21.Substring(4, vtxml3 - 4);
                xml2 = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml21.Substring(4, vtxml3 - 4)));
            }
            if (vitrixml3 > 0 && vitrixml4 > 0)
            {
                string xml31 = hoso.Substring(vitrixml3 + 4);
                int vtxml4 = xml31.IndexOf("XML4");
                //xml3 = xml31.Substring(4, vtxml4 - 4);
                xml3 = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml31.Substring(4, vtxml4 - 4)));
            }
            if (vitrixml3 > 0 && vitrixml4 == -1)
            {
                string xml31 = hoso.Substring(vitrixml3);
                int vtxml4 = xml31.Length;
                //MessageBox.Show(vtxml4.ToString());
                //MessageBox.Show(xml31);
                //xml3 = xml31.Substring(4, vtxml4 - 4);
                xml3 = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml31.Substring(4, vtxml4 - 4)));
            }
            if (vitrixml4 > 0)
            {
                string xml41 = hoso.Substring(vitrixml4);
                int vtxml4 = xml41.Length;
                //xml4 = xml41.Substring(4, vtxml4 - 4);
                xml4 = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(xml41.Substring(4, vtxml4 - 4)));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] abc = get();
            MessageBox.Show(abc[1]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML file(*.xml)|*.xml";
            sfd.RestoreDirectory = true;
            string[] abc = get();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter xtw = new XmlTextWriter(sfd.FileName, Encoding.UTF8);
                xtw.Formatting = Formatting.Indented;
                xtw.WriteStartDocument();
                
                for (int i = 0; i< listBox1.Items.Count;i++)
                {
                   
                    
                    //xtw.WriteEndElement();
                    TachFileXML(abc[i]);
                    // write to element HoTen

                    xtw.WriteStartElement("HOSO");
                    xtw.WriteStartElement("FILEHOSO");
                    if (abc[i].Contains("XML1").ToString() == "True" && abc[i].Contains("XML2").ToString() == "True" && abc[i].Contains("XML3").ToString() == "True")
                    {                   
                        
                        xtw.WriteElementString("LOAIHOSO", "XML1");
                        xtw.WriteElementString("NOIDUNGFILE", xml1);
                        xtw.WriteElementString("LOAIHOSO", "XML2");
                        xtw.WriteElementString("NOIDUNGFILE", xml2);
                        xtw.WriteElementString("LOAIHOSO", "XML3");
                        xtw.WriteElementString("NOIDUNGFILE", xml3);
                        //xtw.WriteEndElement();
                    }
                    else if (abc[i].Contains("XML1").ToString() == "True" && abc[i].Contains("XML2").ToString() == "True" && abc[i].Contains("XML3").ToString() == "True" && abc[i].Contains("XML4").ToString() == "True")
                    {
                        
                        xtw.WriteStartElement("FILEHOSO");
                        xtw.WriteElementString("LOAIHOSO", "XML1");
                        xtw.WriteElementString("NOIDUNGFILE", xml1);
                        xtw.WriteElementString("LOAIHOSO", "XML2");
                        xtw.WriteElementString("NOIDUNGFILE", xml2);
                        xtw.WriteElementString("LOAIHOSO", "XML3");
                        xtw.WriteElementString("NOIDUNGFILE", xml3);
                        xtw.WriteElementString("LOAIHOSO", "XML4");
                        xtw.WriteElementString("NOIDUNGFILE", xml4);
                        //xtw.WriteEndElement();
                    }
                    else if (abc[i].Contains("XML1").ToString() == "True" && abc[i].Contains("XML2").ToString() == "True")
                    {
                        
                        xtw.WriteStartElement("FILEHOSO");
                        xtw.WriteElementString("LOAIHOSO", "XML1");
                        xtw.WriteElementString("NOIDUNGFILE", xml1);
                        xtw.WriteElementString("LOAIHOSO", "XML2");
                        xtw.WriteElementString("NOIDUNGFILE", xml2);
                        //xtw.WriteEndElement();
                    }
                    else
                    {

                    }
                    //xtw.WriteEndElement();
                    //xtw.WriteEndElement();


                }
                
                //xtw.WriteAttributeString("HOSO", "Viet Nam");
                
                xtw.WriteEndDocument();
                xtw.Flush();
                xtw.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sohoso = (listBox1.SelectedIndex).ToString();
            MessageBox.Show(sohoso);
        }

        
    }
}
