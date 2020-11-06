namespace Yazlab1_1
{
    partial class MainMenu
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartGameButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gameMapWidthTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.GameNameText = new System.Windows.Forms.Label();
            this.gameMapHeightTextBox = new System.Windows.Forms.TextBox();
            this.goldRateTextBox = new System.Windows.Forms.TextBox();
            this.secretGoldRateTextBox = new System.Windows.Forms.TextBox();
            this.startGoldTextBox = new System.Windows.Forms.TextBox();
            this.maxMoveTextBox = new System.Windows.Forms.TextBox();
            this.ATargetCostTextBox = new System.Windows.Forms.TextBox();
            this.CTargetCostTextBox = new System.Windows.Forms.TextBox();
            this.DTargetCostTextBox = new System.Windows.Forms.TextBox();
            this.AMoveCostTextBox = new System.Windows.Forms.TextBox();
            this.BMoveCostTextBox = new System.Windows.Forms.TextBox();
            this.CMoveCostTextBox = new System.Windows.Forms.TextBox();
            this.DMoveCostTextBox = new System.Windows.Forms.TextBox();
            this.COpenSecretGoldTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.BTargetCostTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // StartGameButton
            // 
            this.StartGameButton.Font = new System.Drawing.Font("Unispace", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.StartGameButton.ForeColor = System.Drawing.SystemColors.Highlight;
            this.StartGameButton.Location = new System.Drawing.Point(435, 534);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(217, 73);
            this.StartGameButton.TabIndex = 1;
            this.StartGameButton.Text = "Oyunu Başlat";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(20, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Oyun Tahtasının Genişliği:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(20, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Oyun Tahtası Yüksekliği:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(20, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Gizli Altın Bulunma Oranı:(%)";
            // 
            // gameMapWidthTextBox
            // 
            this.gameMapWidthTextBox.Location = new System.Drawing.Point(295, 80);
            this.gameMapWidthTextBox.Name = "gameMapWidthTextBox";
            this.gameMapWidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.gameMapWidthTextBox.TabIndex = 6;
            this.gameMapWidthTextBox.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(20, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(249, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Başlangıç Altın Miktarı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(20, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bir Turdaki Maksimum Adım Sayısı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(20, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Altın Bulunma Oranı:(%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(20, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(349, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "A Oyuncu Hedef Belirleme Maliyeti:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(20, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(349, 19);
            this.label8.TabIndex = 11;
            this.label8.Text = "B Oyuncu Hedef Belirleme Maliyeti:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(20, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(349, 19);
            this.label9.TabIndex = 12;
            this.label9.Text = "C Oyuncu Hedef Belirleme Maliyeti:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(20, 440);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(349, 19);
            this.label10.TabIndex = 13;
            this.label10.Text = "D Oyuncu Hedef Belirleme Maliyeti:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(20, 480);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(249, 19);
            this.label11.TabIndex = 14;
            this.label11.Text = "A Oyuncu Hamle Maliyeti:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(20, 560);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(249, 19);
            this.label12.TabIndex = 15;
            this.label12.Text = "C Oyuncu Hamle Maliyeti:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(20, 520);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(249, 19);
            this.label14.TabIndex = 17;
            this.label14.Text = "B Oyuncu Hamle Maliyeti:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(20, 600);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(249, 19);
            this.label13.TabIndex = 18;
            this.label13.Text = "D Oyuncu Hamle Maliyeti:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label15.Location = new System.Drawing.Point(20, 640);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(349, 19);
            this.label15.TabIndex = 19;
            this.label15.Text = "C Oyuncu Gizli Altın Açma Miktarı:";
            // 
            // GameNameText
            // 
            this.GameNameText.AutoSize = true;
            this.GameNameText.Font = new System.Drawing.Font("Unispace", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameNameText.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GameNameText.Location = new System.Drawing.Point(45, 9);
            this.GameNameText.Name = "GameNameText";
            this.GameNameText.Size = new System.Drawing.Size(0, 58);
            this.GameNameText.TabIndex = 20;
            // 
            // gameMapHeightTextBox
            // 
            this.gameMapHeightTextBox.Location = new System.Drawing.Point(295, 120);
            this.gameMapHeightTextBox.Name = "gameMapHeightTextBox";
            this.gameMapHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.gameMapHeightTextBox.TabIndex = 21;
            this.gameMapHeightTextBox.Text = "20";
            // 
            // goldRateTextBox
            // 
            this.goldRateTextBox.Location = new System.Drawing.Point(295, 160);
            this.goldRateTextBox.Name = "goldRateTextBox";
            this.goldRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.goldRateTextBox.TabIndex = 22;
            this.goldRateTextBox.Text = "20";
            // 
            // secretGoldRateTextBox
            // 
            this.secretGoldRateTextBox.Location = new System.Drawing.Point(325, 200);
            this.secretGoldRateTextBox.Name = "secretGoldRateTextBox";
            this.secretGoldRateTextBox.Size = new System.Drawing.Size(100, 20);
            this.secretGoldRateTextBox.TabIndex = 23;
            this.secretGoldRateTextBox.Text = "10";
            // 
            // startGoldTextBox
            // 
            this.startGoldTextBox.Location = new System.Drawing.Point(295, 240);
            this.startGoldTextBox.Name = "startGoldTextBox";
            this.startGoldTextBox.Size = new System.Drawing.Size(100, 20);
            this.startGoldTextBox.TabIndex = 24;
            this.startGoldTextBox.Text = "200";
            // 
            // maxMoveTextBox
            // 
            this.maxMoveTextBox.Location = new System.Drawing.Point(375, 280);
            this.maxMoveTextBox.Name = "maxMoveTextBox";
            this.maxMoveTextBox.Size = new System.Drawing.Size(100, 20);
            this.maxMoveTextBox.TabIndex = 25;
            this.maxMoveTextBox.Text = "3";
            // 
            // ATargetCostTextBox
            // 
            this.ATargetCostTextBox.Location = new System.Drawing.Point(375, 320);
            this.ATargetCostTextBox.Name = "ATargetCostTextBox";
            this.ATargetCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.ATargetCostTextBox.TabIndex = 26;
            this.ATargetCostTextBox.Text = "5";
            // 
            // CTargetCostTextBox
            // 
            this.CTargetCostTextBox.Location = new System.Drawing.Point(375, 400);
            this.CTargetCostTextBox.Name = "CTargetCostTextBox";
            this.CTargetCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.CTargetCostTextBox.TabIndex = 28;
            this.CTargetCostTextBox.Text = "15";
            // 
            // DTargetCostTextBox
            // 
            this.DTargetCostTextBox.Location = new System.Drawing.Point(375, 440);
            this.DTargetCostTextBox.Name = "DTargetCostTextBox";
            this.DTargetCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.DTargetCostTextBox.TabIndex = 29;
            this.DTargetCostTextBox.Text = "20";
            // 
            // AMoveCostTextBox
            // 
            this.AMoveCostTextBox.Location = new System.Drawing.Point(275, 480);
            this.AMoveCostTextBox.Name = "AMoveCostTextBox";
            this.AMoveCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.AMoveCostTextBox.TabIndex = 30;
            this.AMoveCostTextBox.Text = "5";
            // 
            // BMoveCostTextBox
            // 
            this.BMoveCostTextBox.Location = new System.Drawing.Point(275, 520);
            this.BMoveCostTextBox.Name = "BMoveCostTextBox";
            this.BMoveCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.BMoveCostTextBox.TabIndex = 31;
            this.BMoveCostTextBox.Text = "5";
            // 
            // CMoveCostTextBox
            // 
            this.CMoveCostTextBox.Location = new System.Drawing.Point(275, 560);
            this.CMoveCostTextBox.Name = "CMoveCostTextBox";
            this.CMoveCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.CMoveCostTextBox.TabIndex = 32;
            this.CMoveCostTextBox.Text = "5";
            // 
            // DMoveCostTextBox
            // 
            this.DMoveCostTextBox.Location = new System.Drawing.Point(275, 600);
            this.DMoveCostTextBox.Name = "DMoveCostTextBox";
            this.DMoveCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.DMoveCostTextBox.TabIndex = 33;
            this.DMoveCostTextBox.Text = "5";
            // 
            // COpenSecretGoldTextBox
            // 
            this.COpenSecretGoldTextBox.Location = new System.Drawing.Point(375, 640);
            this.COpenSecretGoldTextBox.Name = "COpenSecretGoldTextBox";
            this.COpenSecretGoldTextBox.Size = new System.Drawing.Size(100, 20);
            this.COpenSecretGoldTextBox.TabIndex = 34;
            this.COpenSecretGoldTextBox.Text = "2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Unispace", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label16.Location = new System.Drawing.Point(45, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(576, 58);
            this.label16.TabIndex = 35;
            this.label16.Text = "Altın Toplama Oyunu";
            // 
            // BTargetCostTextBox
            // 
            this.BTargetCostTextBox.Location = new System.Drawing.Point(375, 360);
            this.BTargetCostTextBox.Name = "BTargetCostTextBox";
            this.BTargetCostTextBox.Size = new System.Drawing.Size(100, 20);
            this.BTargetCostTextBox.TabIndex = 36;
            this.BTargetCostTextBox.Text = "10";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(664, 681);
            this.Controls.Add(this.BTargetCostTextBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.COpenSecretGoldTextBox);
            this.Controls.Add(this.DMoveCostTextBox);
            this.Controls.Add(this.CMoveCostTextBox);
            this.Controls.Add(this.BMoveCostTextBox);
            this.Controls.Add(this.AMoveCostTextBox);
            this.Controls.Add(this.DTargetCostTextBox);
            this.Controls.Add(this.CTargetCostTextBox);
            this.Controls.Add(this.ATargetCostTextBox);
            this.Controls.Add(this.maxMoveTextBox);
            this.Controls.Add(this.startGoldTextBox);
            this.Controls.Add(this.secretGoldRateTextBox);
            this.Controls.Add(this.goldRateTextBox);
            this.Controls.Add(this.gameMapHeightTextBox);
            this.Controls.Add(this.GameNameText);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gameMapWidthTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartGameButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenu";
            this.Text = "Altın Toplama Oyunu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gameMapWidthTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label GameNameText;
        private System.Windows.Forms.TextBox gameMapHeightTextBox;
        private System.Windows.Forms.TextBox goldRateTextBox;
        private System.Windows.Forms.TextBox secretGoldRateTextBox;
        private System.Windows.Forms.TextBox startGoldTextBox;
        private System.Windows.Forms.TextBox maxMoveTextBox;
        private System.Windows.Forms.TextBox ATargetCostTextBox;
        private System.Windows.Forms.TextBox CTargetCostTextBox;
        private System.Windows.Forms.TextBox DTargetCostTextBox;
        private System.Windows.Forms.TextBox AMoveCostTextBox;
        private System.Windows.Forms.TextBox BMoveCostTextBox;
        private System.Windows.Forms.TextBox CMoveCostTextBox;
        private System.Windows.Forms.TextBox DMoveCostTextBox;
        private System.Windows.Forms.TextBox COpenSecretGoldTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox BTargetCostTextBox;
    }
}

