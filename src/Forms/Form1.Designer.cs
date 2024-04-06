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
        player1 = new Panel();
        player2 = new Panel();
        player3 = new Panel();
        pictureBox1 = new PictureBox();
        label4 = new Label();
        pictureBox2 = new PictureBox();
        label5 = new Label();
        label6 = new Label();
        label7 = new Label();
        label8 = new Label();
        panel4 = new Panel();
        label9 = new Label();
        player2meld4 = new Panel();
        player2meld3 = new Panel();
        player1meld4 = new Panel();
        player3meld3 = new Panel();
        player3meld2 = new Panel();
        player2meld1 = new Panel();
        player2meld2 = new Panel();
        player1meld3 = new Panel();
        player1meld1 = new Panel();
        player1meld2 = new Panel();
        player3meld4 = new Panel();
        player3meld1 = new Panel();
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
        callDrawBtn.Location = new Point(756, 43);
        callDrawBtn.Name = "callDrawBtn";
        callDrawBtn.Size = new Size(180, 35);
        callDrawBtn.TabIndex = 6;
        callDrawBtn.Text = "Call Draw";
        callDrawBtn.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Location = new Point(680, 722);
        label1.Name = "label1";
        label1.Size = new Size(98, 32);
        label1.TabIndex = 8;
        label1.Text = "Player 2";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(184, 722);
        label2.Name = "label2";
        label2.Size = new Size(98, 32);
        label2.TabIndex = 9;
        label2.Text = "Player 1";
        label2.Click += label2_Click;
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
        // player1
        // 
        player1.BorderStyle = BorderStyle.Fixed3D;
        player1.Location = new Point(38, 613);
        player1.Name = "player1";
        player1.Size = new Size(400, 96);
        player1.TabIndex = 11;
        // 
        // player2
        // 
        player2.BorderStyle = BorderStyle.Fixed3D;
        player2.Location = new Point(536, 611);
        player2.Name = "player2";
        player2.Size = new Size(400, 96);
        player2.TabIndex = 12;
        // 
        // player3
        // 
        player3.BorderStyle = BorderStyle.Fixed3D;
        player3.Location = new Point(288, 14);
        player3.Name = "player3";
        player3.Size = new Size(393, 96);
        player3.TabIndex = 13;
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
        label6.Location = new Point(38, 338);
        label6.Name = "label6";
        label6.Size = new Size(79, 32);
        label6.TabIndex = 18;
        label6.Text = "Melds";
        // 
        // label7
        // 
        label7.Anchor = AnchorStyles.Top;
        label7.AutoSize = true;
        label7.Location = new Point(857, 338);
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
        // player2meld4
        // 
        player2meld4.BorderStyle = BorderStyle.FixedSingle;
        player2meld4.Location = new Point(816, 373);
        player2meld4.Name = "player2meld4";
        player2meld4.Size = new Size(119, 96);
        player2meld4.TabIndex = 14;
        // 
        // player2meld3
        // 
        player2meld3.BorderStyle = BorderStyle.FixedSingle;
        player2meld3.Location = new Point(691, 373);
        player2meld3.Name = "player2meld3";
        player2meld3.Size = new Size(119, 96);
        player2meld3.TabIndex = 15;
        // 
        // player1meld4
        // 
        player1meld4.BorderStyle = BorderStyle.FixedSingle;
        player1meld4.Location = new Point(163, 373);
        player1meld4.Name = "player1meld4";
        player1meld4.Size = new Size(119, 96);
        player1meld4.TabIndex = 24;
        // 
        // player3meld3
        // 
        player3meld3.BorderStyle = BorderStyle.FixedSingle;
        player3meld3.Location = new Point(489, 172);
        player3meld3.Name = "player3meld3";
        player3meld3.Size = new Size(119, 96);
        player3meld3.TabIndex = 28;
        // 
        // player3meld2
        // 
        player3meld2.BorderStyle = BorderStyle.FixedSingle;
        player3meld2.Location = new Point(364, 172);
        player3meld2.Name = "player3meld2";
        player3meld2.Size = new Size(119, 96);
        player3meld2.TabIndex = 27;
        // 
        // player2meld1
        // 
        player2meld1.BorderStyle = BorderStyle.FixedSingle;
        player2meld1.Location = new Point(534, 488);
        player2meld1.Name = "player2meld1";
        player2meld1.Size = new Size(196, 96);
        player2meld1.TabIndex = 17;
        // 
        // player2meld2
        // 
        player2meld2.BorderStyle = BorderStyle.FixedSingle;
        player2meld2.Location = new Point(739, 488);
        player2meld2.Name = "player2meld2";
        player2meld2.Size = new Size(196, 96);
        player2meld2.TabIndex = 18;
        // 
        // player1meld3
        // 
        player1meld3.BorderStyle = BorderStyle.FixedSingle;
        player1meld3.Location = new Point(38, 373);
        player1meld3.Name = "player1meld3";
        player1meld3.Size = new Size(119, 96);
        player1meld3.TabIndex = 24;
        // 
        // player1meld1
        // 
        player1meld1.BorderStyle = BorderStyle.FixedSingle;
        player1meld1.Location = new Point(38, 488);
        player1meld1.Name = "player1meld1";
        player1meld1.Size = new Size(196, 96);
        player1meld1.TabIndex = 18;
        // 
        // player1meld2
        // 
        player1meld2.BorderStyle = BorderStyle.FixedSingle;
        player1meld2.Location = new Point(242, 488);
        player1meld2.Name = "player1meld2";
        player1meld2.Size = new Size(196, 96);
        player1meld2.TabIndex = 19;
        // 
        // player3meld4
        // 
        player3meld4.BorderStyle = BorderStyle.FixedSingle;
        player3meld4.Location = new Point(614, 172);
        player3meld4.Name = "player3meld4";
        player3meld4.Size = new Size(196, 96);
        player3meld4.TabIndex = 29;
        // 
        // player3meld1
        // 
        player3meld1.BorderStyle = BorderStyle.FixedSingle;
        player3meld1.Location = new Point(163, 172);
        player3meld1.Name = "player3meld1";
        player3meld1.Size = new Size(196, 96);
        player3meld1.TabIndex = 30;
        // 
        // MainForm
        // 
        BackColor = SystemColors.GradientInactiveCaption;
        ClientSize = new Size(974, 754);
        Controls.Add(player3meld1);
        Controls.Add(player3meld4);
        Controls.Add(player1meld2);
        Controls.Add(player1meld1);
        Controls.Add(player1meld3);
        Controls.Add(player2meld2);
        Controls.Add(player2meld1);
        Controls.Add(panel4);
        Controls.Add(player3meld3);
        Controls.Add(player3meld2);
        Controls.Add(player1meld4);
        Controls.Add(player2meld3);
        Controls.Add(player2meld4);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(pictureBox2);
        Controls.Add(label4);
        Controls.Add(pictureBox1);
        Controls.Add(player3);
        Controls.Add(player2);
        Controls.Add(player1);
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
    private Panel player1;
    private Panel player2;
    private Panel player3;
    private PictureBox pictureBox1;
    private Label label4;
    private PictureBox pictureBox2;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Panel panel4;
    private Label label9;
    private Panel player2meld4;
    private Panel player2meld3;
    private Panel player1meld4;
    private Panel player3meld3;
    private Panel player3meld2;
    private Panel player2meld1;
    private Panel player2meld2;
    private Panel player1meld3;
    private Panel player1meld1;
    private Panel player1meld2;
    private Panel player3meld4;
    private Panel player3meld1;
}
