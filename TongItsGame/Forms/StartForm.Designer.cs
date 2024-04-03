namespace TongItsGame.Forms
{
    partial class StartForm
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
            button1 = new Button();
            cardDisplay = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(298, 276);
            button1.Name = "button1";
            button1.Size = new Size(424, 113);
            button1.TabIndex = 0;
            button1.Text = "Start Game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cardDisplay
            // 
            cardDisplay.Anchor = AnchorStyles.Top;
            cardDisplay.Font = new Font("Segoe UI", 14F);
            cardDisplay.Location = new Point(281, 600);
            cardDisplay.Name = "cardDisplay";
            cardDisplay.Size = new Size(477, 51);
            cardDisplay.TabIndex = 3;
            cardDisplay.Text = "Welcome to Tong-Its!";
            cardDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(974, 729);
            Controls.Add(cardDisplay);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "StartForm";
            Text = "StartForm";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label cardDisplay;
    }
}