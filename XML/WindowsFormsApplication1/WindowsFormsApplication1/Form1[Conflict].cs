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
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Data da = new Data();

        string tenfile = "";

        XmlDocument doc = new XmlDocument();
        string appPath = "";
        string loaiHOSO = "";
        string noiDungHOSO = "";
        string noiDungHOSOMAHOA = "";
        string noiDungHOSOMAHOA1 = "";
        string noiDungHOSOMAHOA2 = "";
        string maNoiBo = "";
        string tenNoiBo = "";
        string maVatTuNoiBo = "";
        string maKhoa = "";
        string donGia = "";
        string maThuoc = "";
        string tenThuoc = "";
        string donGia_XML2 = "";
        string maKhoa_XML2 = "";
        string maLK_XML3 = "";
        string maLK_XML2 = "";
        string maLK_XML1 = "";
        string maBN_XML1 = "";
        string hoTenBN_XML1 = "";
        string tenBenh_XML1 = "";
        string maBenh_XML1 = "";
        string maBenhKhac_XML1 = "";
        string[] a;

        public void OpenXML()
        {
            string fileName = "";
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                fileName = oFile.FileName;
                tenfile = System.IO.Path.GetFileName(oFile.FileName);
            }
            doc.Load(fileName);
        }

        public void luuXML()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML file(*.xml)|*.xml";
            sfd.RestoreDirectory = true;
            // string[] abc = get();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XmlTextWriter xtw = new XmlTextWriter(sfd.FileName, Encoding.UTF8);
                xtw.Formatting = Formatting.Indented;

                xtw.WriteStartDocument();
                for (int i = 0; i < 2; i++)
                {
                    //xtw.WriteStartElement("HOSO");
                    //xtw.WriteStartElement("FILEHOSO");
                    xtw.WriteElementString("LOAIHOSO", a[0]);

                    //xtw.WriteEndElement();
                    //xtw.WriteCData(maHoaXML);
                    //xtw.WriteElementString("HOSO", abc);
                    //xtw.WriteEndElement();
                }

                xtw.WriteEndDocument();
                xtw.Flush();
                xtw.Close();
            }
        }

        public string XMLtoBase64(string s)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));
        }
        public string base64ToXML(string s)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(s));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenXML();
            //Tạo danh sách các node HOSO
            XmlNodeList nodeListHOSO = doc.GetElementsByTagName("HOSO");

            //Ghi ra file XML mới
            XmlTextWriter xtw = new XmlTextWriter("base64toXML.xml", Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartDocument();
            xtw.WriteStartElement("DANHSACHHOSO"); //ghi ra file XML 1 node mới tên là "DANHSACHHOSO"

            foreach (XmlNode nodeHOSO in nodeListHOSO) //duyệt tất cả các node HOSO trong danh sách HOSO
            {
                xtw.WriteStartElement("HOSO"); // ghi ra file XML 1 node mới tên là "HOSO"
                foreach (XmlNode nodeFILEHOSO in nodeHOSO.ChildNodes) //duyệt tất cả các node FILEHOSO trong danh sách con của HOSO
                {
                    loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                    noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                    noiDungHOSOMAHOA = base64ToXML(noiDungHOSO); //giải mã base64                    
                    //XmlNode n = doc.GetElementsByTagName();
                    //noiDungHOSOMAHOA1 = noiDungHOSOMAHOA.Replace("&lt;", "<");
                    //noiDungHOSOMAHOA2 = noiDungHOSOMAHOA1.Replace("&gt;", ">");
                    a = new string[] { loaiHOSO, noiDungHOSOMAHOA }; //đưa thông tin vào mảng (có thể ko cần thiết)                    
                    //root element                    
                    xtw.WriteStartElement("FILEHOSO"); //tạo element
                    xtw.WriteElementString("LOAIHOSO", loaiHOSO); //tạo element và nội dung
                    xtw.WriteElementString("NOIDUNGFILE", noiDungHOSOMAHOA);

                    //end root element
                    xtw.WriteEndElement();// đóng element             
                }
                xtw.WriteEndElement();
            }
            xtw.WriteEndDocument();
            xtw.Flush();
            xtw.Close();
            MessageBox.Show("Thành công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenXML();
            //Tạo danh sách các node HOSO
            XmlNodeList nodeListHOSO = doc.GetElementsByTagName("HOSO");

            //Ghi ra file XML mới
            XmlTextWriter xtw = new XmlTextWriter("XMLtoBase64.xml", Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartDocument();
            xtw.WriteStartElement("DANHSACHHOSO"); //ghi ra file XML 1 node mới tên là "DANHSACHHOSO"

            foreach (XmlNode nodeHOSO in nodeListHOSO) //duyệt tất cả các node HOSO trong danh sách HOSO
            {
                xtw.WriteStartElement("HOSO"); // ghi ra file XML 1 node mới tên là "HOSO"
                foreach (XmlNode nodeFILEHOSO in nodeHOSO.ChildNodes) //duyệt tất cả các node FILEHOSO trong danh sách con của HOSO
                {
                    loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                    noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                    noiDungHOSOMAHOA = XMLtoBase64(noiDungHOSO); //giải mã base64
                    //MessageBox.Show(noiDungHOSOMAHOA);
                    //noiDungHOSOMAHOA1 = noiDungHOSOMAHOA.Replace("&lt;?xml version="1.0" encoding="utf - 8" ?&gt;", "<VU></VU>");
                    noiDungHOSOMAHOA1 = noiDungHOSOMAHOA.Replace("&lt;", "<");
                    //noiDungHOSOMAHOA2 = noiDungHOSOMAHOA1.Replace("&gt;", ">");
                    a = new string[] { loaiHOSO, noiDungHOSOMAHOA2 }; //đưa thông tin vào mảng (có thể ko cần thiết)                    
                    //root element                    
                    xtw.WriteStartElement("FILEHOSO"); //tạo element
                    xtw.WriteElementString("LOAIHOSO", loaiHOSO); //tạo element và nội dung
                    xtw.WriteElementString("NOIDUNGFILE", noiDungHOSOMAHOA);
                    //end root element
                    xtw.WriteEndElement();// đóng element             
                }
                xtw.WriteEndElement();
            }
            xtw.WriteEndDocument();
            xtw.Flush();
            xtw.Close();
            MessageBox.Show("Thành công");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenXML();
            //Tạo danh sách các node HOSO
            XmlNodeList nodeListHOSO = doc.GetElementsByTagName("HOSO");
            //Ghi ra file XML mới
            XmlTextWriter xtw = new XmlTextWriter("base64toXML.xml", Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartDocument();
            xtw.WriteStartElement("DANHSACHHOSO"); //ghi ra file XML 1 node mới tên là "DANHSACHHOSO"
            foreach (XmlNode nodeHOSO in nodeListHOSO) //duyệt tất cả các node HOSO trong danh sách HOSO
            {
                xtw.WriteStartElement("HOSO"); // ghi ra file XML 1 node mới tên là "HOSO"
                foreach (XmlNode nodeFILEHOSO in nodeHOSO.ChildNodes) //duyệt tất cả các node FILEHOSO trong danh sách con của HOSO
                {
                    loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                    noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                    noiDungHOSOMAHOA = base64ToXML(noiDungHOSO); //giải mã base64                    
                    if (loaiHOSO == "XML3")
                    {
                        XmlDocument doc1 = new XmlDocument();
                        string c = noiDungHOSOMAHOA.Substring(noiDungHOSOMAHOA.IndexOf('\n'));
                        int index = c.ToString().LastIndexOf('\n');
                        if (index >= 0)
                        {
                            c.Remove(index, 1);
                        }

                        doc1.LoadXml(c);
                        //MessageBox.Show(doc1.InnerXml);
                        //doc1.LoadXml(@"<abc><a>long</a></abc>");
                        XmlElement nodeMaDichVu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_DICH_VU") as XmlElement;
                        maNoiBo = nodeMaDichVu.InnerText;
                        //MessageBox.Show(maNoiBo);
                        nodeMaDichVu.InnerText = doiMaNoiBo();
                        //MessageBox.Show(nodeMaDichVu.InnerText);

                        XmlElement nodeMaVatTu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_VAT_TU") as XmlElement;
                        maVatTuNoiBo = nodeMaVatTu.InnerText;
                        MessageBox.Show(maVatTuNoiBo);
                        nodeMaVatTu.InnerText = doiMaNoiBo_VatTu();
                        //MessageBox.Show(nodeMaVatTu.InnerText);


                        XmlElement nodeTenDichVu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/TEN_DICH_VU") as XmlElement;
                        tenNoiBo = nodeTenDichVu.InnerText;
                        //MessageBox.Show(tenNoiBo);
                        string tendichvu1 = "<![CDATA[";
                        string tendichvu2 = "]]";
                        nodeTenDichVu.InnerText = tendichvu1 + doiTenNoiBo() + tendichvu2;
                        string headerXML3 = "<?xml version=\"" + "1.0\"" + " encoding=\"" + "utf-8\"" + " ?>";
                        //MessageBox.Show(a);
                        string noidungXML3 = doc1.InnerXml;
                        noiDungHOSOMAHOA = (headerXML3 + noidungXML3).Replace("&lt;", "<");
                        //MessageBox.Show(noiDungHOSOMAHOA);
                    }
                    //XmlNode n = doc.GetElementsByTagName();
                    //noiDungHOSOMAHOA1 = noiDungHOSOMAHOA.Replace("&lt;", "<");
                    //noiDungHOSOMAHOA2 = noiDungHOSOMAHOA1.Replace("&gt;", ">");
                    a = new string[] { loaiHOSO, noiDungHOSOMAHOA }; //đưa thông tin vào mảng (có thể ko cần thiết)                    
                    //root element                    
                    xtw.WriteStartElement("FILEHOSO"); //tạo element
                    xtw.WriteElementString("LOAIHOSO", loaiHOSO); //tạo element và nội dung
                    xtw.WriteElementString("NOIDUNGFILE", noiDungHOSOMAHOA);

                    //end root element
                    xtw.WriteEndElement();// đóng element             
                }
                xtw.WriteEndElement();
            }
            xtw.WriteEndDocument();
            xtw.Flush();
            xtw.Close();
            MessageBox.Show("Thành công");
        }
        public DataTable LayMaTuongDuong(string manoibo)
        {
            string sql = "Select matuongduong from abc where manoibo = '" + manoibo + "'";
            DataTable dt = da.LayDulieu(sql).Tables[0];
            return dt;
        }

        public DataTable LayTenVatTuTuongDuong(string manoibo_vattu)
        {
            string sql = "Select tentuongduong from abc where manoibo = '" + manoibo_vattu + "'";
            DataTable dt = da.LayDulieu(sql).Tables[0];
            return dt;
        }

        public DataTable LayTenTuongDuong(string manoibo)
        {
            string sql = "Select tentuongduong from abc where manoibo = '" + manoibo + "'";
            DataTable dt = da.LayDulieu(sql).Tables[0];
            return dt;
        }

        public string doiMaNoiBo_VatTu()
        {
            string a = "";
            DataTable d = LayTenVatTuTuongDuong(maVatTuNoiBo);
            if (d != null && d.Rows.Count > 0)
            {
                dataGridView1.DataSource = d;
                a = dataGridView1.Rows[0].Cells[0].Value.ToString();
                return a;
            }
            else
            {
                string[] b = new string[] { maVatTuNoiBo };
                //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
                File.AppendAllLines(@"E:\" + tenfile + "vattu" + ".txt", b);
                //File.AppendAllText(@"D:\path.txt", maNoiBo);
                //MessageBox.Show("Thiếu mã tương đương: " + maNoiBo);
                return maVatTuNoiBo;
            }
        }
        public string doiMaNoiBo()
        {
            string a = "";
            DataTable d = LayMaTuongDuong(maNoiBo);
            if (d != null && d.Rows.Count > 0)
            {
                dataGridView1.DataSource = d;
                a = dataGridView1.Rows[0].Cells[0].Value.ToString();
                MessageBox.Show(a);
                return a;
            }
            else
            {
                string[] b = new string[] { maNoiBo, maVatTuNoiBo };
                File.AppendAllLines(@"E:\" + tenfile + ".txt", b);
                return maNoiBo;
            }
        }
        public string doiTenNoiBo()
        {
            string a = "";
            DataTable d = LayTenTuongDuong(maNoiBo);
            if (d != null && d.Rows.Count > 0)
            {
                dataGridView1.DataSource = d;
                a = dataGridView1.Rows[0].Cells[0].Value.ToString();
                return a;
            }
            else
            {
                string[] b = new string[] { tenNoiBo };
                //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
                File.AppendAllLines(@"E:\" + tenfile + "tennoibo" + ".txt", b);
                //MessageBox.Show(tenNoiBo);
                //File.AppendAllText(@"D:\path.txt", maNoiBo);
                //MessageBox.Show("Thiếu mã tương đương: " + maNoiBo);
                //MessageBox.Show("Thiếu tên tương đương: " + tenNoiBo);
                return tenNoiBo;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            appPath = fd.SelectedPath.ToString();
            int fileCount = Directory.GetFiles(appPath, "*.*", SearchOption.AllDirectories).Length;
            //MessageBox.Show(fileCount.ToString());
            pBar.Visible = true;
            pBar.Minimum = 1;
            pBar.Maximum = fileCount;
            pBar.Value = 1;
            pBar.Step = 1;            
            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fd.SelectedPath)
                                          .Where(p => p.EndsWith(".xml"))
                                          .ToArray();
                for (int i = 1; i < fileCount; i++)
                {
                    foreach (var path in files)
                    {                        
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(path);
                        XmlNodeList nodeTHONGTINHOSO = xDoc.GetElementsByTagName("THONGTINHOSO");
                        string ngaylap = "";
                        foreach (XmlNode node in nodeTHONGTINHOSO)
                        {
                            ngaylap = node.SelectSingleNode("NGAYLAP").InnerText;
                        }
                        
                        XmlNodeList nodeListHOSO = xDoc.GetElementsByTagName("HOSO");
                        
                        foreach (XmlNode nodeHOSO in nodeListHOSO) //duyệt tất cả các node HOSO trong danh sách HOSO
                        {                            
                            foreach (XmlNode nodeFILEHOSO in nodeHOSO.ChildNodes) //duyệt tất cả các node FILEHOSO trong danh sách con của HOSO
                            {
                                loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                                noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                                noiDungHOSOMAHOA = base64ToXML(noiDungHOSO); //giải mã base64  
                                if (loaiHOSO == "XML2")
                                {
                                    GetInfoXML2();
                                }
                                if (loaiHOSO == "XML3")
                                {
                                    GetInfoXML3();
                                }
                                if (loaiHOSO == "XML1")
                                {
                                    GetInfoXML1();
                                }
                            }                            
                        }                        
                        i++;
                        int percent = (int)(((double)pBar.Value / (double)pBar.Maximum) * 100);
                        pBar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(pBar.Width / 2 - 10, pBar.Height / 2 - 7));
                        pBar.PerformStep();
                    }
                }
                MessageBox.Show("Thành công");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenXML();
            //Tạo danh sách các node HOSO
            XmlNodeList nodeListHOSO = doc.GetElementsByTagName("HOSO");
            MessageBox.Show(nodeListHOSO.Count.ToString());
            //Ghi ra file XML mới
            //string duongdan = @"E:\\base64toXML\";
            string tenfileXML = @"E:\base64toXML\" + "base64toXML" + tenfile + ".xml";
            XmlTextWriter xtw = new XmlTextWriter(tenfileXML, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.WriteStartDocument();
            xtw.WriteStartElement("DANHSACHHOSO"); //ghi ra file XML 1 node mới tên là "DANHSACHHOSO"
            foreach (XmlNode nodeHOSO in nodeListHOSO) //duyệt tất cả các node HOSO trong danh sách HOSO
            {
                xtw.WriteStartElement("HOSO"); // ghi ra file XML 1 node mới tên là "HOSO"
                foreach (XmlNode nodeFILEHOSO in nodeHOSO.ChildNodes) //duyệt tất cả các node FILEHOSO trong danh sách con của HOSO
                {

                    loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                    noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                    noiDungHOSOMAHOA = base64ToXML(noiDungHOSO); //giải mã base64  
                    if (loaiHOSO == "XML2")
                    {
                        GetInfoXML2();

                    }
                    if (loaiHOSO == "XML3")
                    {
                        //GetInfoXML3();                                            
                    }

                    a = new string[] { loaiHOSO, noiDungHOSOMAHOA }; //đưa thông tin vào mảng (có thể ko cần thiết)                    
                    //root element                    
                    xtw.WriteStartElement("FILEHOSO"); //tạo element
                    xtw.WriteElementString("LOAIHOSO", loaiHOSO); //tạo element và nội dung
                    xtw.WriteElementString("NOIDUNGFILE", noiDungHOSOMAHOA);
                    //end root element
                    xtw.WriteEndElement();// đóng element             
                }
                xtw.WriteEndElement();
            }
            xtw.WriteEndDocument();
            xtw.Flush();
            xtw.Close();
            MessageBox.Show("Thành công");
        }

       
        void GetInfoXML1()
        {
            XmlDocument doc1 = new XmlDocument();
            string c = noiDungHOSOMAHOA.Substring(noiDungHOSOMAHOA.IndexOf('\n'));
            string d = noiDungHOSOMAHOA.Replace("﻿&lt;", "<").Replace("&gt;", ">");

            int index = c.ToString().LastIndexOf('\n');
            if (index >= 0)
            {
                c.Remove(index, 1);
            }                        
            doc1.LoadXml(c);
            XmlNodeList nodeListNOIDUNGFILE = doc1.GetElementsByTagName("TONG_HOP");            
            
            foreach (XmlNode node in nodeListNOIDUNGFILE)
            {
                //XmlElement nodeMaLK = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_LK") as XmlElement;
                maLK_XML1 = node.SelectSingleNode("MA_LK").InnerText;
                string abc = maLK_XML1.ToString();
                string[] arrMaLK = new string[] { maLK_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_LK_XML1" + ".txt", arrMaLK);
                                
                maBN_XML1 = node.SelectSingleNode("MA_BN").InnerText;
                string[] arrMaBN = new string[] { maBN_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_BN_XML1" + ".txt", arrMaBN);

                hoTenBN_XML1 = node.SelectSingleNode("HO_TEN").InnerText;
                string[] arrHoTen = new string[] { hoTenBN_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ho_Ten_XML1" + ".txt", arrHoTen);

                tenBenh_XML1 = node.SelectSingleNode("TEN_BENH").InnerText;
                string[] arrTenBenh = new string[] { tenBenh_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ten_Benh_XML1" + ".txt", arrTenBenh);

                maBenh_XML1 = node.SelectSingleNode("MA_BENH").InnerText;
                string[] arrMaBenh = new string[] { maBenh_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_Benh_XML1" + ".txt", arrMaBenh);

                maBenhKhac_XML1 = node.SelectSingleNode("MA_BENHKHAC").InnerText;
                string[] arrMaBenhKhac = new string[] { maBenhKhac_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_BenhKhac_XML1" + ".txt", arrMaBenhKhac);


            }
            dataGridView1.DataSource = dtXML1;
            
        }

        void GetInfoXML2()
        {
            XmlDocument doc1 = new XmlDocument();
            string c = noiDungHOSOMAHOA.Substring(noiDungHOSOMAHOA.IndexOf('\n'));
            string d = noiDungHOSOMAHOA.Replace("﻿&lt;", "<").Replace("&gt;", ">");

            int index = c.ToString().LastIndexOf('\n');
            if (index >= 0)
            {
                c.Remove(index, 1);
            }
            //MessageBox.Show(d);

            //richTextBox1.Text = d;
            doc1.LoadXml(c);
            XmlNodeList nodeListNOIDUNGFILE = doc1.GetElementsByTagName("DSACH_CHI_TIET_THUOC");
            //MessageBox.Show(nodeListNOIDUNGFILE.Count.ToString());
            foreach (XmlNode nodeDSACH_CHI_TIET_THUOC in nodeListNOIDUNGFILE)
            {
                foreach (XmlNode node in nodeDSACH_CHI_TIET_THUOC.ChildNodes)
                {
                    //XmlElement nodeMaLK = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_LK") as XmlElement;
                    maLK_XML2 = node.SelectSingleNode("MA_LK").InnerText;
                    string[] arrMaLK = new string[] { maLK_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_Ma_LK_XML2" + ".txt", arrMaLK);

                    //XmlElement nodeSTT = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/STT") as XmlElement;
                    string STT_XML2 = node.SelectSingleNode("STT").InnerText;
                    string[] arrSTT = new string[] { STT_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_STT_XML2" + ".txt", arrSTT);

                    //XmlElement nodeMaThuoc = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_THUOC") as XmlElement;
                    maThuoc = node.SelectSingleNode("MA_THUOC").InnerText;
                    string[] arrMaThuoc = new string[] { maThuoc };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_Ma_Thuoc_XML2" + ".txt", arrMaThuoc);

                    //XmlElement nodeTenThuoc = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/TEN_THUOC") as XmlElement;
                    tenThuoc = node.SelectSingleNode("TEN_THUOC").InnerText;
                    string[] arrtenThuoc = new string[] { tenThuoc };
                    //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_Ten_Thuoc_XML2" + ".txt", arrtenThuoc);

                    //XmlElement nodeDonGia = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/DON_GIA") as XmlElement;
                    donGia_XML2 = node.SelectSingleNode("DON_GIA").InnerText;
                    string[] arrDonGia = new string[] { donGia_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_DonGia_XML2" + ".txt", arrDonGia);

                    //XmlElement nodeMaKhoa = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_KHOA") as XmlElement;
                    maKhoa_XML2 = node.SelectSingleNode("MA_KHOA").InnerText;
                    string[] arrMaKhoa = new string[] { maKhoa_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_MaKhoa_XML2" + ".txt", arrMaKhoa);
                }
            }
        }             

        void GetInfoXML3()
        {
            XmlDocument doc1 = new XmlDocument();
            string c = noiDungHOSOMAHOA.Substring(noiDungHOSOMAHOA.IndexOf('\n'));
            string w = noiDungHOSOMAHOA.Replace("﻿&lt;", "<").Replace("&gt;", ">");
            int index = c.ToString().LastIndexOf('\n');
            if (index >= 0)
            {
                c.Remove(index, 1);
            }

            doc1.LoadXml(c);
            //richTextBox2.Text = w;
            XmlNodeList nodeListNOIDUNGFILE = doc1.GetElementsByTagName("DSACH_CHI_TIET_DVKT");
            foreach (XmlNode nodeDSACH_CHI_TIET_DVKT in nodeListNOIDUNGFILE)
            {
                foreach (XmlNode node in nodeDSACH_CHI_TIET_DVKT.ChildNodes)
                {
                    //XmlElement nodeMaLK = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_LK") as XmlElement;
                    maLK_XML3 = node.SelectSingleNode("MA_LK").InnerText;
                    string[] arrMaLK = new string[] { maLK_XML3 };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "_Ma_LK_XML3" + ".txt", arrMaLK);

                    string STT_XML3 = node.SelectSingleNode("STT").InnerText;
                    string[] arrSTT = new string[] { STT_XML3 };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "_STT_XML3" + ".txt", arrSTT);

                    maNoiBo = node.SelectSingleNode("MA_DICH_VU").InnerText;
                    string[] arrMaNoiBo = new string[] { maNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "Manoibo_XML3" + ".txt", arrMaNoiBo);
                    //string[] arrMaNoiBo_VatTU;
                    ////XmlElement nodeMaDichVu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_DICH_VU") as XmlElement;
                    //maNoiBo = node.SelectSingleNode("MA_DICH_VU").InnerText;
                    //maVatTuNoiBo = node.SelectSingleNode("MA_VAT_TU").InnerText;
                    //if(maNoiBo =="")
                    //{
                    //    arrMaNoiBo_VatTU = new string[] { maVatTuNoiBo };
                    //    File.AppendAllLines(@"E:\XML3\" + tenfile + "Manoibo_XML3" + ".txt", arrMaNoiBo_VatTU);
                    //}
                    ////string[] arrMaNoiBo = new string[] { maNoiBo };
                    ////File.AppendAllLines(@"E:\XML3\" + tenfile + "Manoibo_XML3" + ".txt", arrMaNoiBo);
                    //if(maVatTuNoiBo=="")
                    //{
                    //    arrMaNoiBo_VatTU = new string[] { maNoiBo };
                    //    File.AppendAllLines(@"E:\XML3\" + tenfile + "Manoibo_XML3" + ".txt", arrMaNoiBo_VatTU);
                    //}
                    maVatTuNoiBo = node.SelectSingleNode("MA_VAT_TU").InnerText;
                    string[] arrMaVatTu = new string[] { maVatTuNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "MaVatTu_XML3" + ".txt", arrMaVatTu);

                    //XmlElement nodeDonGia = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/DON_GIA") as XmlElement;
                    donGia = node.SelectSingleNode("DON_GIA").InnerText;
                    string[] arrDonGia = new string[] { donGia };
                    //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "DonGia_XML3" + ".txt", arrDonGia);

                    //XmlElement nodeTenDichVu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/TEN_DICH_VU") as XmlElement;
                    tenNoiBo = node.SelectSingleNode("TEN_DICH_VU").InnerText.Replace(Environment.NewLine,"");
                    string[] arrTenNoiBo = new string[] { tenNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "Tennoibo_XML3" + ".txt", arrTenNoiBo);

                    //XmlElement nodeMaKhoa = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_KHOA") as XmlElement;
                    maKhoa = node.SelectSingleNode("MA_KHOA").InnerText;
                    string[] arrMaKhoa = new string[] { maKhoa };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "MaKhoa_XML3" + ".txt", arrMaKhoa);
                }
            }
        }

        void ReadAllXMLfromFolder()
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            string[] a;
            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fd.SelectedPath)
                                          .Where(p => p.EndsWith(".xml"))
                                          .ToArray();
                foreach (var path in files)
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(path);
                    //MessageBox.Show(xDoc.InnerXml);                    
                    a = new string[] { xDoc.InnerXml };
                    File.AppendAllLines(@"E:\" + tenfile + "_MaKhoa_XML2" + ".txt", a);
                }
            }
        }

        private void btnChinhSuaXML_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            appPath = fd.SelectedPath.ToString();
            int fileCount = Directory.GetFiles(appPath, "*.*", SearchOption.AllDirectories).Length;
            MessageBox.Show(fileCount.ToString());
            pBar.Visible = true;
            pBar.Minimum = 1;
            pBar.Maximum = fileCount;
            pBar.Value = 1;
            pBar.Step = 1;
            string[] a;
            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fd.SelectedPath)
                                          .Where(p => p.EndsWith(".xml"))
                                          .ToArray();
                for (int i = 1; i < fileCount; i++)
                {
                    foreach (var path in files)
                    {
                        //MessageBox.Show(fileCount.ToString());   
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.Load(path);
                        XmlNodeList nodeTHONGTINHOSO = xDoc.GetElementsByTagName("THONGTINHOSO");
                        string ngaylap = "";
                        foreach (XmlNode node in nodeTHONGTINHOSO)
                        {
                            ngaylap = node.SelectSingleNode("NGAYLAP").InnerText;
                        }
                        //MessageBox.Show(ngaylap);
                        string[] tenfilemoi = path.Split('\\');
                        int count_tenfilemoi = tenfilemoi.Length;                        
                        XmlNodeList nodeListHOSO = xDoc.GetElementsByTagName("HOSO");                        
                        
                        string tenfileXML = @"E:\base64toXML_Edit\" + "base64toXML" + tenfilemoi[count_tenfilemoi - 1] + ".xml"; //Ghi ra file XML mới
                        XmlTextWriter xtw = new XmlTextWriter(tenfileXML, Encoding.UTF8);
                        xtw.Formatting = Formatting.Indented;
                        xtw.WriteStartDocument();
                        xtw.WriteStartElement("GIAMDINHHS"); //Open GIAMDINHHS
                        xtw.WriteAttributeString("xmlns:xsd", null, "http://www.w3.org/2001/XMLSchema");//GIAMDINHHS
                        xtw.WriteStartElement("THONGTINDONVI"); //Open THONGTINDONVI
                        xtw.WriteElementString("MACSKCB", "79013");
                        xtw.WriteEndElement(); //Close THONGTINDONVI
                        xtw.WriteStartElement("THONGTINHOSO"); //Open THONGTINHOSO
                        xtw.WriteElementString("NGAYLAP", ngaylap);
                        xtw.WriteElementString("SOLUONGHOSO", "1");
                        xtw.WriteStartElement("DANHSACHHOSO"); //ghi ra file XML 1 node mới tên là "DANHSACHHOSO"
                        foreach (XmlNode nodeHOSO in nodeListHOSO) //duyệt tất cả các node HOSO trong danh sách HOSO
                        {
                            xtw.WriteStartElement("HOSO"); // ghi ra file XML 1 node mới tên là "HOSO"
                            foreach (XmlNode nodeFILEHOSO in nodeHOSO.ChildNodes) //duyệt tất cả các node FILEHOSO trong danh sách con của HOSO
                            {
                                loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                                noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                                noiDungHOSOMAHOA = base64ToXML(noiDungHOSO); //giải mã base64  
                                if (loaiHOSO == "XML2")
                                {
                                    GetInfoXML2();
                                }
                                if (loaiHOSO == "XML3")
                                {
                                    GetInfoXML3();
                                }

                                a = new string[] { loaiHOSO, noiDungHOSOMAHOA }; //đưa thông tin vào mảng (có thể ko cần thiết)                    
                                //root element
                                xtw.WriteStartElement("FILEHOSO"); //tạo element
                                xtw.WriteElementString("LOAIHOSO", loaiHOSO); //tạo element và nội dung
                                xtw.WriteElementString("NOIDUNGFILE", noiDungHOSOMAHOA);
                                //end root element
                                xtw.WriteEndElement();// đóng element             
                            }
                            xtw.WriteEndElement();
                        }
                        xtw.WriteEndElement();
                        xtw.WriteEndElement();//Close THONGTINHOSO                    
                        xtw.WriteElementString("CHUKYDONVI", "");
                        xtw.WriteEndElement();//Close GIAMDINHHS
                        xtw.WriteEndDocument();
                        xtw.Flush();
                        xtw.Close();
                        i++;
                        int percent = (int)(((double)pBar.Value / (double)pBar.Maximum) * 100);
                        pBar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(pBar.Width / 2 - 10, pBar.Height / 2 - 7));
                        pBar.PerformStep();
                    }                    
                }
                MessageBox.Show("Thành công");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            string[] a;
            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fd.SelectedPath)
                                          .Where(p => p.EndsWith(".xml"))
                                          .ToArray();
                foreach (var path in files)
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(path);
                    XmlNodeList nodeTHONGTINHOSO = xDoc.GetElementsByTagName("THONGTINHOSO");
                    string ngaylap = "";
                    foreach (XmlNode node in nodeTHONGTINHOSO)
                    {
                        ngaylap = node.SelectSingleNode("NGAYLAP").InnerText;
                    }
                    //MessageBox.Show(ngaylap);
                    string[] tenfilemoi = path.Split('\\');
                    XmlNodeList nodeListHOSO = xDoc.GetElementsByTagName("HOSO");
                    //MessageBox.Show(nodeListHOSO.Count.ToString());
                    //Ghi ra file XML mới
                    string tenfileXML = @"E:\XML1\" + "base64toXML" + tenfilemoi[4] + ".xml";
                    XmlTextWriter xtw = new XmlTextWriter(tenfileXML, Encoding.UTF8);
                    xtw.Formatting = Formatting.Indented;
                    xtw.WriteStartDocument();
                    xtw.WriteStartElement("GIAMDINHHS"); //Open GIAMDINHHS
                    xtw.WriteAttributeString("xmlns:xsd", null, "http://www.w3.org/2001/XMLSchema");//GIAMDINHHS
                    xtw.WriteStartElement("THONGTINDONVI"); //Open THONGTINDONVI
                    xtw.WriteElementString("MACSKCB", "79013");
                    xtw.WriteEndElement(); //Close THONGTINDONVI
                    xtw.WriteStartElement("THONGTINHOSO"); //Open THONGTINHOSO
                    xtw.WriteElementString("NGAYLAP", ngaylap);
                    xtw.WriteElementString("SOLUONGHOSO", "1");
                    xtw.WriteStartElement("DANHSACHHOSO"); //ghi ra file XML 1 node mới tên là "DANHSACHHOSO"
                    foreach (XmlNode nodeHOSO in nodeListHOSO) //duyệt tất cả các node HOSO trong danh sách HOSO
                    {
                        xtw.WriteStartElement("HOSO"); // ghi ra file XML 1 node mới tên là "HOSO"
                        foreach (XmlNode nodeFILEHOSO in nodeHOSO.ChildNodes) //duyệt tất cả các node FILEHOSO trong danh sách con của HOSO
                        {
                            loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                            noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                            noiDungHOSOMAHOA = base64ToXML(noiDungHOSO); //giải mã base64  
                            if (loaiHOSO == "XML1")
                            {
                                GetInfoXML1();

                            }
                            
                            xtw.WriteStartElement("FILEHOSO"); //tạo element
                            xtw.WriteElementString("LOAIHOSO", loaiHOSO); //tạo element và nội dung
                            xtw.WriteElementString("NOIDUNGFILE", noiDungHOSOMAHOA);
                            //end root element
                            xtw.WriteEndElement();// đóng element             
                        }
                        xtw.WriteEndElement();
                    }
                    xtw.WriteEndElement();
                    xtw.WriteEndElement();//Close THONGTINHOSO                    
                    xtw.WriteElementString("CHUKYDONVI", "");
                    xtw.WriteEndElement();//Close GIAMDINHHS
                    xtw.WriteEndDocument();
                    xtw.Flush();
                    xtw.Close();
                }
                dataGridView1.DataSource = dtXML1;
                MessageBox.Show("Thành công");
                
                
            }
        }

        private void btnShowNumberFiles_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog fd = new FolderBrowserDialog();
            //DialogResult result = fd.ShowDialog();
            //appPath = fd.SelectedPath.ToString();
            //int fileCount = Directory.GetFiles(appPath,"*.*",SearchOption.AllDirectories).Length;


            ////MessageBox.Show(appPath);
            //MessageBox.Show(fileCount.ToString());
            //pBar.Visible = true;
            //pBar.Minimum = 1;
            //pBar.Maximum = fileCount;
            //pBar.Value = 1;
            //pBar.Step = 1;
            //for (int i = 1; i < fileCount;i++)
            //{
            //    int percent = (int)(((double)pBar.Value / (double)pBar.Maximum) * 100);
            //    pBar.CreateGraphics().DrawString(percent.ToString() + "%", new Font("Arial", (float)8.25, FontStyle.Regular), Brushes.Black, new PointF(pBar.Width / 2 - 10, pBar.Height / 2 - 7));
            //    pBar.PerformStep();
            //    //lbNumberFiles.Text = pBar.Value.ToString();
            //}
            //MessageBox.Show("xong");

            
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook wb = excel.Workbooks.Open(@"E:\\abc.xlsx");
            Excel.Worksheet sh = wb.Sheets.Add();
            sh.Name = "TestSheet";
            sh.Cells[1, "A"].Value2 = "SNO";
            sh.Cells[2, "B"].Value2 = "A";
            sh.Cells[2, "C"].Value2 = "1122";
            sh.Cells[1, "A"].Value = "abc";
            //sh.Cells[
            wb.Close(true);
            excel.Quit();
        }
        
    }
}
