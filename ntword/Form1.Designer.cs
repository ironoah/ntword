namespace ntword
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNext = new System.Windows.Forms.Button();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.txtJapanese = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNext.Location = new System.Drawing.Point(261, 208);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(369, 86);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.button1_Click);
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chk1.Location = new System.Drawing.Point(679, 41);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(96, 25);
            this.chk1.TabIndex = 2;
            this.chk1.Text = "finished";
            this.chk1.UseVisualStyleBackColor = true;
            this.chk1.Click += new System.EventHandler(this.chk1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnBack.Location = new System.Drawing.Point(32, 208);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(223, 86);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton1.Location = new System.Drawing.Point(679, 219);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 25);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButton2.Location = new System.Drawing.Point(679, 259);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(124, 25);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Incomplete";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // txtWord
            // 
            this.txtWord.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtWord.Location = new System.Drawing.Point(32, 31);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(612, 71);
            this.txtWord.TabIndex = 6;
            // 
            // txtJapanese
            // 
            this.txtJapanese.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtJapanese.Location = new System.Drawing.Point(32, 122);
            this.txtJapanese.Name = "txtJapanese";
            this.txtJapanese.Size = new System.Drawing.Size(772, 71);
            this.txtJapanese.TabIndex = 7;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMessage.Location = new System.Drawing.Point(28, 307);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 21);
            this.lblMessage.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 337);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtJapanese);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.btnNext);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "単語帳";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.TextBox txtJapanese;
        private System.Windows.Forms.Label lblMessage;
    }
}

