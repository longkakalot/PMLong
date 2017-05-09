namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGetInfoXML1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgvInfoXML = new System.Windows.Forms.DataGridView();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.btnGetInfoXML2 = new System.Windows.Forms.Button();
            this.btnGetInfoXML3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInfoXML)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1174, 68);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnGetInfoXML3);
            this.tabPage1.Controls.Add(this.btnGetInfoXML2);
            this.tabPage1.Controls.Add(this.btnGetInfoXML1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1166, 42);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "XML";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGetInfoXML1
            // 
            this.btnGetInfoXML1.Location = new System.Drawing.Point(7, 7);
            this.btnGetInfoXML1.Name = "btnGetInfoXML1";
            this.btnGetInfoXML1.Size = new System.Drawing.Size(88, 23);
            this.btnGetInfoXML1.TabIndex = 0;
            this.btnGetInfoXML1.Text = "GetInfoXML1";
            this.btnGetInfoXML1.UseVisualStyleBackColor = true;
            this.btnGetInfoXML1.Click += new System.EventHandler(this.btnGetInfoXML1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1166, 42);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgvInfoXML
            // 
            this.dtgvInfoXML.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvInfoXML.Location = new System.Drawing.Point(5, 111);
            this.dtgvInfoXML.Name = "dtgvInfoXML";
            this.dtgvInfoXML.Size = new System.Drawing.Size(1161, 453);
            this.dtgvInfoXML.TabIndex = 1;
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(441, 74);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(432, 23);
            this.pBar.TabIndex = 2;
            this.pBar.Visible = false;
            // 
            // btnGetInfoXML2
            // 
            this.btnGetInfoXML2.Location = new System.Drawing.Point(102, 7);
            this.btnGetInfoXML2.Name = "btnGetInfoXML2";
            this.btnGetInfoXML2.Size = new System.Drawing.Size(98, 23);
            this.btnGetInfoXML2.TabIndex = 1;
            this.btnGetInfoXML2.Text = "GetInfoXML2";
            this.btnGetInfoXML2.UseVisualStyleBackColor = true;
            this.btnGetInfoXML2.Click += new System.EventHandler(this.btnGetInfoXML2_Click);
            // 
            // btnGetInfoXML3
            // 
            this.btnGetInfoXML3.Location = new System.Drawing.Point(207, 7);
            this.btnGetInfoXML3.Name = "btnGetInfoXML3";
            this.btnGetInfoXML3.Size = new System.Drawing.Size(103, 23);
            this.btnGetInfoXML3.TabIndex = 2;
            this.btnGetInfoXML3.Text = "GetInfoXML3";
            this.btnGetInfoXML3.UseVisualStyleBackColor = true;
            this.btnGetInfoXML3.Click += new System.EventHandler(this.btnGetInfoXML3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 669);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.dtgvInfoXML);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInfoXML)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnGetInfoXML1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dtgvInfoXML;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button btnGetInfoXML2;
        private System.Windows.Forms.Button btnGetInfoXML3;
    }
}

