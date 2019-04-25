namespace WindowsFormsDataBase
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
            this.Connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GetDataBaseVer = new System.Windows.Forms.Button();
            this.Ver = new System.Windows.Forms.Label();
            this.StationName = new System.Windows.Forms.Label();
            this.ProductName = new System.Windows.Forms.Label();
            this.ProfileName = new System.Windows.Forms.Label();
            this.GetDataParam = new System.Windows.Forms.Button();
            this.sValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(634, 51);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 44);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect to Data Base";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(594, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Base not Connected";
            // 
            // GetDataBaseVer
            // 
            this.GetDataBaseVer.Location = new System.Drawing.Point(26, 60);
            this.GetDataBaseVer.Name = "GetDataBaseVer";
            this.GetDataBaseVer.Size = new System.Drawing.Size(159, 35);
            this.GetDataBaseVer.TabIndex = 2;
            this.GetDataBaseVer.Text = "GetDataBaseVer";
            this.GetDataBaseVer.UseVisualStyleBackColor = true;
            this.GetDataBaseVer.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // Ver
            // 
            this.Ver.AutoSize = true;
            this.Ver.Location = new System.Drawing.Point(205, 71);
            this.Ver.Name = "Ver";
            this.Ver.Size = new System.Drawing.Size(35, 13);
            this.Ver.TabIndex = 3;
            this.Ver.Text = "label2";
            // 
            // StationName
            // 
            this.StationName.AutoSize = true;
            this.StationName.Location = new System.Drawing.Point(23, 25);
            this.StationName.Name = "StationName";
            this.StationName.Size = new System.Drawing.Size(35, 13);
            this.StationName.TabIndex = 4;
            this.StationName.Text = "label3";
            // 
            // ProductName
            // 
            this.ProductName.AutoSize = true;
            this.ProductName.Location = new System.Drawing.Point(101, 25);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(35, 13);
            this.ProductName.TabIndex = 5;
            this.ProductName.Text = "label4";
            // 
            // ProfileName
            // 
            this.ProfileName.AutoSize = true;
            this.ProfileName.Location = new System.Drawing.Point(205, 25);
            this.ProfileName.Name = "ProfileName";
            this.ProfileName.Size = new System.Drawing.Size(35, 13);
            this.ProfileName.TabIndex = 6;
            this.ProfileName.Text = "label5";
            // 
            // GetDataParam
            // 
            this.GetDataParam.Location = new System.Drawing.Point(26, 126);
            this.GetDataParam.Name = "GetDataParam";
            this.GetDataParam.Size = new System.Drawing.Size(159, 35);
            this.GetDataParam.TabIndex = 7;
            this.GetDataParam.Text = "GetDataParam";
            this.GetDataParam.UseVisualStyleBackColor = true;
            this.GetDataParam.Click += new System.EventHandler(this.Button1_Click_2);
            // 
            // sValue
            // 
            this.sValue.AutoSize = true;
            this.sValue.Location = new System.Drawing.Point(205, 137);
            this.sValue.Name = "sValue";
            this.sValue.Size = new System.Drawing.Size(35, 13);
            this.sValue.TabIndex = 8;
            this.sValue.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sValue);
            this.Controls.Add(this.GetDataParam);
            this.Controls.Add(this.ProfileName);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.StationName);
            this.Controls.Add(this.Ver);
            this.Controls.Add(this.GetDataBaseVer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GetDataBaseVer;
        private System.Windows.Forms.Label Ver;
        private System.Windows.Forms.Label StationName;
        private System.Windows.Forms.Label ProductName;
        private System.Windows.Forms.Label ProfileName;
        private System.Windows.Forms.Button GetDataParam;
        private System.Windows.Forms.Label sValue;
    }
}

