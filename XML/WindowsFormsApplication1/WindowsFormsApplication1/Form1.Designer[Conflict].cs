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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGetInfoXML23 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnChinhSuaXML = new System.Windows.Forms.Button();
            this.btnXML1 = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnShowNumberFiles = new System.Windows.Forms.Button();
            this.lbNumberFiles = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Chuyển đổi base64-->XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Chuyển đổi XML-->base64";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(320, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Doi ma XML3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(541, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(290, 95);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnGetInfoXML23
            // 
            this.btnGetInfoXML23.Location = new System.Drawing.Point(12, 122);
            this.btnGetInfoXML23.Name = "btnGetInfoXML23";
            this.btnGetInfoXML23.Size = new System.Drawing.Size(97, 23);
            this.btnGetInfoXML23.TabIndex = 9;
            this.btnGetInfoXML23.Text = "GetInfoXML2+3";
            this.btnGetInfoXML23.UseVisualStyleBackColor = true;
            this.btnGetInfoXML23.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(239, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 255);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(423, 481);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(450, 255);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(403, 481);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "";
            // 
            // btnChinhSuaXML
            // 
            this.btnChinhSuaXML.Location = new System.Drawing.Point(401, 43);
            this.btnChinhSuaXML.Name = "btnChinhSuaXML";
            this.btnChinhSuaXML.Size = new System.Drawing.Size(109, 23);
            this.btnChinhSuaXML.TabIndex = 13;
            this.btnChinhSuaXML.Text = "Chinh sửa XML";
            this.btnChinhSuaXML.UseVisualStyleBackColor = true;
            this.btnChinhSuaXML.Click += new System.EventHandler(this.btnChinhSuaXML_Click);
            // 
            // btnXML1
            // 
            this.btnXML1.Location = new System.Drawing.Point(859, 255);
            this.btnXML1.Name = "btnXML1";
            this.btnXML1.Size = new System.Drawing.Size(403, 481);
            this.btnXML1.TabIndex = 12;
            this.btnXML1.Text = "";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 93);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "GetInfoXML1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnShowNumberFiles
            // 
            this.btnShowNumberFiles.Location = new System.Drawing.Point(878, 43);
            this.btnShowNumberFiles.Name = "btnShowNumberFiles";
            this.btnShowNumberFiles.Size = new System.Drawing.Size(75, 23);
            this.btnShowNumberFiles.TabIndex = 15;
            this.btnShowNumberFiles.Text = "Xem SL file";
            this.btnShowNumberFiles.UseVisualStyleBackColor = true;
            this.btnShowNumberFiles.Click += new System.EventHandler(this.btnShowNumberFiles_Click);
            // 
            // lbNumberFiles
            // 
            this.lbNumberFiles.AutoSize = true;
            this.lbNumberFiles.Location = new System.Drawing.Point(878, 13);
            this.lbNumberFiles.Name = "lbNumberFiles";
            this.lbNumberFiles.Size = new System.Drawing.Size(35, 13);
            this.lbNumberFiles.TabIndex = 16;
            this.lbNumberFiles.Text = "label1";
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(995, 43);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(218, 23);
            this.pBar.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 740);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.lbNumberFiles);
            this.Controls.Add(this.btnShowNumberFiles);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnChinhSuaXML);
            this.Controls.Add(this.btnXML1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnGetInfoXML23);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGetInfoXML23;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button btnChinhSuaXML;
        private System.Windows.Forms.RichTextBox btnXML1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnShowNumberFiles;
        private System.Windows.Forms.Label lbNumberFiles;
        private System.Windows.Forms.ProgressBar pBar;
    }
}

