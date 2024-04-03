using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

public partial class MainForm : Form
{
    private Label cardDisplay;

    // Create an instance of your Game class
    private Game game;

    public MainForm()
    {
        InitializeComponent();
        this.Size = new Size(800, 600); // Set the form size
        this.StartPosition = FormStartPosition.CenterScreen; // Center form on screen
        game = new Game();
        game.OnHandChanged += Game_OnHandChanged; // Subscribe
        game.UpdateDrawPile += UpdateDrawPileDisplay;
        game.StartGame();
        pictureBox1.Click += pictureBoxDiscardPile_Click;
        pictureBox2.Click += pictureBoxDrawPile_Click;

    }

    // Hand

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
        int overlap = 45; // The amount each card will overlap the previous one

        foreach (Card card in hand.GetAllCards())
        {
            string imagePath = $"Forms/Images/{card.FaceValue}{card.Suit}.jpg";
            PictureBox cardPictureBox = new PictureBox
            {
                Width = cardWidth,
                Height = cardHeight,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(imagePath), // Assuming image exists
                Location = new Point(xOffset, 0), // Set the location with an offset
                Tag = card // Tag the PictureBox with its corresponding Card object
            };
            cardPictureBox.Click += CardPictureBox_Click;
            panel.Controls.Add(cardPictureBox);

            xOffset -= (cardWidth - overlap); // Move the offset for the next card
        }
    }

    // Piles

    private Card selectedCard = null;
    private PictureBox selectedPictureBox = null;

    private void CardPictureBox_Click(object sender, EventArgs e)
    {
        var pictureBox = sender as PictureBox;
        if (pictureBox != null && pictureBox.Tag is Card)
        {
            var clickedCard = (Card)pictureBox.Tag;

            // Toggle selection if the same card is clicked again
            if (selectedPictureBox == pictureBox)
            {
                pictureBox.BorderStyle = BorderStyle.None;
                selectedPictureBox = null;
                selectedCard = null;
            }
            else
            {
                // Update previously selected PictureBox, if any
                if (selectedPictureBox != null)
                {
                    selectedPictureBox.BorderStyle = BorderStyle.None;
                }

                selectedPictureBox = pictureBox;
                selectedPictureBox.BorderStyle = BorderStyle.Fixed3D;
                selectedCard = clickedCard;
            }
        }
    }

    private void pictureBoxDrawPile_Click(object sender, EventArgs e)
    {
        try
        {
            // Draw a card for the current player
            game.DrawCard();
            
            // Update the UI for all players' hands since the current player's hand has changed
            game.DisplayHands();
            
            // Update the draw pile display to reflect the new state after drawing a card
            UpdateDrawPileDisplay();
        }
        catch (InvalidOperationException ex)
        {
            // You can handle exceptions here, for example, if there are no cards left in the draw pile
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            // Generic exception handling, could log or display a message
            MessageBox.Show("An unexpected error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void pictureBoxDiscardPile_Click(object sender, EventArgs e)
    {
        if (selectedCard != null && selectedPictureBox != null)
        {
            game.DiscardCard(selectedCard); // Discard the selected card

            // Update the UI for all players and the discard pile
            game.DisplayHands();
            UpdateDiscardPileDisplay();

            // Deselect the card
            selectedPictureBox.BorderStyle = BorderStyle.None;
            selectedPictureBox = null;
            selectedCard = null;
        }
    }

    private void UpdateDrawPileDisplay()
    {
        // Check if the draw pile is empty or not
        if (!game.IsDrawPileEmpty()) // You might need to implement this method in your Game class
        {
            // If not empty, display a generic back of card image
            pictureBox2.Image = Image.FromFile("Forms/Images/cardback.jpg");
        }
        else
        {
            // If empty, you might want to clear the PictureBox or display a specific "empty" image
            pictureBox2.Image = null; // Or set to an "empty pile" image
        }
    }

    private void UpdateDiscardPileDisplay()
    {
        // Assuming you have a PictureBox for the discard pile
        Card topDiscard = game.GetTopDiscard(); // Implement this method in Game
        if (topDiscard != null)
        {
            string imagePath = $"Forms/Images/{topDiscard.FaceValue}{topDiscard.Suit}.jpg";
            pictureBox1.Image = Image.FromFile(imagePath);
        }
    }

    // Next player

    private void UpdatePlayerLabelsStyle()
    {
        // Assume currentPlayerIndex is accessible; if not, make it available from the Game class
        int currentPlayerIndex = game.GetCurrentPlayerIndex(); // You might need to implement this method in your Game class

        // Reset all labels to regular font
        label2.Font = new Font(label2.Font, FontStyle.Regular);
        label1.Font = new Font(label1.Font, FontStyle.Regular);
        label3.Font = new Font(label3.Font, FontStyle.Regular);

        // Set the current player's label to bold
        switch (currentPlayerIndex)
        {
            case 0:
                label2.Font = new Font(label2.Font, FontStyle.Bold);
                break;
            case 1:
                label1.Font = new Font(label1.Font, FontStyle.Bold);
                break;
            case 2:
                label3.Font = new Font(label3.Font, FontStyle.Bold);
                break;
        }
    }
}