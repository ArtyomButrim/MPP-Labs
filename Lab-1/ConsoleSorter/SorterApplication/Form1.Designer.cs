namespace SorterApplication
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathToSaveOriginalFile = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPathForSaveSortFile = new System.Windows.Forms.TextBox();
            this.txtPathForOriginalFile = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnGenerate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPathToSaveOriginalFile);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Text File";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(73, 114);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(121, 24);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path for saving file:";
            // 
            // txtPathToSaveOriginalFile
            // 
            this.txtPathToSaveOriginalFile.Location = new System.Drawing.Point(11, 35);
            this.txtPathToSaveOriginalFile.Name = "txtPathToSaveOriginalFile";
            this.txtPathToSaveOriginalFile.Size = new System.Drawing.Size(253, 20);
            this.txtPathToSaveOriginalFile.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSort);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPathForSaveSortFile);
            this.groupBox2.Controls.Add(this.txtPathForOriginalFile);
            this.groupBox2.Location = new System.Drawing.Point(1, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 145);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sort Text File";
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(73, 111);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(121, 24);
            this.btnSort.TabIndex = 6;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path for saving sort file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path to original text file:";
            // 
            // txtPathForSaveSortFile
            // 
            this.txtPathForSaveSortFile.Location = new System.Drawing.Point(11, 85);
            this.txtPathForSaveSortFile.Name = "txtPathForSaveSortFile";
            this.txtPathForSaveSortFile.Size = new System.Drawing.Size(253, 20);
            this.txtPathForSaveSortFile.TabIndex = 2;
            // 
            // txtPathForOriginalFile
            // 
            this.txtPathForOriginalFile.Location = new System.Drawing.Point(11, 34);
            this.txtPathForOriginalFile.Name = "txtPathForOriginalFile";
            this.txtPathForOriginalFile.Size = new System.Drawing.Size(253, 20);
            this.txtPathForOriginalFile.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "250 MB",
            "500 MB",
            "1 GB",
            "2 GB",
            "5GB"});
            this.comboBox1.Location = new System.Drawing.Point(11, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(253, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Size of file:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 301);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPathToSaveOriginalFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPathForSaveSortFile;
        private System.Windows.Forms.TextBox txtPathForOriginalFile;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}

