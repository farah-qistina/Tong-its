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

    private void InitializeComponent()
    {
        cardDisplay = new Label();
        callDrawBtn = new Button();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        panel1 = new Panel();
        panel2 = new Panel();
        panel3 = new Panel();
        pictureBox1 = new PictureBox();
        label4 = new Label();
        pictureBox2 = new PictureBox();
        label5 = new Label();
        label6 = new Label();
        label7 = new Label();
        label8 = new Label();
        panel4 = new Panel();
        label9 = new Label();
        panel6 = new Panel();
        panel5 = new Panel();
        panel9 = new Panel();
        panel11 = new Panel();
        panel12 = new Panel();
        panel14 = new Panel();
        panel7 = new Panel();
        panel15 = new Panel();
        panel8 = new Panel();
        panel10 = new Panel();
        panel13 = new Panel();
        panel16 = new Panel();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        panel4.SuspendLayout();
        SuspendLayout();
        // 
        // cardDisplay
        // 
        cardDisplay.Font = new Font("Segoe UI", 12F);
        cardDisplay.ImageAlign = ContentAlignment.MiddleLeft;
        cardDisplay.Location = new Point(27, 9);
        cardDisplay.Name = "cardDisplay";
        cardDisplay.Size = new Size(469, 95);
        cardDisplay.TabIndex = 2;
        cardDisplay.Text = "Welcome to Tong-Its!";
        cardDisplay.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // callDrawBtn
        // 
        callDrawBtn.Anchor = AnchorStyles.Top;
        callDrawBtn.Location = new Point(799, 43);
        callDrawBtn.Name = "callDrawBtn";
        callDrawBtn.Size = new Size(145, 35);
        callDrawBtn.TabIndex = 6;
        callDrawBtn.Text = "Call Draw";
        callDrawBtn.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Location = new Point(685, 734);
        label1.Name = "label1";
        label1.Size = new Size(98, 32);
        label1.TabIndex = 8;
        label1.Text = "Player 2";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(177, 736);
        label2.Name = "label2";
        label2.Size = new Size(98, 32);
        label2.TabIndex = 9;
        label2.Text = "Player 1";
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Top;
        label3.AutoSize = true;
        label3.Location = new Point(461, 137);
        label3.Name = "label3";
        label3.Size = new Size(98, 32);
        label3.TabIndex = 10;
        label3.Text = "Player 3";
        label3.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panel1
        // 
        panel1.Location = new Point(38, 613);
        panel1.Name = "panel1";
        panel1.Size = new Size(400, 120);
        panel1.TabIndex = 11;
        // 
        // panel2
        // 
        panel2.Location = new Point(536, 611);
        panel2.Name = "panel2";
        panel2.Size = new Size(400, 120);
        panel2.TabIndex = 12;
        // 
        // panel3
        // 
        panel3.Location = new Point(288, 14);
        panel3.Name = "panel3";
        panel3.Size = new Size(393, 120);
        panel3.TabIndex = 13;
        // 
        // pictureBox1
        // 
        pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        pictureBox1.Location = new Point(509, 323);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(71, 96);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 14;
        pictureBox1.TabStop = false;
        // 
        // label4
        // 
        label4.Location = new Point(595, 323);
        label4.Name = "label4";
        label4.Size = new Size(102, 78);
        label4.TabIndex = 15;
        label4.Text = "Discard Pile";
        label4.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pictureBox2
        // 
        pictureBox2.Location = new Point(393, 323);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(71, 96);
        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox2.TabIndex = 16;
        pictureBox2.TabStop = false;
        // 
        // label5
        // 
        label5.Location = new Point(285, 323);
        label5.Name = "label5";
        label5.Size = new Size(102, 78);
        label5.TabIndex = 17;
        label5.Text = "Draw Pile";
        label5.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // label6
        // 
        label6.Anchor = AnchorStyles.Top;
        label6.AutoSize = true;
        label6.Location = new Point(38, 323);
        label6.Name = "label6";
        label6.Size = new Size(79, 32);
        label6.TabIndex = 18;
        label6.Text = "Melds";
        // 
        // label7
        // 
        label7.Anchor = AnchorStyles.Top;
        label7.AutoSize = true;
        label7.Location = new Point(858, 319);
        label7.Name = "label7";
        label7.Size = new Size(79, 32);
        label7.TabIndex = 19;
        label7.Text = "Melds";
        label7.TextAlign = ContentAlignment.TopCenter;
        // 
        // label8
        // 
        label8.Anchor = AnchorStyles.Top;
        label8.AutoSize = true;
        label8.Location = new Point(461, 271);
        label8.Name = "label8";
        label8.Size = new Size(79, 32);
        label8.TabIndex = 20;
        label8.Text = "Melds";
        // 
        // panel4
        // 
        panel4.Anchor = AnchorStyles.None;
        panel4.BackColor = SystemColors.ControlLightLight;
        panel4.BorderStyle = BorderStyle.FixedSingle;
        panel4.Controls.Add(label9);
        panel4.Location = new Point(289, 269);
        panel4.Name = "panel4";
        panel4.Size = new Size(393, 200);
        panel4.TabIndex = 22;
        panel4.Visible = false;
        // 
        // label9
        // 
        label9.Anchor = AnchorStyles.None;
        label9.AutoSize = true;
        label9.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold);
        label9.Location = new Point(51, 81);
        label9.Name = "label9";
        label9.Size = new Size(547, 65);
        label9.TabIndex = 0;
        label9.Text = "The winner is Player1!";
        label9.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panel6
        // 
        panel6.BorderStyle = BorderStyle.FixedSingle;
        panel6.Location = new Point(816, 373);
        panel6.Name = "panel6";
        panel6.Size = new Size(119, 96);
        panel6.TabIndex = 14;
        // 
        // panel5
        // 
        panel5.BorderStyle = BorderStyle.FixedSingle;
        panel5.Location = new Point(691, 373);
        panel5.Name = "panel5";
        panel5.Size = new Size(119, 96);
        panel5.TabIndex = 15;
        // 
        // panel9
        // 
        panel9.BorderStyle = BorderStyle.FixedSingle;
        panel9.Location = new Point(163, 373);
        panel9.Name = "panel9";
        panel9.Size = new Size(119, 96);
        panel9.TabIndex = 24;
        // 
        // panel11
        // 
        panel11.BorderStyle = BorderStyle.FixedSingle;
        panel11.Location = new Point(489, 172);
        panel11.Name = "panel11";
        panel11.Size = new Size(119, 96);
        panel11.TabIndex = 28;
        // 
        // panel12
        // 
        panel12.BorderStyle = BorderStyle.FixedSingle;
        panel12.Location = new Point(364, 172);
        panel12.Name = "panel12";
        panel12.Size = new Size(119, 96);
        panel12.TabIndex = 27;
        // 
        // panel14
        // 
        panel14.BorderStyle = BorderStyle.FixedSingle;
        panel14.Location = new Point(534, 488);
        panel14.Name = "panel14";
        panel14.Size = new Size(196, 96);
        panel14.TabIndex = 17;
        // 
        // panel7
        // 
        panel7.BorderStyle = BorderStyle.FixedSingle;
        panel7.Location = new Point(739, 488);
        panel7.Name = "panel7";
        panel7.Size = new Size(196, 96);
        panel7.TabIndex = 18;
        // 
        // panel15
        // 
        panel15.BorderStyle = BorderStyle.FixedSingle;
        panel15.Location = new Point(38, 373);
        panel15.Name = "panel15";
        panel15.Size = new Size(119, 96);
        panel15.TabIndex = 24;
        // 
        // panel8
        // 
        panel8.BorderStyle = BorderStyle.FixedSingle;
        panel8.Location = new Point(38, 488);
        panel8.Name = "panel8";
        panel8.Size = new Size(196, 96);
        panel8.TabIndex = 18;
        // 
        // panel10
        // 
        panel10.BorderStyle = BorderStyle.FixedSingle;
        panel10.Location = new Point(242, 488);
        panel10.Name = "panel10";
        panel10.Size = new Size(196, 96);
        panel10.TabIndex = 19;
        // 
        // panel13
        // 
        panel13.BorderStyle = BorderStyle.FixedSingle;
        panel13.Location = new Point(614, 172);
        panel13.Name = "panel13";
        panel13.Size = new Size(196, 96);
        panel13.TabIndex = 29;
        // 
        // panel16
        // 
        panel16.BorderStyle = BorderStyle.FixedSingle;
        panel16.Location = new Point(163, 172);
        panel16.Name = "panel16";
        panel16.Size = new Size(196, 96);
        panel16.TabIndex = 30;
        // 
        // MainForm
        // 
        BackColor = SystemColors.GradientInactiveCaption;
        ClientSize = new Size(974, 754);
        Controls.Add(panel16);
        Controls.Add(panel13);
        Controls.Add(panel10);
        Controls.Add(panel8);
        Controls.Add(panel15);
        Controls.Add(panel7);
        Controls.Add(panel14);
        Controls.Add(panel4);
        Controls.Add(panel11);
        Controls.Add(panel12);
        Controls.Add(panel9);
        Controls.Add(panel5);
        Controls.Add(panel6);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(pictureBox2);
        Controls.Add(label4);
        Controls.Add(pictureBox1);
        Controls.Add(panel3);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(callDrawBtn);
        Controls.Add(cardDisplay);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "MainForm";
        Text = "Tong-Its Game";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        panel4.ResumeLayout(false);
        panel4.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private Button callDrawBtn;
    private Label label1;
    private Label label2;
    private Label label3;
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private PictureBox pictureBox1;
    private Label label4;
    private PictureBox pictureBox2;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Panel panel4;
    private Label label9;
    private Panel panel6;
    private Panel panel5;
    private Panel panel9;
    private Panel panel11;
    private Panel panel12;
    private Panel panel14;
    private Panel panel7;
    private Panel panel15;
    private Panel panel8;
    private Panel panel10;
    private Panel panel13;
    private Panel panel16;
}
