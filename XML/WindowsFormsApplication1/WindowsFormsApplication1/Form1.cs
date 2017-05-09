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


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        XML xml = new XML();
        Data da = new Data();
        DataTable dtXML1 = new DataTable();
        string filenameXML1 = @"E:\\XML1\\" + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";
        string filenameXML2 = @"E:\\XML2\\" + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";
        string filenameXML3 = @"E:\\XML3\\" + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";
        XmlDocument doc = new XmlDocument();
        string tenfile = "";
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
        string STT_XML2 = "";
        string STT_XML3 = "";
        string maLK_XML2 = "";
        string maLK_XML1 = "";
        string maBN_XML1 = "";
        string hoTenBN_XML1 = "";
        string tenBenh_XML1 = "";
        string maBenh_XML1 = "";
        string maBenhKhac_XML1 = "";
        string[] a;
        string[] tenfilemoi;
        int count = 0;

        #region Hàm
        
        
        
        

        //void GetInfoXML1()
        //{
        //    XmlDocument doc1 = new XmlDocument();
        //    string c = noiDungHOSOMAHOA.Substring(noiDungHOSOMAHOA.IndexOf('\n'));
        //    string d = noiDungHOSOMAHOA.Replace("﻿&lt;", "<").Replace("&gt;", ">");

        //    int index = c.ToString().LastIndexOf('\n');
        //    if (index >= 0)
        //    {
        //        c.Remove(index, 1);
        //    }

        //    doc1.LoadXml(c);
        //    XmlNodeList nodeListNOIDUNGFILE = doc1.GetElementsByTagName("TONG_HOP");

        //    foreach (XmlNode node in nodeListNOIDUNGFILE)
        //    {
        //        //XmlElement nodeMaLK = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_LK") as XmlElement;
        //        maLK_XML1 = node.SelectSingleNode("MA_LK").InnerText;
        //        string[] arrMaLK = new string[] { maLK_XML1 };
        //        File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_LK_XML1" + ".txt", arrMaLK);

        //        maBN_XML1 = node.SelectSingleNode("MA_BN").InnerText;
        //        string[] arrMaBN = new string[] { maBN_XML1 };
        //        File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_BN_XML1" + ".txt", arrMaBN);

        //        hoTenBN_XML1 = node.SelectSingleNode("HO_TEN").InnerText;
        //        string[] arrHoTen = new string[] { hoTenBN_XML1 };
        //        File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ho_Ten_XML1" + ".txt", arrHoTen);

        //        tenBenh_XML1 = node.SelectSingleNode("TEN_BENH").InnerText;
        //        string[] arrTenBenh = new string[] { tenBenh_XML1 };
        //        File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ten_Benh_XML1" + ".txt", arrTenBenh);

        //        maBenh_XML1 = node.SelectSingleNode("MA_BENH").InnerText;
        //        string[] arrMaBenh = new string[] { maBenh_XML1 };
        //        File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_Benh_XML1" + ".txt", arrMaBenh);

        //        maBenhKhac_XML1 = node.SelectSingleNode("MA_BENHKHAC").InnerText;
        //        string[] arrMaBenhKhac = new string[] { maBenhKhac_XML1 };
        //        File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_BenhKhac_XML1" + ".txt", arrMaBenhKhac);

        //        DataRow dr = dtXML1.NewRow();
        //        dr["MA_LK"] = maLK_XML1;
        //        dr["MA_BN"] = maBN_XML1;
        //        dr["HO_TEN"] = hoTenBN_XML1;
        //        dr["TEN_BENH"] = tenBenh_XML1;
        //        dr["MA_BENH"] = maBenh_XML1;
        //        dr["MA_BENHKHAC"] = maBenhKhac_XML1;
        //        dtXML1.Rows.Add(dr);
        //    }
        //}
        
        
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
            doc1.LoadXml(c);
            XmlNodeList nodeListNOIDUNGFILE = doc1.GetElementsByTagName("DSACH_CHI_TIET_THUOC");
            foreach (XmlNode nodeDSACH_CHI_TIET_THUOC in nodeListNOIDUNGFILE)
            {
                foreach (XmlNode node in nodeDSACH_CHI_TIET_THUOC.ChildNodes)
                {
                    //XmlElement nodeMaLK = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_LK") as XmlElement;
                    maLK_XML2 = node.SelectSingleNode("MA_LK").InnerText;
                    string[] arrMaLK = new string[] { maLK_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_Ma_LK_XML2" + ".txt", arrMaLK);

                    //XmlElement nodeSTT = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/STT") as XmlElement;
                    STT_XML2 = node.SelectSingleNode("STT").InnerText;
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

                    DataRow dr = dtXML1.NewRow();
                    dr["MA_LK"] = maLK_XML2;
                    dr["STT"] = STT_XML2;
                    dr["MA_THUOC"] = maThuoc;
                    dr["TEN_THUOC"] = tenThuoc;
                    dr["DON_GIA"] = donGia_XML2;
                    dr["MA_KHOA"] = maKhoa_XML2;
                    dtXML1.Rows.Add(dr);
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

                    STT_XML3 = node.SelectSingleNode("STT").InnerText;
                    string[] arrSTT = new string[] { STT_XML3 };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "_STT_XML3" + ".txt", arrSTT);

                    maNoiBo = node.SelectSingleNode("MA_DICH_VU").InnerText;
                    string[] arrMaNoiBo = new string[] { maNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "Manoibo_XML3" + ".txt", arrMaNoiBo);

                    maVatTuNoiBo = node.SelectSingleNode("MA_VAT_TU").InnerText;
                    string[] arrMaVatTu = new string[] { maVatTuNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "MaVatTu_XML3" + ".txt", arrMaVatTu);

                    //XmlElement nodeDonGia = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/DON_GIA") as XmlElement;
                    donGia = node.SelectSingleNode("DON_GIA").InnerText;
                    string[] arrDonGia = new string[] { donGia };
                    //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "DonGia_XML3" + ".txt", arrDonGia);

                    //XmlElement nodeTenDichVu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/TEN_DICH_VU") as XmlElement;
                    tenNoiBo = node.SelectSingleNode("TEN_DICH_VU").InnerText.Replace(Environment.NewLine, "");
                    string[] arrTenNoiBo = new string[] { tenNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "Tennoibo_XML3" + ".txt", arrTenNoiBo);

                    //XmlElement nodeMaKhoa = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_KHOA") as XmlElement;
                    maKhoa = node.SelectSingleNode("MA_KHOA").InnerText;
                    string[] arrMaKhoa = new string[] { maKhoa };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "MaKhoa_XML3" + ".txt", arrMaKhoa);
                    DataRow dr = dtXML1.NewRow();
                    dr["MA_LK"] = maLK_XML3;
                    dr["STT"] = STT_XML3;
                    dr["MA_DICH_VU"] = maNoiBo;
                    dr["MA_VAT_TU"] = maVatTuNoiBo;
                    dr["DON_GIA"] = donGia;
                    dr["TEN_DICH_VU"] = tenNoiBo;
                    dr["MA_KHOA"] = maKhoa;
                    dtXML1.Rows.Add(dr);
                }
            }
        }
        //Lấy mã dịch vụ tương đương
        public string GetMaDichVu(string maLK, string STT)
        {
            string sql = "SELECT MaTuongDuong FROM Sheet1 Where Ma_LK = '" + maLK + "' and STT = '" + STT + "'";
            string maDVKT = "";
            DataTable dt = da.LayDulieu(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                maDVKT = dr["MaTuongDuong"].ToString();
                count++;
                return maDVKT;
            }
            else
            {
                string[] arrmaNoiBo = { maNoiBo };
                File.AppendAllLines(@"E:\Thieu\" + "_MaNoiBo" + ".txt", arrmaNoiBo);
                string[] arrmaLK = { maLK_XML3 };
                File.AppendAllLines(@"E:\Thieu\" + "_MaLK" + ".txt", arrmaLK);
                string[] arrSTT = { STT_XML3 };
                File.AppendAllLines(@"E:\Thieu\" + "_STT" + ".txt", arrSTT);
                string[] arrmaVatTu = { maVatTuNoiBo };
                File.AppendAllLines(@"E:\Thieu\" + "_MaVatTu" + ".txt", arrmaVatTu);
                return maNoiBo;
            }
        }

        //Lấy mã vật tư mới (nếu có)
        public string GetMaVatTu(string maLK, string STT)
        {
            string sql = "SELECT Ma_Vat_Tu FROM Sheet1 Where Ma_LK = '" + maLK + "' and STT = '" + STT + "'";
            string maDVKT = "";
            DataTable dt = da.LayDulieu(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                maDVKT = dr["Ma_Vat_Tu"].ToString();
                //count++;
                return maDVKT;
            }
            else
            {
                string[] arrMaVatTu = { maVatTuNoiBo };
                File.AppendAllLines(@"E:\Thieu\" + "thieuMaVatTu" + ".txt", arrMaVatTu);
                return maVatTuNoiBo;
            }
        }

        //Lấy tên dịch vụ tương đương
        public string GetTenDichVu(string maLK, string STT)
        {
            string sql = "SELECT TenTuongDuong FROM Sheet1 Where Ma_LK = '" + maLK + "' and STT = '" + STT + "'";
            string maDVKT = "";
            DataTable dt = da.LayDulieu(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                maDVKT = dr["TenTuongDuong"].ToString();
                //count++;
                return maDVKT;
            }
            else
            {
                string[] arrtenNoiBo = { tenNoiBo };
                File.AppendAllLines(@"E:\Thieu\" + "thieuTenNoiBo" + ".txt", arrtenNoiBo);
                return tenNoiBo;
            }
        }
        void ConvertXML3()
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

            XmlNodeList nodeListNOIDUNGFILE = doc1.GetElementsByTagName("DSACH_CHI_TIET_DVKT");
            foreach (XmlNode nodeDSACH_CHI_TIET_DVKT in nodeListNOIDUNGFILE)
            {
                foreach (XmlNode node in nodeDSACH_CHI_TIET_DVKT.ChildNodes)
                {
                    maLK_XML3 = node.SelectSingleNode("MA_LK").InnerText;
                    STT_XML3 = node.SelectSingleNode("STT").InnerText;
                    string tendichvu1 = "<![CDATA[";
                    string tendichvu2 = "]]>";
                    string headerXML3 = "<?xml version=\"" + "1.0\"" + " encoding=\"" + "utf-8\"" + " ?>";

                    XmlElement nodeMaDichVu = node.SelectSingleNode("MA_DICH_VU") as XmlElement;
                    maNoiBo = node.SelectSingleNode("MA_DICH_VU").InnerText;
                    nodeMaDichVu.InnerText = GetMaDichVu(maLK_XML3, STT_XML3);

                    XmlElement nodeMaVatTu = node.SelectSingleNode("MA_VAT_TU") as XmlElement;
                    maVatTuNoiBo = node.SelectSingleNode("MA_VAT_TU").InnerText;
                    nodeMaVatTu.InnerText = GetMaVatTu(maLK_XML3, STT_XML3);

                    XmlElement nodeTenDichVu = node.SelectSingleNode("TEN_DICH_VU") as XmlElement;
                    tenNoiBo = node.SelectSingleNode("TEN_DICH_VU").InnerText;
                    nodeTenDichVu.InnerText = tendichvu1 + GetTenDichVu(maLK_XML3, STT_XML3) + tendichvu2;

                    string noidungXML3 = (headerXML3 + doc1.InnerXml).Replace("&lt;", "<").Replace("&gt;", ">");
                    XmlDocument d = new XmlDocument();
                    d.LoadXml(noidungXML3);
                    StringWriter sw = new StringWriter();
                    XmlTextWriter xtw = new XmlTextWriter(sw);
                    xtw.Formatting = Formatting.Indented;
                    d.WriteTo(xtw);
                    noiDungHOSOMAHOA = sw.ToString();
                }
            }
        }

        //Create file CSV
        public void CreateCSVFile(DataTable dt, string strFilePath)
        {
            try
            {
                StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
                int columnCount = dt.Columns.Count;

                for (int i = 0; i < columnCount; i++)
                {
                    sw.Write(dt.Columns[i]);

                    if (i < columnCount - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }

                        if (i < columnCount - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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

        #endregion


        #region Events
        //Convert Base64 to XML
        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            xml.OpenXML(doc);
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
                    noiDungHOSOMAHOA = xml.base64ToXML(noiDungHOSO); //giải mã base64                    
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

        //Convert XML to Base64
        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            xml.OpenXML(doc);
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
                    noiDungHOSOMAHOA = xml.XMLtoBase64(noiDungHOSO); //giải mã base64
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
        //Đổi mã XML3
        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            xml.OpenXML(doc);
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
                    noiDungHOSOMAHOA = xml.base64ToXML(noiDungHOSO); //giải mã base64                    
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
                        XmlElement nodeMaDichVu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_DICH_VU") as XmlElement;
                        maNoiBo = nodeMaDichVu.InnerText;                        
                        //nodeMaDichVu.InnerText = doiMaNoiBo();                        

                        XmlElement nodeMaVatTu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_VAT_TU") as XmlElement;
                        maVatTuNoiBo = nodeMaVatTu.InnerText;
                        MessageBox.Show(maVatTuNoiBo);
                        //nodeMaVatTu.InnerText = doiMaNoiBo_VatTu();                        

                        XmlElement nodeTenDichVu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/TEN_DICH_VU") as XmlElement;
                        tenNoiBo = nodeTenDichVu.InnerText;                        
                        string tendichvu1 = "<![CDATA[";
                        string tendichvu2 = "]]";
                        //nodeTenDichVu.InnerText = tendichvu1 + doiTenNoiBo() + tendichvu2;
                        string headerXML3 = "<?xml version=\"" + "1.0\"" + " encoding=\"" + "utf-8\"" + " ?>";                        
                        string noidungXML3 = doc1.InnerXml;
                        noiDungHOSOMAHOA = (headerXML3 + noidungXML3).Replace("&lt;", "<");
                        //MessageBox.Show(noiDungHOSOMAHOA);
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


        private void btnChinhSuaXML_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            string tenfileXML = "";
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
                    tenfilemoi = path.Split('\\');
                    XmlNodeList nodeListHOSO = xDoc.GetElementsByTagName("HOSO");
                    //MessageBox.Show(nodeListHOSO.Count.ToString());
                    //Ghi ra file XML mới
                    tenfileXML = @"E:\base64toXML_Edit\" + "base64toXML" + tenfilemoi[4] + ".xml";
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
                            noiDungHOSOMAHOA = xml.base64ToXML(noiDungHOSO); //giải mã base64  
                            if (loaiHOSO == "XML2")
                            {
                                //GetInfoXML2();
                            }
                            if (loaiHOSO == "XML3")
                            {
                                ConvertXML3();
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
                }
                MessageBox.Show("Thành công");
            }
        }

        void progressBarInfo(FolderBrowserDialog fd)
        {
            int countFileXML = Directory.GetFiles(fd.SelectedPath).Length;
            pBar.Visible = true;
            pBar.Maximum = countFileXML;
            pBar.Minimum = 1;
            pBar.Value = 1;
            pBar.Step = 1;
        }

        void showPercentInProgressBar()
        {
            int percent = (int)(((double)(pBar.Value - pBar.Minimum) / (double)(pBar.Maximum - pBar.Minimum)) * 100);
            using (Graphics gr = pBar.CreateGraphics())
            {
                gr.DrawString(percent.ToString() + "%",
                    SystemFonts.DefaultFont,
                    Brushes.Black,
                    new PointF(pBar.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                        SystemFonts.DefaultFont).Width / 2.0F),
                    pBar.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }
            pBar.PerformStep();
        }
        
        //Lấy thông tin XML
        public void LayThongTinXML(string path, string loaiHS)
        {
            //DataTable dtLayThongtin = new DataTable();
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
                    string loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                    string noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                    noiDungHOSOMAHOA = xml.base64ToXML(noiDungHOSO); //giải mã base64  
                    if (loaiHOSO == loaiHS)
                    {
                        GetInfoXML1();                        
                    }
                    if (loaiHOSO == loaiHS)
                    {
                        GetInfoXML2();
                    }
                    if (loaiHOSO == loaiHS)
                    {
                        GetInfoXML3();
                    }
                }
            }        
        }

        public void GetInfoXML1()
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
                string maLK_XML1 = node.SelectSingleNode("MA_LK").InnerText;
                string[] arrMaLK = new string[] { maLK_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_LK_XML1" + ".txt", arrMaLK);

                string maBN_XML1 = node.SelectSingleNode("MA_BN").InnerText;
                string[] arrMaBN = new string[] { maBN_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_BN_XML1" + ".txt", arrMaBN);

                string hoTenBN_XML1 = node.SelectSingleNode("HO_TEN").InnerText;
                string[] arrHoTen = new string[] { hoTenBN_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ho_Ten_XML1" + ".txt", arrHoTen);

                string tenBenh_XML1 = node.SelectSingleNode("TEN_BENH").InnerText;
                string[] arrTenBenh = new string[] { tenBenh_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ten_Benh_XML1" + ".txt", arrTenBenh);

                string maBenh_XML1 = node.SelectSingleNode("MA_BENH").InnerText;
                string[] arrMaBenh = new string[] { maBenh_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_Benh_XML1" + ".txt", arrMaBenh);

                string maBenhKhac_XML1 = node.SelectSingleNode("MA_BENHKHAC").InnerText;
                string[] arrMaBenhKhac = new string[] { maBenhKhac_XML1 };
                File.AppendAllLines(@"E:\XML1\" + tenfile + "_Ma_BenhKhac_XML1" + ".txt", arrMaBenhKhac);

                DataRow dr = dtXML1.NewRow();
                dr["MA_LK"] = maLK_XML1;
                dr["MA_BN"] = maBN_XML1;
                dr["HO_TEN"] = hoTenBN_XML1;
                dr["TEN_BENH"] = tenBenh_XML1;
                dr["MA_BENH"] = maBenh_XML1;
                dr["MA_BENHKHAC"] = maBenhKhac_XML1;
                dtXML1.Rows.Add(dr);
            }
            
        }
        //GetInfoXML1
        private void button6_Click(object sender, EventArgs e)
        {
            dtXML1.Columns.Add("MA_LK");
            dtXML1.Columns.Add("MA_BN");
            dtXML1.Columns.Add("HO_TEN");
            dtXML1.Columns.Add("TEN_BENH");
            dtXML1.Columns.Add("MA_BENH");
            dtXML1.Columns.Add("MA_BENHKHAC");
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            int countFileXML = Directory.GetFiles(fd.SelectedPath).Length;            
            progressBarInfo(fd);
            //string noiDungHSMahoa ="";
            //var path;
            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fd.SelectedPath)
                                          .Where(p => p.EndsWith(".xml"))
                                          .ToArray();
                //string path;
                for (int i = 1; i <= countFileXML; i++)
                {                    
                    foreach (var path in files)
                    {
                        LayThongTinXML(path,"XML1");                        
                        showPercentInProgressBar();
                        i++;                        
                    }                    
                }                
            }
            //dtXML1 = XML.LayThongTinXML("a", "XML1");
            dataGridView1.DataSource = dtXML1;
            CreateCSVFile(dtXML1, filenameXML1);
                MessageBox.Show("Thành công");
        }


        private void button7_Click(object sender, EventArgs e)
        {
            string malk = "160901095425256770015";
            string stt = "651";
            string a = GetMaDichVu(malk, stt);
            MessageBox.Show(a);
        }

        private void btnXMLtoBase64_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            string tenfileXML = "";            
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
                    tenfilemoi = path.Split('\\');
                    XmlNodeList nodeListHOSO = xDoc.GetElementsByTagName("HOSO");
                    //MessageBox.Show(nodeListHOSO.Count.ToString());
                    //Ghi ra file XML mới
                    tenfileXML = @"E:\XMLtoBase64_Edit\" + "XMLtoBase64" + tenfilemoi[2] + ".xml";
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

                            noiDungHOSOMAHOA = xml.XMLtoBase64(noiDungHOSO); //mã hóa base64                              

                            xtw.WriteStartElement("FILEHOSO"); //tạo element
                            xtw.WriteElementString("LOAIHOSO", loaiHOSO); //tạo element và nội dung
                            xtw.WriteElementString("NOIDUNGFILE", "77u/" + noiDungHOSOMAHOA);
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
                MessageBox.Show("Thành công");
            }
        }

        private void btnGetInfoXML23_Click(object sender, EventArgs e)
        {
            dtXML1.Columns.Add("MA_LK");
            dtXML1.Columns.Add("STT");
            dtXML1.Columns.Add("MA_THUOC");
            dtXML1.Columns.Add("TEN_THUOC");
            dtXML1.Columns.Add("DON_GIA");
            dtXML1.Columns.Add("MA_KHOA");
            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            int countFileXML = Directory.GetFiles(fd.SelectedPath).Length;
            progressBarInfo(fd);

            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fd.SelectedPath)
                                          .Where(p => p.EndsWith(".xml"))
                                          .ToArray();
                for (int i = 1; i <= countFileXML; i++)
                {
                    foreach (var path in files)
                    {
                        LayThongTinXML(path,"XML2");
                        showPercentInProgressBar();
                        i++;
                    }
                }
                dataGridView1.DataSource = dtXML1;
                CreateCSVFile(dtXML1, filenameXML2);
                MessageBox.Show("Thành công");
            }        
        }

        private void btnGetInfoXML3_Click(object sender, EventArgs e)
        {
            dtXML1.Columns.Add("MA_LK");
            dtXML1.Columns.Add("STT");
            dtXML1.Columns.Add("MA_DICH_VU");
            dtXML1.Columns.Add("MA_VAT_TU");
            dtXML1.Columns.Add("DON_GIA");
            dtXML1.Columns.Add("TEN_DICH_VU");
            dtXML1.Columns.Add("MA_KHOA");

            FolderBrowserDialog fd = new FolderBrowserDialog();
            DialogResult result = fd.ShowDialog();
            int countFileXML = Directory.GetFiles(fd.SelectedPath).Length;
            progressBarInfo(fd);

            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(fd.SelectedPath)
                                          .Where(p => p.EndsWith(".xml"))
                                          .ToArray();
                for (int i = 1; i <= countFileXML; i++)
                {
                    foreach (var path in files)
                    {
                        LayThongTinXML(path, "XML3");
                        showPercentInProgressBar();
                        i++;
                    }
                }
                dataGridView1.DataSource = dtXML1;
                CreateCSVFile(dtXML1, filenameXML3);
                MessageBox.Show("Thành công");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
        }
        #endregion




    }
}
