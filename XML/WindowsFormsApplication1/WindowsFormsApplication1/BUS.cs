using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class BUS
    {
        Data da = new Data();

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

        //public string doiMaNoiBo_VatTu()
        //{
        //    string a = "";
        //    DataTable d = LayTenVatTuTuongDuong(maVatTuNoiBo);
        //    if (d != null && d.Rows.Count > 0)
        //    {
        //        dataGridView1.DataSource = d;
        //        a = dataGridView1.Rows[0].Cells[0].Value.ToString();
        //        return a;
        //    }
        //    else
        //    {
        //        string[] b = new string[] { maVatTuNoiBo };
        //        //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
        //        File.AppendAllLines(@"E:\" + tenfile + "vattu" + ".txt", b);
        //        //File.AppendAllText(@"D:\path.txt", maNoiBo);
        //        //MessageBox.Show("Thiếu mã tương đương: " + maNoiBo);
        //        return maVatTuNoiBo;
        //    }
        //}
        //public string doiMaNoiBo()
        //{
        //    string a = "";
        //    DataTable d = LayMaTuongDuong(maNoiBo);
        //    if (d != null && d.Rows.Count > 0)
        //    {
        //        dataGridView1.DataSource = d;
        //        a = dataGridView1.Rows[0].Cells[0].Value.ToString();
        //        MessageBox.Show(a);
        //        return a;
        //    }
        //    else
        //    {
        //        string[] b = new string[] { maNoiBo, maVatTuNoiBo };
        //        File.AppendAllLines(@"E:\" + tenfile + ".txt", b);
        //        return maNoiBo;
        //    }
        //}
        //public string doiTenNoiBo()
        //{
        //    string a = "";
        //    DataTable d = LayTenTuongDuong(maNoiBo);
        //    if (d != null && d.Rows.Count > 0)
        //    {
        //        dataGridView1.DataSource = d;
        //        a = dataGridView1.Rows[0].Cells[0].Value.ToString();
        //        return a;
        //    }
        //    else
        //    {
        //        string[] b = new string[] { tenNoiBo };
        //        //string b = File.WriteAllText(@"D:\path.txt", maNoiBo);
        //        File.AppendAllLines(@"E:\" + tenfile + "tennoibo" + ".txt", b);
        //        //MessageBox.Show(tenNoiBo);
        //        //File.AppendAllText(@"D:\path.txt", maNoiBo);
        //        //MessageBox.Show("Thiếu mã tương đương: " + maNoiBo);
        //        //MessageBox.Show("Thiếu tên tương đương: " + tenNoiBo);
        //        return tenNoiBo;
        //    }
        //}
    }
}
