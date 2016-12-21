namespace TOP_3
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cntUser = new System.Windows.Forms.Label();
            this.cntProduct = new System.Windows.Forms.Label();
            this.cntCategory = new System.Windows.Forms.Label();
            this.dbDataSet = new TOP_3.dbDataSet();
            this.btnUser = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cntTransactions = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Šiuo metu parduotuvėje yra:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Užsiregistravusių vartotojų:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parduodamų prekių:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Prekių kategorijų:";
            // 
            // cntUser
            // 
            this.cntUser.AutoSize = true;
            this.cntUser.Location = new System.Drawing.Point(171, 41);
            this.cntUser.Name = "cntUser";
            this.cntUser.Size = new System.Drawing.Size(13, 13);
            this.cntUser.TabIndex = 4;
            this.cntUser.Text = "0";
            // 
            // cntProduct
            // 
            this.cntProduct.AutoSize = true;
            this.cntProduct.Location = new System.Drawing.Point(171, 54);
            this.cntProduct.Name = "cntProduct";
            this.cntProduct.Size = new System.Drawing.Size(13, 13);
            this.cntProduct.TabIndex = 5;
            this.cntProduct.Text = "0";
            // 
            // cntCategory
            // 
            this.cntCategory.AutoSize = true;
            this.cntCategory.Location = new System.Drawing.Point(171, 67);
            this.cntCategory.Name = "cntCategory";
            this.cntCategory.Size = new System.Drawing.Size(13, 13);
            this.cntCategory.TabIndex = 6;
            this.cntCategory.Text = "0";
            // 
            // dbDataSet
            // 
            this.dbDataSet.DataSetName = "dbDataSet";
            this.dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnUser
            // 
            this.btnUser.Location = new System.Drawing.Point(12, 135);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(75, 23);
            this.btnUser.TabIndex = 7;
            this.btnUser.Text = "Vartotojai";
            this.btnUser.UseVisualStyleBackColor = true;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(93, 135);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(75, 23);
            this.btnProducts.TabIndex = 8;
            this.btnProducts.Text = "Prekės";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Transakcijos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cntTransactions
            // 
            this.cntTransactions.AutoSize = true;
            this.cntTransactions.Location = new System.Drawing.Point(171, 80);
            this.cntTransactions.Name = "cntTransactions";
            this.cntTransactions.Size = new System.Drawing.Size(13, 13);
            this.cntTransactions.TabIndex = 11;
            this.cntTransactions.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Padaryta transakcijų:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 170);
            this.Controls.Add(this.cntTransactions);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnProducts);
            this.Controls.Add(this.btnUser);
            this.Controls.Add(this.cntCategory);
            this.Controls.Add(this.cntProduct);
            this.Controls.Add(this.cntUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Online Shop Admin";
            ((System.ComponentModel.ISupportInitialize)(this.dbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label cntUser;
        private System.Windows.Forms.Label cntProduct;
        private System.Windows.Forms.Label cntCategory;
        private dbDataSet dbDataSet;
        private System.Windows.Forms.Button btnUser;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label cntTransactions;
        private System.Windows.Forms.Label label6;
    }
}

