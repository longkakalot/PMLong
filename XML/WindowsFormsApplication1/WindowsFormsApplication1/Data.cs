using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Data
    {
        public OleDbConnection mycon;
        public OleDbDataAdapter myda;
        public DataSet myds;
        public DataTable mydt;
        private OleDbCommand mycom;
        OleDbDataReader dr = null;
        public void ketnoi()
        {
            try
            {
                mycon = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=a.accdb; Persist Security Info = False;");
                mycon.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataSet LayDulieu(string sql)
        {
            ketnoi();
            myda = new OleDbDataAdapter(sql, mycon);
            myds = new DataSet();
            myda.Fill(myds);
            ngatketnoi();
            return myds;
        }
        public void ngatketnoi()
        {
            mycon.Close();
        }
        public void command(string luusql)
        {
            mycom = new OleDbCommand(luusql, mycon);
            mycom.ExecuteNonQuery();
        }
        public void xoamyds()
        {
            myds.Clear();
        }

        public void datagrid(string all)
        {
            myda = new OleDbDataAdapter(all, mycon);
            myds = new DataSet();
            myda.Fill(myds, "Tour");
            mydt = myds.Tables["Tour"];
        }

    }
}

