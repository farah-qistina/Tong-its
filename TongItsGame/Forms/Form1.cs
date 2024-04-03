using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

public partial class MainForm : Form
{
    private Button buttonShuffle;
    private Button buttonDeal;
    private Label cardDisplay;
    private Panel panelCards;

    // Create an instance of your Game class
    private Game game;

    public MainForm()
    {
        InitializeComponent();
        this.Size = new Size(800, 600); // Set the form size
        this.StartPosition = FormStartPosition.CenterScreen; // Center form on screen
        game = new Game();
        game.OnHandChanged += Game_OnHandChanged;
        game.DisplayHands();
        // UpdateDrawPileDisplay();
        makeMeldBtn.Click += drawCardButton_Click;

    }

    private void Game_OnHandChanged(int playerIndex)
    {
        // Call the method to update the UI based on which player's hand changed
        DisplayPlayerHandInLayout(playerIndex);
    }

    private void DisplayPlayerHandInLayout(int index)
    {
        Panel panel;

        switch (index)
        {
            case 0:
                panel = panel1;
                break;
            case 1:
                panel = panel2;
                break;
            case 2:
                panel = panel3;
                break;
            default:
                throw new ArgumentException("Invalid panel index", nameof(index));
        }
        panel.Controls.Clear(); // Clear existing controls/cards

        List<Hand> hands = game.GetAllHands();
        Hand hand = hands[index];

        int cardWidth = 71;
        int cardHeight = 96;
        int xOffset = panel.Width - cardWidth;
        int overlap = 42; // The amount each card will overlap the previous one

        foreach (Card card in hand.GetAllCards())
        {
            string imagePath = $"Forms/Images/{card.FaceValue}{card.Suit}.jpg";
            PictureBox cardPictureBox = new PictureBox
            {
                Width = cardWidth,
                Height = cardHeight,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(imagePath), // Assuming image exists
                Location = new Point(xOffset, 0) // Set the location with an offset
            };
            panel.Controls.Add(cardPictureBox);

            xOffset -= (cardWidth - overlap); // Move the offset for the next card
        }
    }


    private void drawCardButton_Click(object sender, EventArgs e)
    {
        // Call the DrawCard() method and display the result
        // string card = game.DrawCard();
        // Assuming you have a Label or TextBox named cardDisplay
        string imagePath = "Forms/Images/AceClubs.jpg";

        // Create a new PictureBox
        PictureBox cardPictureBox = new PictureBox
        {
            Width = 100, // Set the width (adjust as needed)
            Height = 140, // Set the height (adjust as needed)
            Location = new Point(10, 10), // Set the initial location on the form (adjust as needed)
            SizeMode = PictureBoxSizeMode.StretchImage, // Set the size mode to stretch the image to fit the PictureBox
            BorderStyle = BorderStyle.Fixed3D // Optional: adds a border around the PictureBox
        };

        // Check if the image file exists before attempting to load it
        if (File.Exists(imagePath))
        {
            // Load the image into the PictureBox
            cardDisplay.Text = "Image present";
            cardPictureBox.Image = Image.FromFile(imagePath);
        }
        else
        {
            // Log or handle the case where the image file does not exist
            cardDisplay.Text = "Not present";
            // Optionally, you could set a default image or leave the PictureBox empty
        }

        // Add the PictureBox to the form's controls
        this.Controls.Add(cardPictureBox);

        // Adjust the PictureBox location or other properties as needed
        // For example, to add multiple PictureBoxes without overlap, you might increment the Location for each new card
    }

    private void UpdateDiscardPileDisplay()
    {
        // Assuming you have a PictureBox for the discard pile
        var topDiscard = game.GetTopDiscard(); // Implement this method in Game
        if (topDiscard != null)
        {
            string imagePath = $"Forms/Images/{topDiscard.FaceValue}{topDiscard.Suit}.jpg";
            pictureBox1.Image = Image.FromFile(imagePath);
        }
    }

    // private void UpdateDrawPileDisplay()
    // {
    //     // Check if the draw pile is empty or not
    //     if (!game.IsDrawPileEmpty()) // You might need to implement this method in your Game class
    //     {
    //         // If not empty, display a generic back of card image
    //         string imagePath = "cardback.jpg"; // Replace with the path to your card back image
    //         pictureBox2.Image = Image.FromFile(imagePath);
    //     }
    //     else
    //     {
    //         // If empty, you might want to clear the PictureBox or display a specific "empty" image
    //         pictureBox2.Image = null; // Or set to an "empty pile" image
    //     }
    // }

    private void drawPilePictureBox_Click(object sender, EventArgs e)
    {
        // Handle drawing a card from the draw pile
    }

    private void discardPilePictureBox_Click(object sender, EventArgs e)
    {
        // Handle picking up the discard pile, if your game rules allow it
    }

    private void buttonShuffle_Click(object sender, EventArgs e)
    {
        // Add code to shuffle the deck
        cardDisplay.Text = "Deck shuffled!";
    }

    private void buttonDeal_Click(object sender, EventArgs e)
    {
        // Add code to deal cards to the hands
        cardDisplay.Text = "Cards dealt!";
    }
}