namespace AddressPrinter
{
    partial class AddressPrinter
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
            this.txtYubinnbanngouAtena = new System.Windows.Forms.TextBox();
            this.lblyubinnbanngou = new System.Windows.Forms.Label();
            this.btnKennsakuAtena = new System.Windows.Forms.Button();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtZyuusyoAtena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsatu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAtenaName = new System.Windows.Forms.TextBox();
            this.txtTatemonoAtena = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.combAtenaKeisyou = new System.Windows.Forms.ComboBox();
            this.combSyozokusakiKEisyouAtena = new System.Windows.Forms.ComboBox();
            this.txtSyozokusakiAtena = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtYubinnbanngouAtena
            // 
            this.txtYubinnbanngouAtena.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtYubinnbanngouAtena.Location = new System.Drawing.Point(31, 76);
            this.txtYubinnbanngouAtena.Name = "txtYubinnbanngouAtena";
            this.txtYubinnbanngouAtena.Size = new System.Drawing.Size(169, 24);
            this.txtYubinnbanngouAtena.TabIndex = 1;
            // 
            // lblyubinnbanngou
            // 
            this.lblyubinnbanngou.AutoSize = true;
            this.lblyubinnbanngou.Location = new System.Drawing.Point(31, 55);
            this.lblyubinnbanngou.Name = "lblyubinnbanngou";
            this.lblyubinnbanngou.Size = new System.Drawing.Size(143, 15);
            this.lblyubinnbanngou.TabIndex = 2;
            this.lblyubinnbanngou.Text = "郵便番号（ハイフン有）";
            // 
            // btnKennsakuAtena
            // 
            this.btnKennsakuAtena.Location = new System.Drawing.Point(206, 66);
            this.btnKennsakuAtena.Name = "btnKennsakuAtena";
            this.btnKennsakuAtena.Size = new System.Drawing.Size(119, 44);
            this.btnKennsakuAtena.TabIndex = 3;
            this.btnKennsakuAtena.Text = "住所検索";
            this.btnKennsakuAtena.UseVisualStyleBackColor = true;
            this.btnKennsakuAtena.Click += new System.EventHandler(this.btnKennsakuAtena_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(31, 130);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(37, 15);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "住所";
            // 
            // txtZyuusyoAtena
            // 
            this.txtZyuusyoAtena.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtZyuusyoAtena.Location = new System.Drawing.Point(31, 148);
            this.txtZyuusyoAtena.Multiline = true;
            this.txtZyuusyoAtena.Name = "txtZyuusyoAtena";
            this.txtZyuusyoAtena.Size = new System.Drawing.Size(294, 88);
            this.txtZyuusyoAtena.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(154, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "宛先";
            // 
            // btnInsatu
            // 
            this.btnInsatu.Location = new System.Drawing.Point(31, 479);
            this.btnInsatu.Name = "btnInsatu";
            this.btnInsatu.Size = new System.Drawing.Size(109, 44);
            this.btnInsatu.TabIndex = 9;
            this.btnInsatu.Text = "印刷";
            this.btnInsatu.UseVisualStyleBackColor = true;
            this.btnInsatu.Click += new System.EventHandler(this.btnInsatu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "宛名";
            // 
            // txtAtenaName
            // 
            this.txtAtenaName.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAtenaName.Location = new System.Drawing.Point(31, 346);
            this.txtAtenaName.Name = "txtAtenaName";
            this.txtAtenaName.Size = new System.Drawing.Size(219, 24);
            this.txtAtenaName.TabIndex = 12;
            // 
            // txtTatemonoAtena
            // 
            this.txtTatemonoAtena.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTatemonoAtena.Location = new System.Drawing.Point(31, 269);
            this.txtTatemonoAtena.Multiline = true;
            this.txtTatemonoAtena.Name = "txtTatemonoAtena";
            this.txtTatemonoAtena.Size = new System.Drawing.Size(294, 47);
            this.txtTatemonoAtena.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "建物名・号室";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 388);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 32;
            this.label10.Text = "所属先";
            // 
            // combAtenaKeisyou
            // 
            this.combAtenaKeisyou.FormattingEnabled = true;
            this.combAtenaKeisyou.Location = new System.Drawing.Point(256, 346);
            this.combAtenaKeisyou.Name = "combAtenaKeisyou";
            this.combAtenaKeisyou.Size = new System.Drawing.Size(69, 23);
            this.combAtenaKeisyou.TabIndex = 36;
            // 
            // combSyozokusakiKEisyouAtena
            // 
            this.combSyozokusakiKEisyouAtena.FormattingEnabled = true;
            this.combSyozokusakiKEisyouAtena.Location = new System.Drawing.Point(256, 427);
            this.combSyozokusakiKEisyouAtena.Name = "combSyozokusakiKEisyouAtena";
            this.combSyozokusakiKEisyouAtena.Size = new System.Drawing.Size(69, 23);
            this.combSyozokusakiKEisyouAtena.TabIndex = 40;
            // 
            // txtSyozokusakiAtena
            // 
            this.txtSyozokusakiAtena.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtSyozokusakiAtena.Location = new System.Drawing.Point(31, 406);
            this.txtSyozokusakiAtena.Multiline = true;
            this.txtSyozokusakiAtena.Name = "txtSyozokusakiAtena";
            this.txtSyozokusakiAtena.Size = new System.Drawing.Size(219, 44);
            this.txtSyozokusakiAtena.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(216, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 44);
            this.button1.TabIndex = 41;
            this.button1.Text = "印刷プレビュー";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnInsatsuPreview_Click);
            // 
            // AddressPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 560);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.combSyozokusakiKEisyouAtena);
            this.Controls.Add(this.txtSyozokusakiAtena);
            this.Controls.Add(this.combAtenaKeisyou);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTatemonoAtena);
            this.Controls.Add(this.txtAtenaName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInsatu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtZyuusyoAtena);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.btnKennsakuAtena);
            this.Controls.Add(this.lblyubinnbanngou);
            this.Controls.Add(this.txtYubinnbanngouAtena);
            this.Name = "AddressPrinter";
            this.Text = "AddressPrinter";
            this.Load += new System.EventHandler(this.AddressPrinter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtYubinnbanngouAtena;
        private System.Windows.Forms.Label lblyubinnbanngou;
        private System.Windows.Forms.Button btnKennsakuAtena;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtZyuusyoAtena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsatu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAtenaName;
        private System.Windows.Forms.TextBox txtTatemonoAtena;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox combAtenaKeisyou;
        private System.Windows.Forms.ComboBox combSyozokusakiKEisyouAtena;
        private System.Windows.Forms.TextBox txtSyozokusakiAtena;
        private System.Windows.Forms.Button button1;
    }
}

