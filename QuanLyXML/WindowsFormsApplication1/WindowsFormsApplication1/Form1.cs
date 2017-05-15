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
using WindowsFormsApplication1.BUS;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        BUS_XML busXml = new BUS_XML();
        string filenameXML1 = @"E:\\XML1\\" + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";
        string filenameXML2 = @"E:\\XML2\\" + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";
        string filenameXML3 = @"E:\\XML3\\" + "_" + DateTime.Now.ToString("MM_dd_yyyy") + ".csv";

        public Form1()
        {
            InitializeComponent();
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

        private void btnGetInfoXML1_Click(object sender, EventArgs e)
        {
            DataTable dtXML1 = new DataTable();
            dtXML1.Columns.Add("MA_LK");
            dtXML1.Columns.Add("MA_BN");
            dtXML1.Columns.Add("HO_TEN");
            dtXML1.Columns.Add("TEN_BENH");
            dtXML1.Columns.Add("MA_BENH");
            dtXML1.Columns.Add("MA_BENHKHAC");
            dtXML1.Columns.Add("NGAY_VAO");
            dtXML1.Columns.Add("NGAY_RA");
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
                        busXml.LayThongTinXML(path, "XML1", dtXML1);
                        showPercentInProgressBar();
                        i++;
                    }
                }
            }            
            dtgvInfoXML.DataSource = busXml.GetInfoXML1(dtXML1);
            busXml.CreateCSVFile(dtXML1, filenameXML1);            
        }

        private void btnGetInfoXML2_Click(object sender, EventArgs e)
        {
            DataTable dtXML2 = new DataTable();
            dtXML2.Columns.Add("MA_LK");
            dtXML2.Columns.Add("STT");
            dtXML2.Columns.Add("MA_THUOC");
            dtXML2.Columns.Add("TEN_THUOC");
            dtXML2.Columns.Add("DON_GIA");
            dtXML2.Columns.Add("MA_KHOA");
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
                        busXml.LayThongTinXML(path, "XML2", dtXML2);
                        showPercentInProgressBar();
                        i++;
                    }
                }
            }            
            dtgvInfoXML.DataSource = busXml.GetInfoXML2(dtXML2);
            busXml.CreateCSVFile(dtXML2, filenameXML2);
        }

        private void btnGetInfoXML3_Click(object sender, EventArgs e)
        {
            DataTable dtXML1 = new DataTable();
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
                        busXml.LayThongTinXML(path, "XML3", dtXML1);
                        showPercentInProgressBar();
                        i++;
                    }
                }
            }            
            dtgvInfoXML.DataSource = busXml.GetInfoXML2(dtXML1);
            busXml.CreateCSVFile(dtXML1, filenameXML3);
        }
    }
}
