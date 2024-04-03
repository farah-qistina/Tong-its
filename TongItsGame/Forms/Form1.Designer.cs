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
        makeMeldBtn = new Button();
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
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        SuspendLayout();
        // 
        // cardDisplay
        // 
        cardDisplay.Location = new Point(74, 258);
        cardDisplay.Name = "cardDisplay";
        cardDisplay.Size = new Size(200, 30);
        cardDisplay.TabIndex = 2;
        cardDisplay.Text = "Welcome to Tong-Its!";
        cardDisplay.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // makeMeldBtn
        // 
        makeMeldBtn.Anchor = AnchorStyles.Top;
        makeMeldBtn.Location = new Point(406, 628);
        makeMeldBtn.Name = "makeMeldBtn";
        makeMeldBtn.Size = new Size(145, 35);
        makeMeldBtn.TabIndex = 5;
        makeMeldBtn.Text = "Make Meld";
        makeMeldBtn.UseVisualStyleBackColor = true;
        // 
        // callDrawBtn
        // 
        callDrawBtn.Anchor = AnchorStyles.Top;
        callDrawBtn.Location = new Point(406, 669);
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
        label1.Location = new Point(711, 734);
        label1.Name = "label1";
        label1.Size = new Size(98, 32);
        label1.TabIndex = 8;
        label1.Text = "Player 2";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(139, 736);
        label2.Name = "label2";
        label2.Size = new Size(98, 32);
        label2.TabIndex = 9;
        label2.Text = "Player 1";
        // 
        // label3
        // 
        label3.Anchor = AnchorStyles.Top;
        label3.AutoSize = true;
        label3.Location = new Point(442, 148);
        label3.Name = "label3";
        label3.Size = new Size(98, 32);
        label3.TabIndex = 10;
        label3.Text = "Player 3";
        label3.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panel1
        // 
        panel1.Location = new Point(0, 613);
        panel1.Name = "panel1";
        panel1.Size = new Size(400, 120);
        panel1.TabIndex = 11;
        // 
        // panel2
        // 
        panel2.Location = new Point(562, 611);
        panel2.Name = "panel2";
        panel2.Size = new Size(400, 120);
        panel2.TabIndex = 12;
        // 
        // panel3
        // 
        panel3.Location = new Point(278, 25);
        panel3.Name = "panel3";
        panel3.Size = new Size(393, 120);
        panel3.TabIndex = 13;
        // 
        // pictureBox1
        // 
        pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        pictureBox1.Location = new Point(502, 341);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(71, 96);
        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox1.TabIndex = 14;
        pictureBox1.TabStop = false;
        // 
        // label4
        // 
        label4.Location = new Point(588, 341);
        label4.Name = "label4";
        label4.Size = new Size(102, 78);
        label4.TabIndex = 15;
        label4.Text = "Discard Pile";
        label4.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pictureBox2
        // 
        pictureBox2.Location = new Point(386, 341);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new Size(71, 96);
        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        pictureBox2.TabIndex = 16;
        pictureBox2.TabStop = false;
        // 
        // label5
        // 
        label5.Location = new Point(278, 341);
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
        label6.Location = new Point(139, 578);
        label6.Name = "label6";
        label6.Size = new Size(98, 32);
        label6.TabIndex = 18;
        label6.Text = "Player 3";
        // 
        // label7
        // 
        label7.Anchor = AnchorStyles.Top;
        label7.AutoSize = true;
        label7.Location = new Point(711, 576);
        label7.Name = "label7";
        label7.Size = new Size(98, 32);
        label7.TabIndex = 19;
        label7.Text = "Player 3";
        // 
        // label8
        // 
        label8.Anchor = AnchorStyles.Top;
        label8.AutoSize = true;
        label8.Location = new Point(442, 294);
        label8.Name = "label8";
        label8.Size = new Size(98, 32);
        label8.TabIndex = 20;
        label8.Text = "Player 3";
        // 
        // MainForm
        // 
        BackColor = SystemColors.InactiveCaption;
        ClientSize = new Size(974, 754);
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
        Controls.Add(makeMeldBtn);
        Controls.Add(cardDisplay);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "MainForm";
        Text = "Tong-Its Game";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Button makeMeldBtn;
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
}
