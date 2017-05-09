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
            this.btnChinhSuaXML = new System.Windows.Forms.Button();
            this.btnGetInfoXML = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnXMLtoBase64 = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.btnGetInfoXML2 = new System.Windows.Forms.Button();
            this.btnGetInfoXML3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
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
            this.button3.Location = new System.Drawing.Point(206, 11);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1103, 464);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnChinhSuaXML
            // 
            this.btnChinhSuaXML.Location = new System.Drawing.Point(429, 12);
            this.btnChinhSuaXML.Name = "btnChinhSuaXML";
            this.btnChinhSuaXML.Size = new System.Drawing.Size(109, 23);
            this.btnChinhSuaXML.TabIndex = 13;
            this.btnChinhSuaXML.Text = "Chinh sửa XML";
            this.btnChinhSuaXML.UseVisualStyleBackColor = true;
            this.btnChinhSuaXML.Click += new System.EventHandler(this.btnChinhSuaXML_Click);
            // 
            // btnGetInfoXML
            // 
            this.btnGetInfoXML.Location = new System.Drawing.Point(12, 82);
            this.btnGetInfoXML.Name = "btnGetInfoXML";
            this.btnGetInfoXML.Size = new System.Drawing.Size(99, 23);
            this.btnGetInfoXML.TabIndex = 14;
            this.btnGetInfoXML.Text = "GetInfoXML1";
            this.btnGetInfoXML.UseVisualStyleBackColor = true;
            this.btnGetInfoXML.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(909, 11);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnXMLtoBase64
            // 
            this.btnXMLtoBase64.Location = new System.Drawing.Point(429, 42);
            this.btnXMLtoBase64.Name = "btnXMLtoBase64";
            this.btnXMLtoBase64.Size = new System.Drawing.Size(109, 23);
            this.btnXMLtoBase64.TabIndex = 16;
            this.btnXMLtoBase64.Text = "XML-->base64";
            this.btnXMLtoBase64.UseVisualStyleBackColor = true;
            this.btnXMLtoBase64.Click += new System.EventHandler(this.btnXMLtoBase64_Click);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(429, 82);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(170, 23);
            this.pBar.TabIndex = 17;
            // 
            // btnGetInfoXML2
            // 
            this.btnGetInfoXML2.Location = new System.Drawing.Point(117, 82);
            this.btnGetInfoXML2.Name = "btnGetInfoXML2";
            this.btnGetInfoXML2.Size = new System.Drawing.Size(106, 23);
            this.btnGetInfoXML2.TabIndex = 19;
            this.btnGetInfoXML2.Text = "GetInfo XML2";
            this.btnGetInfoXML2.UseVisualStyleBackColor = true;
            this.btnGetInfoXML2.Click += new System.EventHandler(this.btnGetInfoXML23_Click);
            // 
            // btnGetInfoXML3
            // 
            this.btnGetInfoXML3.Location = new System.Drawing.Point(229, 82);
            this.btnGetInfoXML3.Name = "btnGetInfoXML3";
            this.btnGetInfoXML3.Size = new System.Drawing.Size(88, 23);
            this.btnGetInfoXML3.TabIndex = 20;
            this.btnGetInfoXML3.Text = "GetInfoXML3";
            this.btnGetInfoXML3.UseVisualStyleBackColor = true;
            this.btnGetInfoXML3.Click += new System.EventHandler(this.btnGetInfoXML3_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(621, 81);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 740);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnGetInfoXML3);
            this.Controls.Add(this.btnGetInfoXML2);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.btnXMLtoBase64);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.btnGetInfoXML);
            this.Controls.Add(this.btnChinhSuaXML);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnChinhSuaXML;
        private System.Windows.Forms.Button btnGetInfoXML;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnXMLtoBase64;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button btnGetInfoXML2;
        private System.Windows.Forms.Button btnGetInfoXML3;
        private System.Windows.Forms.Button button6;
    }
}

