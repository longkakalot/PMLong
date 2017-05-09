using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace WindowsFormsApplication1.BUS
{
    public class BUS_XML
    {
        string noiDungHOSOMAHOA = "";
        string tenfile = "";

        //Tạo file CSV
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
        public string XMLtoBase64(string s)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));
        }
        public string base64ToXML(string s)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(s));
        }

        //Lấy thông tin XML
        public void LayThongTinXML(string path, string loaiHS, DataTable dt)
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
                    string loaiHOSO = nodeFILEHOSO.FirstChild.InnerText; //lấy ra thông tin của node con đầu tiên trong FILEHOSO
                    string noiDungHOSO = nodeFILEHOSO.LastChild.InnerText; //lấy ra thông tin của node con cuối cùng trong FILEHOSO
                    noiDungHOSOMAHOA = base64ToXML(noiDungHOSO); //giải mã base64  
                    if (loaiHOSO == loaiHS)
                    {
                        GetInfoXML1(dt);
                    }
                    if (loaiHOSO == loaiHS)
                    {
                        GetInfoXML2(dt);
                    }
                    if (loaiHOSO == loaiHS)
                    {
                        GetInfoXML3(dt);
                    }
                }
            }
        }

        public string GetInfo()
        {            
            string loadXml = noiDungHOSOMAHOA.Substring(noiDungHOSOMAHOA.IndexOf('\n'));
            //string d = noiDungHOSOMAHOA.Replace("﻿&lt;", "<").Replace("&gt;", ">");
            int index = loadXml.ToString().LastIndexOf('\n');
            if (index >= 0)
            {
                loadXml.Remove(index, 1);
            }
            return loadXml;
        }

        public DataTable GetInfoXML1(DataTable dtXML1)
        {            
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(GetInfo());            
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
            return dtXML1;
        }

        public DataTable GetInfoXML2(DataTable dtXML2)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(GetInfo());
            XmlNodeList nodeListNOIDUNGFILE = doc1.GetElementsByTagName("DSACH_CHI_TIET_THUOC");

            foreach (XmlNode nodeDSACH_CHI_TIET_THUOC in nodeListNOIDUNGFILE)
            {
                foreach (XmlNode node in nodeDSACH_CHI_TIET_THUOC.ChildNodes)
                {
                    //XmlElement nodeMaLK = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_LK") as XmlElement;
                    string maLK_XML2 = node.SelectSingleNode("MA_LK").InnerText;
                    string[] arrMaLK = new string[] { maLK_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_Ma_LK_XML2" + ".txt", arrMaLK);

                    //XmlElement nodeSTT = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/STT") as XmlElement;
                    string STT_XML2 = node.SelectSingleNode("STT").InnerText;
                    string[] arrSTT = new string[] { STT_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_STT_XML2" + ".txt", arrSTT);

                    //XmlElement nodeMaThuoc = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_THUOC") as XmlElement;
                    string maThuoc = node.SelectSingleNode("MA_THUOC").InnerText;
                    string[] arrMaThuoc = new string[] { maThuoc };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_Ma_Thuoc_XML2" + ".txt", arrMaThuoc);

                    //XmlElement nodeTenThuoc = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/TEN_THUOC") as XmlElement;
                    string tenThuoc = node.SelectSingleNode("TEN_THUOC").InnerText;
                    string[] arrtenThuoc = new string[] { tenThuoc };
                    //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_Ten_Thuoc_XML2" + ".txt", arrtenThuoc);

                    //XmlElement nodeDonGia = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/DON_GIA") as XmlElement;
                    string donGia_XML2 = node.SelectSingleNode("DON_GIA").InnerText;
                    string[] arrDonGia = new string[] { donGia_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_DonGia_XML2" + ".txt", arrDonGia);

                    //XmlElement nodeMaKhoa = doc1.SelectSingleNode("/DSACH_CHI_TIET_THUOC/CHI_TIET_THUOC/MA_KHOA") as XmlElement;
                    string maKhoa_XML2 = node.SelectSingleNode("MA_KHOA").InnerText;
                    string[] arrMaKhoa = new string[] { maKhoa_XML2 };
                    File.AppendAllLines(@"E:\XML2\" + tenfile + "_MaKhoa_XML2" + ".txt", arrMaKhoa);

                    DataRow dr = dtXML2.NewRow();
                    dr["MA_LK"] = maLK_XML2;
                    dr["STT"] = STT_XML2;
                    dr["MA_THUOC"] = maThuoc;
                    dr["TEN_THUOC"] = tenThuoc;
                    dr["DON_GIA"] = donGia_XML2;
                    dr["MA_KHOA"] = maKhoa_XML2;
                    dtXML2.Rows.Add(dr);
                }               
            }
            return dtXML2;
        }

        public DataTable GetInfoXML3(DataTable dtXML1)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(GetInfo());
            XmlNodeList nodeListNOIDUNGFILE = doc1.GetElementsByTagName("DSACH_CHI_TIET_DVKT");
            foreach (XmlNode nodeDSACH_CHI_TIET_DVKT in nodeListNOIDUNGFILE)
            {
                foreach (XmlNode node in nodeDSACH_CHI_TIET_DVKT.ChildNodes)
                {
                    //XmlElement nodeMaLK = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_LK") as XmlElement;
                    string maLK_XML3 = node.SelectSingleNode("MA_LK").InnerText;
                    string[] arrMaLK = new string[] { maLK_XML3 };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "_Ma_LK_XML3" + ".txt", arrMaLK);

                    string STT_XML3 = node.SelectSingleNode("STT").InnerText;
                    string[] arrSTT = new string[] { STT_XML3 };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "_STT_XML3" + ".txt", arrSTT);

                    string maNoiBo = node.SelectSingleNode("MA_DICH_VU").InnerText;
                    string[] arrMaNoiBo = new string[] { maNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "Manoibo_XML3" + ".txt", arrMaNoiBo);

                    string maVatTuNoiBo = node.SelectSingleNode("MA_VAT_TU").InnerText;
                    string[] arrMaVatTu = new string[] { maVatTuNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "MaVatTu_XML3" + ".txt", arrMaVatTu);

                    //XmlElement nodeDonGia = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/DON_GIA") as XmlElement;
                    string donGia = node.SelectSingleNode("DON_GIA").InnerText;
                    string[] arrDonGia = new string[] { donGia };
                    //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "DonGia_XML3" + ".txt", arrDonGia);

                    //XmlElement nodeTenDichVu = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/TEN_DICH_VU") as XmlElement;
                    string tenNoiBo = node.SelectSingleNode("TEN_DICH_VU").InnerText.Replace(Environment.NewLine, "");
                    string[] arrTenNoiBo = new string[] { tenNoiBo };
                    File.AppendAllLines(@"E:\XML3\" + tenfile + "Tennoibo_XML3" + ".txt", arrTenNoiBo);

                    //XmlElement nodeMaKhoa = doc1.SelectSingleNode("/DSACH_CHI_TIET_DVKT/CHI_TIET_DVKT/MA_KHOA") as XmlElement;
                    string maKhoa = node.SelectSingleNode("MA_KHOA").InnerText;
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
            return dtXML1;
        }
    }
}
