using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication1
{
    public class XML
    {
        
        public void OpenXML(XmlDocument doc)
        {
            string fileName = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                fileName = oFile.FileName;
                //tenfile = System.IO.Path.GetFileName(oFile.FileName);
            }
            doc.Load(fileName);
        }

        //public static void luuXML()
        //{
        //    string[] a;
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "XML file(*.xml)|*.xml";
        //    sfd.RestoreDirectory = true;
        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        XmlTextWriter xtw = new XmlTextWriter(sfd.FileName, Encoding.UTF8);
        //        xtw.Formatting = Formatting.Indented;

        //        xtw.WriteStartDocument();
        //        for (int i = 0; i < 2; i++)
        //        {
        //            xtw.WriteElementString("LOAIHOSO", a[0]);
        //        }
        //        xtw.WriteEndDocument();
        //        xtw.Flush();
        //        xtw.Close();
        //    }
        //}

        public string XMLtoBase64(string s)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));
        }
        public string base64ToXML(string s)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(s));
        }
        
    }
}
