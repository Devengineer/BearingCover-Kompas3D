namespace bearingCover
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.additionalParamsGroupBox = new System.Windows.Forms.GroupBox();
			this.angleCut = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.colorPanel = new System.Windows.Forms.Panel();
			this.partColor = new System.Windows.Forms.Button();
			this.exitButton = new System.Windows.Forms.Button();
			this.buildButton = new System.Windows.Forms.Button();
			this.paramsGroupBox = new System.Windows.Forms.GroupBox();
			this.holesNumber = new System.Windows.Forms.TextBox();
			this.distanceAroundHoles = new System.Windows.Forms.TextBox();
			this.holesDiameter = new System.Windows.Forms.TextBox();
			this.bearingCoverDiameter = new System.Windows.Forms.TextBox();
			this.inDiameterCentralHole = new System.Windows.Forms.TextBox();
			this.holesDistance = new System.Windows.Forms.TextBox();
			this.outDiameterCentralHole = new System.Windows.Forms.TextBox();
			this.posteriorWallThickness = new System.Windows.Forms.TextBox();
			this.centralHoleDepth = new System.Windows.Forms.TextBox();
			this.rearProjection = new System.Windows.Forms.TextBox();
			this.borderThickness = new System.Windows.Forms.TextBox();
			this.frontProjection = new System.Windows.Forms.TextBox();
			this.coverThickness = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.BearingCoverImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.additionalParamsGroupBox.SuspendLayout();
			this.paramsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BearingCoverImage)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.additionalParamsGroupBox);
			this.splitContainer1.Panel1.Controls.Add(this.exitButton);
			this.splitContainer1.Panel1.Controls.Add(this.buildButton);
			this.splitContainer1.Panel1.Controls.Add(this.paramsGroupBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.BearingCoverImage);
			this.splitContainer1.Size = new System.Drawing.Size(918, 510);
			this.splitContainer1.SplitterDistance = 339;
			this.splitContainer1.TabIndex = 0;
			// 
			// additionalParamsGroupBox
			// 
			this.additionalParamsGroupBox.Controls.Add(this.angleCut);
			this.additionalParamsGroupBox.Controls.Add(this.label14);
			this.additionalParamsGroupBox.Controls.Add(this.colorPanel);
			this.additionalParamsGroupBox.Controls.Add(this.partColor);
			this.additionalParamsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.additionalParamsGroupBox.ForeColor = System.Drawing.SystemColors.Highlight;
			this.additionalParamsGroupBox.Location = new System.Drawing.Point(0, 376);
			this.additionalParamsGroupBox.Name = "additionalParamsGroupBox";
			this.additionalParamsGroupBox.Size = new System.Drawing.Size(339, 87);
			this.additionalParamsGroupBox.TabIndex = 3;
			this.additionalParamsGroupBox.TabStop = false;
			this.additionalParamsGroupBox.Text = "Дополнительные параметры";
			// 
			// angleCut
			// 
			this.angleCut.Location = new System.Drawing.Point(292, 36);
			this.angleCut.MaxLength = 3;
			this.angleCut.Name = "angleCut";
			this.angleCut.Size = new System.Drawing.Size(41, 20);
			this.angleCut.TabIndex = 3;
			this.angleCut.Text = "0";
			this.angleCut.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label14.Location = new System.Drawing.Point(206, 39);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(80, 13);
			this.label14.TabIndex = 2;
			this.label14.Text = "Угол разреза:";
			// 
			// colorPanel
			// 
			this.colorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(144)))), ((int)(((byte)(144)))));
			this.colorPanel.Location = new System.Drawing.Point(120, 20);
			this.colorPanel.Name = "colorPanel";
			this.colorPanel.Size = new System.Drawing.Size(63, 61);
			this.colorPanel.TabIndex = 1;
			// 
			// partColor
			// 
			this.partColor.ForeColor = System.Drawing.SystemColors.ControlText;
			this.partColor.Location = new System.Drawing.Point(12, 34);
			this.partColor.Name = "partColor";
			this.partColor.Size = new System.Drawing.Size(90, 23);
			this.partColor.TabIndex = 0;
			this.partColor.Text = "Цвет детали";
			this.partColor.UseVisualStyleBackColor = true;
			this.partColor.Click += new System.EventHandler(this.partColor_Click);
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.exitButton.Location = new System.Drawing.Point(250, 475);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(75, 23);
			this.exitButton.TabIndex = 2;
			this.exitButton.Text = "Выход";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
			// 
			// buildButton
			// 
			this.buildButton.Location = new System.Drawing.Point(12, 475);
			this.buildButton.Name = "buildButton";
			this.buildButton.Size = new System.Drawing.Size(75, 23);
			this.buildButton.TabIndex = 1;
			this.buildButton.Text = "Построить";
			this.buildButton.UseVisualStyleBackColor = true;
			this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
			// 
			// paramsGroupBox
			// 
			this.paramsGroupBox.Controls.Add(this.holesNumber);
			this.paramsGroupBox.Controls.Add(this.distanceAroundHoles);
			this.paramsGroupBox.Controls.Add(this.holesDiameter);
			this.paramsGroupBox.Controls.Add(this.bearingCoverDiameter);
			this.paramsGroupBox.Controls.Add(this.inDiameterCentralHole);
			this.paramsGroupBox.Controls.Add(this.holesDistance);
			this.paramsGroupBox.Controls.Add(this.outDiameterCentralHole);
			this.paramsGroupBox.Controls.Add(this.posteriorWallThickness);
			this.paramsGroupBox.Controls.Add(this.centralHoleDepth);
			this.paramsGroupBox.Controls.Add(this.rearProjection);
			this.paramsGroupBox.Controls.Add(this.borderThickness);
			this.paramsGroupBox.Controls.Add(this.frontProjection);
			this.paramsGroupBox.Controls.Add(this.coverThickness);
			this.paramsGroupBox.Controls.Add(this.label13);
			this.paramsGroupBox.Controls.Add(this.label12);
			this.paramsGroupBox.Controls.Add(this.label11);
			this.paramsGroupBox.Controls.Add(this.label10);
			this.paramsGroupBox.Controls.Add(this.label9);
			this.paramsGroupBox.Controls.Add(this.label8);
			this.paramsGroupBox.Controls.Add(this.label7);
			this.paramsGroupBox.Controls.Add(this.label6);
			this.paramsGroupBox.Controls.Add(this.label5);
			this.paramsGroupBox.Controls.Add(this.label4);
			this.paramsGroupBox.Controls.Add(this.label3);
			this.paramsGroupBox.Controls.Add(this.label2);
			this.paramsGroupBox.Controls.Add(this.label1);
			this.paramsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.paramsGroupBox.ForeColor = System.Drawing.SystemColors.Highlight;
			this.paramsGroupBox.Location = new System.Drawing.Point(0, 0);
			this.paramsGroupBox.Name = "paramsGroupBox";
			this.paramsGroupBox.Size = new System.Drawing.Size(339, 376);
			this.paramsGroupBox.TabIndex = 0;
			this.paramsGroupBox.TabStop = false;
			this.paramsGroupBox.Text = "Параметры";
			// 
			// holesNumber
			// 
			this.holesNumber.Location = new System.Drawing.Point(292, 13);
			this.holesNumber.MaxLength = 1;
			this.holesNumber.Name = "holesNumber";
			this.holesNumber.Size = new System.Drawing.Size(41, 20);
			this.holesNumber.TabIndex = 49;
			this.holesNumber.Text = "6";
			this.holesNumber.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// distanceAroundHoles
			// 
			this.distanceAroundHoles.Location = new System.Drawing.Point(292, 345);
			this.distanceAroundHoles.MaxLength = 2;
			this.distanceAroundHoles.Name = "distanceAroundHoles";
			this.distanceAroundHoles.Size = new System.Drawing.Size(41, 20);
			this.distanceAroundHoles.TabIndex = 48;
			this.distanceAroundHoles.Text = "36";
			this.distanceAroundHoles.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// holesDiameter
			// 
			this.holesDiameter.Location = new System.Drawing.Point(292, 317);
			this.holesDiameter.MaxLength = 2;
			this.holesDiameter.Name = "holesDiameter";
			this.holesDiameter.Size = new System.Drawing.Size(41, 20);
			this.holesDiameter.TabIndex = 47;
			this.holesDiameter.Text = "22";
			this.holesDiameter.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// bearingCoverDiameter
			// 
			this.bearingCoverDiameter.Location = new System.Drawing.Point(292, 289);
			this.bearingCoverDiameter.MaxLength = 3;
			this.bearingCoverDiameter.Name = "bearingCoverDiameter";
			this.bearingCoverDiameter.Size = new System.Drawing.Size(41, 20);
			this.bearingCoverDiameter.TabIndex = 46;
			this.bearingCoverDiameter.Text = "490";
			this.bearingCoverDiameter.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// inDiameterCentralHole
			// 
			this.inDiameterCentralHole.Location = new System.Drawing.Point(292, 261);
			this.inDiameterCentralHole.MaxLength = 3;
			this.inDiameterCentralHole.Name = "inDiameterCentralHole";
			this.inDiameterCentralHole.Size = new System.Drawing.Size(41, 20);
			this.inDiameterCentralHole.TabIndex = 45;
			this.inDiameterCentralHole.Text = "372";
			this.inDiameterCentralHole.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// holesDistance
			// 
			this.holesDistance.Location = new System.Drawing.Point(292, 233);
			this.holesDistance.MaxLength = 3;
			this.holesDistance.Name = "holesDistance";
			this.holesDistance.Size = new System.Drawing.Size(41, 20);
			this.holesDistance.TabIndex = 44;
			this.holesDistance.Text = "450";
			this.holesDistance.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// outDiameterCentralHole
			// 
			this.outDiameterCentralHole.Location = new System.Drawing.Point(292, 206);
			this.outDiameterCentralHole.MaxLength = 3;
			this.outDiameterCentralHole.Name = "outDiameterCentralHole";
			this.outDiameterCentralHole.Size = new System.Drawing.Size(41, 20);
			this.outDiameterCentralHole.TabIndex = 43;
			this.outDiameterCentralHole.Text = "400";
			this.outDiameterCentralHole.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// posteriorWallThickness
			// 
			this.posteriorWallThickness.Location = new System.Drawing.Point(292, 180);
			this.posteriorWallThickness.MaxLength = 2;
			this.posteriorWallThickness.Name = "posteriorWallThickness";
			this.posteriorWallThickness.Size = new System.Drawing.Size(41, 20);
			this.posteriorWallThickness.TabIndex = 42;
			this.posteriorWallThickness.Text = "14";
			this.posteriorWallThickness.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// centralHoleDepth
			// 
			this.centralHoleDepth.Location = new System.Drawing.Point(292, 151);
			this.centralHoleDepth.MaxLength = 2;
			this.centralHoleDepth.Name = "centralHoleDepth";
			this.centralHoleDepth.Size = new System.Drawing.Size(41, 20);
			this.centralHoleDepth.TabIndex = 41;
			this.centralHoleDepth.Text = "20";
			this.centralHoleDepth.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// rearProjection
			// 
			this.rearProjection.Location = new System.Drawing.Point(292, 123);
			this.rearProjection.MaxLength = 2;
			this.rearProjection.Name = "rearProjection";
			this.rearProjection.Size = new System.Drawing.Size(41, 20);
			this.rearProjection.TabIndex = 40;
			this.rearProjection.Text = "6";
			this.rearProjection.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// borderThickness
			// 
			this.borderThickness.Location = new System.Drawing.Point(292, 95);
			this.borderThickness.MaxLength = 2;
			this.borderThickness.Name = "borderThickness";
			this.borderThickness.Size = new System.Drawing.Size(41, 20);
			this.borderThickness.TabIndex = 39;
			this.borderThickness.Text = "18";
			this.borderThickness.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// frontProjection
			// 
			this.frontProjection.Location = new System.Drawing.Point(292, 67);
			this.frontProjection.MaxLength = 2;
			this.frontProjection.Name = "frontProjection";
			this.frontProjection.Size = new System.Drawing.Size(41, 20);
			this.frontProjection.TabIndex = 38;
			this.frontProjection.Text = "10";
			this.frontProjection.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// coverThickness
			// 
			this.coverThickness.Location = new System.Drawing.Point(292, 40);
			this.coverThickness.MaxLength = 2;
			this.coverThickness.Name = "coverThickness";
			this.coverThickness.Size = new System.Drawing.Size(41, 20);
			this.coverThickness.TabIndex = 37;
			this.coverThickness.Text = "34";
			this.coverThickness.Leave += new System.EventHandler(this.ParamInputLeave);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label13.Location = new System.Drawing.Point(6, 348);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(230, 13);
			this.label13.TabIndex = 22;
			this.label13.Text = "Диаметр вокруг отверстий - d1 (20 - 36 мм):";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label12.Location = new System.Drawing.Point(6, 320);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(187, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "Диаметр отверстий - d (11 - 22 мм):";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label11.Location = new System.Drawing.Point(6, 292);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(260, 13);
			this.label11.TabIndex = 20;
			this.label11.Text = "Диаметр крышки подшипника - D3 (155 - 490 мм):";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label10.Location = new System.Drawing.Point(6, 98);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(188, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Толщина окантовки - h1 (7 - 18 мм):";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label9.Location = new System.Drawing.Point(6, 126);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(156, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "Выступ сзади - h2 (3 - 10 мм):";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label8.Location = new System.Drawing.Point(6, 154);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(251, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Глубина центрального отверстия - l (10 - 20 мм):";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label7.Location = new System.Drawing.Point(6, 264);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(282, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Диаметр внутр. стенки центр. отв. - D2 (100 - 372 мм):";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label6.Location = new System.Drawing.Point(6, 209);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(280, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Диаметр внешн. стенки центр. отв. - D (110 - 400 мм):";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label5.Location = new System.Drawing.Point(6, 236);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(271, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Расстояние между отверстиями - D1 (130 - 450 мм):";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label4.Location = new System.Drawing.Point(6, 182);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(202, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Толщина задней стенки - s (6 - 14 мм):";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label3.Location = new System.Drawing.Point(6, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(162, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Выступ спереди - h (5 - 10 мм):";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label2.Location = new System.Drawing.Point(6, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Толщина крышки - H (16 - 34 мм):";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(157, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Число отверстий - n (4 или 6):";
			// 
			// BearingCoverImage
			// 
			this.BearingCoverImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BearingCoverImage.Image = ((System.Drawing.Image)(resources.GetObject("BearingCoverImage.Image")));
			this.BearingCoverImage.InitialImage = null;
			this.BearingCoverImage.Location = new System.Drawing.Point(0, 0);
			this.BearingCoverImage.Name = "BearingCoverImage";
			this.BearingCoverImage.Size = new System.Drawing.Size(575, 510);
			this.BearingCoverImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.BearingCoverImage.TabIndex = 0;
			this.BearingCoverImage.TabStop = false;
			// 
			// MainForm
			// 
			this.AcceptButton = this.buildButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.exitButton;
			this.ClientSize = new System.Drawing.Size(918, 510);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Крышка подшипника";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.additionalParamsGroupBox.ResumeLayout(false);
			this.additionalParamsGroupBox.PerformLayout();
			this.paramsGroupBox.ResumeLayout(false);
			this.paramsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.BearingCoverImage)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox paramsGroupBox;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.PictureBox BearingCoverImage;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox coverThickness;
		private System.Windows.Forms.TextBox distanceAroundHoles;
		private System.Windows.Forms.TextBox holesDiameter;
		private System.Windows.Forms.TextBox bearingCoverDiameter;
		private System.Windows.Forms.TextBox inDiameterCentralHole;
		private System.Windows.Forms.TextBox holesDistance;
		private System.Windows.Forms.TextBox outDiameterCentralHole;
		private System.Windows.Forms.TextBox posteriorWallThickness;
		private System.Windows.Forms.TextBox centralHoleDepth;
		private System.Windows.Forms.TextBox rearProjection;
		private System.Windows.Forms.TextBox borderThickness;
		private System.Windows.Forms.TextBox frontProjection;
		private System.Windows.Forms.TextBox holesNumber;
		private System.Windows.Forms.GroupBox additionalParamsGroupBox;
		private System.Windows.Forms.Button partColor;
		private System.Windows.Forms.Panel colorPanel;
		private System.Windows.Forms.TextBox angleCut;
		private System.Windows.Forms.Label label14;
    }
}

