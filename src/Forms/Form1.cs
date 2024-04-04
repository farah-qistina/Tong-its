using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Design;

public partial class MainForm : Form
{
    private Label cardDisplay;
    private int winner = -1; // No winner initially

    // Create an instance of Game class
    private Game game;

    public MainForm()
    {
        InitializeComponent();
        this.Size = new Size(800, 600); // Set the form size
        this.StartPosition = FormStartPosition.CenterScreen; // Center form on screen
        game = new Game();
        game.OnHandChanged += Game_OnHandChanged; // Subscribe
        UpdateDrawPileDisplay();
        UpdatePlayerLabelsStyle();
        game.DisplayHands();
        pictureBox1.Click += pictureBoxDiscardPile_Click;
        pictureBox2.Click += pictureBoxDrawPile_Click;
        callDrawBtn.Click += callDrawBtn_Click;
        Panel[] panels = { panel5,panel6, panel7, panel8, panel9, panel10, panel11, panel12, panel13, panel14, panel15, panel16 };

        // Subscribe to the click event for each panel using a loop
        foreach (Panel panel in panels)
        {
            panel.Click += Panel_Click;
        }

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

        if ((hand.GetAllCards().Count) == 0) {
            return;
        }

        int cardWidth = 71;
        int cardHeight = 96;
        int panelWidth = panel.Width - 100;

        // Calculate overlap based on the number of cards and the panel width
        int totalCardWidth = (hand.GetAllCards().Count) * cardWidth;
        int overlap = ((totalCardWidth - panelWidth) / (hand.GetAllCards().Count));
        int xOffset = panel.Width - cardWidth; // Start from the right edge of the panel

        foreach (Card card in hand.GetAllCards())
        {
            string imagePath = $"Forms/Images/{card.FaceValue}{card.Suit}.jpg";
            PictureBox cardPictureBox = new PictureBox
            {
                Width = cardWidth,
                Height = cardHeight,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile(imagePath),
                Location = new Point(xOffset, 0),
                Tag = card
            };
            cardPictureBox.Click += CardPictureBox_Click;
            panel.Controls.Add(cardPictureBox);

            // Update xOffset for the next card
            xOffset -= cardWidth - overlap;
        }
    }


    private Card selectedCard = null;
    private PictureBox selectedPictureBox = null;

    private void CardPictureBox_Click(object sender, EventArgs e)
    {
        PictureBox clickedCardPictureBox = sender as PictureBox;
        Card clickedCard = clickedCardPictureBox.Tag as Card;

        // Get the current player index from the Game class
        int currentPlayerIndex = game.GetCurrentPlayerIndex();

        int cardPlayerIndex = game.FindPlayer(clickedCard);

        if (currentPlayerIndex == cardPlayerIndex && clickedCardPictureBox != null && clickedCardPictureBox.Tag is Card)
        {
            clickedCard = (Card)clickedCardPictureBox.Tag;

            // Toggle selection if the same card is clicked again
            if (selectedPictureBox == clickedCardPictureBox)
            {
                clickedCardPictureBox.BorderStyle = BorderStyle.None;
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

                selectedPictureBox = clickedCardPictureBox;
                selectedPictureBox.BorderStyle = BorderStyle.Fixed3D;
                selectedCard = clickedCard;
            }
        }
        else
        {
            // Ignore the selection or show a message, as the card does not belong to the current player
            cardDisplay.Text = "Wait for yor turn!";
        }
    }

    // Piles

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

            if (game.IsDrawPileEmpty())
            {
                cardDisplay.Text = "Deck is empty. Calculating winner...";
                winner = game.CalcScore();
                ShowWinner(winner);
            } else {
                int currentPlayer = game.GetCurrentPlayerIndex();
                game.SetCurrentPlayerIndex((currentPlayer + 1) % game.GetPlayers(currentPlayer));
                UpdatePlayerLabelsStyle();
            }
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("An unexpected error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void pictureBoxDiscardPile_Click(object sender, EventArgs e)
    {
        if (selectedCard != null && selectedPictureBox != null)
        {
            game.DiscardCard(selectedCard); // Discard the selected card

            bool emptyHand = game.IsCurrentPlayerHandEmpty();

            // Update the UI for all players and the discard pile
            game.DisplayHands();
            UpdateDiscardPileDisplay();

            if (emptyHand)
            {
                // Perform actions based on the hand being empty
                cardDisplay.Text = "Tongit!";
                winner = game.GetCurrentPlayerIndex();
                ShowWinner(winner);
            } else {
                cardDisplay.Text = "Card discarded.";
            }

            // Deselect the card
            selectedPictureBox.BorderStyle = BorderStyle.None;
            selectedPictureBox = null;
            selectedCard = null;     
        }
    }

    private void UpdateDrawPileDisplay()
    {
        // Check if the draw pile is empty or not
        if (!game.IsDrawPileEmpty())
        {
            // If not empty, display a generic back of card image
            pictureBox2.Image = Image.FromFile("Forms/Images/cardback.jpg");
        }
        else
        {
            // If empty, clear the PictureBox or display a specific "empty" image
            pictureBox2.Image = null;
        }
    }

    private void UpdateDiscardPileDisplay()
    {
        Card topDiscard = game.GetTopDiscard();
        if (topDiscard != null)
        {
            string imagePath = $"Forms/Images/{topDiscard.FaceValue}{topDiscard.Suit}.jpg";
            pictureBox1.Image = Image.FromFile(imagePath);
        }
    }

    // Melds

    // To keep score of how many cards are in each meld
    int panel5Count, panel6Count, panel7Count, panel8Count, panel9Count, panel10Count, panel11Count, panel12Count, panel13Count, panel14Count, panel15Count, panel16Count = 0;


    private void Panel_Click(object sender, EventArgs e) {
    if (selectedCard != null && selectedPictureBox != null)
            {
                game.RemoveCard(selectedCard); // Remove the selected card

                bool emptyHand = game.IsCurrentPlayerHandEmpty();

                // Update the UI for all players and the discard pile
                game.DisplayHands();

                if (emptyHand)
                {
                    // Perform actions based on the hand being empty
                    cardDisplay.Text = "Tongit!";
                    winner = game.GetCurrentPlayerIndex();
                    ShowWinner(winner);
                } else {
                    cardDisplay.Text = "Card added to meld.";
                }

                Panel panel = (Panel)sender;
                int cardWidth = 71;
                int cardHeight = 96;
                int panelWidth = panel.Width;
                int currentCount = 0;
                int xOffset;

                // Use a switch case to increment panel counts
                switch (panel.Name)
                {
                    case "panel5":
                        panel5Count++;
                        currentCount = panel5Count;
                        break;
                    case "panel6":
                        panel6Count++;
                        currentCount = panel6Count;
                        break;
                    case "panel7":
                        panel7Count++;
                        currentCount = panel7Count;
                        break;
                    case "panel8":
                        panel8Count++;
                        currentCount = panel8Count;
                        break;
                    case "panel9":
                        panel9Count++;
                        currentCount = panel9Count;
                        break;
                    case "panel10":
                        panel10Count++;
                        currentCount = panel10Count;
                        break;
                    case "panel11":
                        panel11Count++;
                        currentCount = panel11Count;
                        break;
                    case "panel12":
                        panel12Count++;
                        currentCount = panel12Count;
                        break;
                    case "panel13":
                        panel13Count++;
                        currentCount = panel13Count;
                        break;
                    case "panel14":
                        panel13Count++;
                        currentCount = panel14Count;
                        break;
                    case "panel15":
                        panel13Count++;
                        currentCount = panel15Count;
                        break;
                    case "panel16":
                        panel13Count++;
                        currentCount = panel16Count;
                        break;
                }

                int overlap = 55;
                xOffset = panel.Width - cardWidth;
                if (currentCount > 1) {
                    xOffset = (panel.Width - cardWidth - ((cardWidth - overlap) * (currentCount - 1)));
                }

                string imagePath = $"Forms/Images/{selectedCard.FaceValue}{selectedCard.Suit}.jpg";
                PictureBox cardPictureBox = new PictureBox
                {
                    Width = cardWidth,
                    Height = cardHeight,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Image.FromFile(imagePath),
                    Location = new Point(xOffset, 0),
                    Tag = selectedCard
                };
                panel.Controls.Add(cardPictureBox);
                
                // Deselect the card
                selectedPictureBox.BorderStyle = BorderStyle.None;
                selectedPictureBox = null;
                selectedCard = null;
            }
    }


    // Next player

    private void UpdatePlayerLabelsStyle()
    {
        int currentPlayerIndex = game.GetCurrentPlayerIndex();

        // Reset all labels to regular font
        label2.Font = new Font(label2.Font, FontStyle.Regular);
        label1.Font = new Font(label1.Font, FontStyle.Regular);
        label3.Font = new Font(label3.Font, FontStyle.Regular);

        // Set the current player's label to bold and underline
        switch (currentPlayerIndex)
        {
            case 0:
                label2.Font = new Font(label2.Font, FontStyle.Bold | FontStyle.Underline);
                break;
            case 1:
                label1.Font = new Font(label1.Font, FontStyle.Bold | FontStyle.Underline);
                break;
            case 2:
                label3.Font = new Font(label3.Font, FontStyle.Bold | FontStyle.Underline);
                break;
        }
        cardDisplay.Text = $"Player {currentPlayerIndex + 1}'s turn.";
    }

    // Call Draw
    private void callDrawBtn_Click(object sender, EventArgs e)
    {
        cardDisplay.Text = "Call draw! Calculating winner...";
        winner = game.CalcScore();
        ShowWinner(winner);
    }

    // Winner
    private void ShowWinner(int winnerPlayerIndex)
    {
        label9.Text = $"The winner is Player {winner + 1}!";
        panel4.Visible = true;
        panel4.BringToFront(); // Ensure the panel is on top of other controls
    }
}