namespace Demo
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
            this.label1 = new System.Windows.Forms.Label();
            this.InputPlaintext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Ciphertext = new System.Windows.Forms.TextBox();
            this.EncodeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ReadPlaintextBtn = new System.Windows.Forms.Button();
            this.TransferBtn = new System.Windows.Forms.Button();
            this.SaveCiphertextBtn = new System.Windows.Forms.Button();
            this.InputCiphertext = new System.Windows.Forms.TextBox();
            this.Plaintext = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ReadCiphertextBtn = new System.Windows.Forms.Button();
            this.DecodeBtn = new System.Windows.Forms.Button();
            this.SavePlaintextBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bản rõ";
            // 
            // InputPlaintext
            // 
            this.InputPlaintext.Location = new System.Drawing.Point(30, 109);
            this.InputPlaintext.Multiline = true;
            this.InputPlaintext.Name = "InputPlaintext";
            this.InputPlaintext.Size = new System.Drawing.Size(430, 129);
            this.InputPlaintext.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bản mã";
            // 
            // Ciphertext
            // 
            this.Ciphertext.Location = new System.Drawing.Point(30, 414);
            this.Ciphertext.Multiline = true;
            this.Ciphertext.Name = "Ciphertext";
            this.Ciphertext.Size = new System.Drawing.Size(430, 161);
            this.Ciphertext.TabIndex = 3;
            // 
            // EncodeBtn
            // 
            this.EncodeBtn.Location = new System.Drawing.Point(190, 264);
            this.EncodeBtn.Name = "EncodeBtn";
            this.EncodeBtn.Size = new System.Drawing.Size(92, 28);
            this.EncodeBtn.TabIndex = 4;
            this.EncodeBtn.Text = "Mã hóa";
            this.EncodeBtn.UseVisualStyleBackColor = true;
            this.EncodeBtn.Click += new System.EventHandler(this.EncodeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "MÃ HÓA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(651, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "GIẢI MÃ";
            // 
            // ReadPlaintextBtn
            // 
            this.ReadPlaintextBtn.Location = new System.Drawing.Point(486, 106);
            this.ReadPlaintextBtn.Name = "ReadPlaintextBtn";
            this.ReadPlaintextBtn.Size = new System.Drawing.Size(92, 28);
            this.ReadPlaintextBtn.TabIndex = 7;
            this.ReadPlaintextBtn.Text = "File";
            this.ReadPlaintextBtn.UseVisualStyleBackColor = true;
            this.ReadPlaintextBtn.Click += new System.EventHandler(this.ReadPlaintextBtn_Click);
            // 
            // TransferBtn
            // 
            this.TransferBtn.Location = new System.Drawing.Point(486, 414);
            this.TransferBtn.Name = "TransferBtn";
            this.TransferBtn.Size = new System.Drawing.Size(92, 28);
            this.TransferBtn.TabIndex = 8;
            this.TransferBtn.Text = "Chuyển";
            this.TransferBtn.UseVisualStyleBackColor = true;
            this.TransferBtn.Click += new System.EventHandler(this.TransferBtn_Click);
            // 
            // SaveCiphertextBtn
            // 
            this.SaveCiphertextBtn.Location = new System.Drawing.Point(486, 479);
            this.SaveCiphertextBtn.Name = "SaveCiphertextBtn";
            this.SaveCiphertextBtn.Size = new System.Drawing.Size(92, 28);
            this.SaveCiphertextBtn.TabIndex = 9;
            this.SaveCiphertextBtn.Text = "Lưu";
            this.SaveCiphertextBtn.UseVisualStyleBackColor = true;
            this.SaveCiphertextBtn.Click += new System.EventHandler(this.SaveCiphertextBtn_Click);
            // 
            // InputCiphertext
            // 
            this.InputCiphertext.Location = new System.Drawing.Point(654, 112);
            this.InputCiphertext.Multiline = true;
            this.InputCiphertext.Name = "InputCiphertext";
            this.InputCiphertext.Size = new System.Drawing.Size(457, 126);
            this.InputCiphertext.TabIndex = 10;
            // 
            // Plaintext
            // 
            this.Plaintext.Location = new System.Drawing.Point(654, 414);
            this.Plaintext.Multiline = true;
            this.Plaintext.Name = "Plaintext";
            this.Plaintext.Size = new System.Drawing.Size(457, 161);
            this.Plaintext.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(658, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Bản rõ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(651, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bản mã";
            // 
            // ReadCiphertextBtn
            // 
            this.ReadCiphertextBtn.Location = new System.Drawing.Point(1149, 112);
            this.ReadCiphertextBtn.Name = "ReadCiphertextBtn";
            this.ReadCiphertextBtn.Size = new System.Drawing.Size(92, 28);
            this.ReadCiphertextBtn.TabIndex = 14;
            this.ReadCiphertextBtn.Text = "File";
            this.ReadCiphertextBtn.UseVisualStyleBackColor = true;
            this.ReadCiphertextBtn.Click += new System.EventHandler(this.ReadCiphertextBtn_Click);
            // 
            // DecodeBtn
            // 
            this.DecodeBtn.Location = new System.Drawing.Point(827, 264);
            this.DecodeBtn.Name = "DecodeBtn";
            this.DecodeBtn.Size = new System.Drawing.Size(92, 28);
            this.DecodeBtn.TabIndex = 15;
            this.DecodeBtn.Text = "Giải mã";
            this.DecodeBtn.UseVisualStyleBackColor = true;
            this.DecodeBtn.Click += new System.EventHandler(this.DecodeBtn_Click);
            // 
            // SavePlaintextBtn
            // 
            this.SavePlaintextBtn.Location = new System.Drawing.Point(1149, 479);
            this.SavePlaintextBtn.Name = "SavePlaintextBtn";
            this.SavePlaintextBtn.Size = new System.Drawing.Size(92, 28);
            this.SavePlaintextBtn.TabIndex = 16;
            this.SavePlaintextBtn.Text = "Lưu";
            this.SavePlaintextBtn.UseVisualStyleBackColor = true;
            this.SavePlaintextBtn.Click += new System.EventHandler(this.SavePlaintextBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 721);
            this.Controls.Add(this.SavePlaintextBtn);
            this.Controls.Add(this.DecodeBtn);
            this.Controls.Add(this.ReadCiphertextBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Plaintext);
            this.Controls.Add(this.InputCiphertext);
            this.Controls.Add(this.SaveCiphertextBtn);
            this.Controls.Add(this.TransferBtn);
            this.Controls.Add(this.ReadPlaintextBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EncodeBtn);
            this.Controls.Add(this.Ciphertext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InputPlaintext);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputPlaintext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Ciphertext;
        private System.Windows.Forms.Button EncodeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ReadPlaintextBtn;
        private System.Windows.Forms.Button TransferBtn;
        private System.Windows.Forms.Button SaveCiphertextBtn;
        private System.Windows.Forms.TextBox InputCiphertext;
        private System.Windows.Forms.TextBox Plaintext;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ReadCiphertextBtn;
        private System.Windows.Forms.Button DecodeBtn;
        private System.Windows.Forms.Button SavePlaintextBtn;
    }
}

