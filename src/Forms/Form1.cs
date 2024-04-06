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
        Panel[] panels = { player1, player2, player3, player1meld1, player1meld2, player1meld3, player1meld4, player2meld1, player2meld2, player2meld3, player2meld4, player3meld1, player3meld2, player3meld3, player3meld4 };

        // Subscribe to the click event for each panel using a loop
        foreach (Panel panel in panels)
        {
            panel.Click += Panel_Click;
        }
        game.PanelChanged += Game_PanelChanged; // Subscribe
        UpdateDrawPileDisplay();
        UpdatePlayerLabelsStyle();
        game.DisplayHands();
        pictureBox1.Click += pictureBoxDiscardPile_Click;
        pictureBox2.Click += pictureBoxDrawPile_Click;
        callDrawBtn.Click += callDrawBtn_Click;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        // This line attempts to set the focus away from any button/control to the form itself.
        // It's a workaround and might not work in all scenarios as expected because Windows Forms
        // generally expects a control to have focus.
        this.ActiveControl = null; // Attempt to remove focus from all controls
    }

    // Hands and melds

    private void Game_PanelChanged(int panelIndex)
    {
        // Call the method to update the UI based on which panel hand changed
        DisplayPanels(panelIndex);
    }

    private void DisplayPanels(int index)
    {
        Panel panel;

        switch (index)
        {
            case 0:
                panel = player1;
                break;
            case 1:
                panel = player2;
                break;
            case 2:
                panel = player3;
                break;
            case 3:
                panel = player1meld1;
                break;
            case 4:
                panel = player1meld2;
                break;
            case 5:
                panel = player1meld3;
                break;
            case 6:
                panel = player1meld4;
                break;
            case 7:
                panel = player2meld1;
                break;
            case 8:
                panel = player2meld2;
                break;
            case 9:
                panel = player2meld3;
                break;
            case 10:
                panel = player2meld4;
                break;
            case 11:
                panel = player3meld1;
                break;
            case 12:
                panel = player3meld2;
                break;
            case 13:
                panel = player3meld3;
                break;
            case 14:
                panel = player3meld4;
                break;
            default:
                throw new ArgumentException("Invalid panel index", nameof(index));
        }
        panel.Controls.Clear(); // Clear existing controls/cards

        List<Hand> hands = game.GetAllHands();
        Hand hand = hands[index];

        if ((hand.GetAllCards().Count) == 0)
        {
            return;
        }

        int cardWidth = 71;
        int cardHeight = 96;
        int panelWidth = panel.Width - 80;

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
            if (index > -1 && index < game.GetPlayers()) {
                cardPictureBox.Click += CardPictureBox_Click;
            }
            panel.Controls.Add(cardPictureBox);

            // Update xOffset for the next card
            xOffset -= cardWidth - overlap;
        }
    }

    // Cards

    private Card selectedCard = null;
    private PictureBox selectedPictureBox = null;
    private List<Card> selectedCards = new List<Card>();
    private List<PictureBox> selectedPictureBoxes = new List<PictureBox>();


    private void CardPictureBox_Click(object sender, EventArgs e)
    {
        PictureBox clickedPictureBox = sender as PictureBox;
        if (clickedPictureBox != null && clickedPictureBox.Tag is Card clickedCard)
        {
            // Get the current player index from the Game class
            int currentPlayerIndex = game.GetCurrentPlayerIndex();
            int panelIndex = game.FindPlayer(clickedCard);

            if (panelIndex > -1 && panelIndex < game.GetPlayers() && currentPlayerIndex != panelIndex)
            {
                // Ignore the selection or show a message, as the card does not belong to the current player
                cardDisplay.Text = "Wait for your turn!";
                return;
            }

            if (selectedCards.Contains(clickedCard)) {
                clickedPictureBox.BorderStyle = BorderStyle.None;
                selectedPictureBoxes.Remove(clickedPictureBox);
                selectedCards.Remove(clickedCard);
                selectedPictureBox = null;
                selectedCard = null;
            } else if (!selectedCards.Contains(clickedCard)) {
                clickedPictureBox.BorderStyle = BorderStyle.Fixed3D;
                selectedPictureBoxes.Add(clickedPictureBox);
                selectedCards.Add(clickedCard);
                selectedPictureBox = clickedPictureBox;
                selectedCard = clickedCard;
            }           
            
        }
    }


    // Piles

    private void pictureBoxDrawPile_Click(object sender, EventArgs e)
    {
        try
        {
            // Draw a card for the current player
            game.DrawCard(game.GetCurrentPlayerIndex());

            // Update the UI for all players' hands since the current player's hand has changed
            game.DisplayHands();

            // Update the draw pile display to reflect the new state after drawing a card
            UpdateDrawPileDisplay();

            if (game.IsDrawPileEmpty())
            {
                cardDisplay.Text = "Deck is empty. Calculating winner...";
                winner = game.CalcScore();
                ShowWinner(winner);
            }
            else
            {
                int currentPlayer = game.GetCurrentPlayerIndex();
                game.SetCurrentPlayerIndex((currentPlayer + 1) % game.GetPlayers());
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
            if (selectedCards.Count > 1) {
                cardDisplay.Text = "Please select only 1 card to discard.";
                return;
            }
            game.DiscardCard(selectedCard); // Discard the selected card

            bool emptyHand = game.IsCurrentPlayerHandEmpty(game.GetCurrentPlayerIndex());

            // Update the UI for all players and the discard pile
            game.DisplayHands();
            UpdateDiscardPileDisplay();

            if (emptyHand)
            {
                // Perform actions based on the hand being empty
                cardDisplay.Text = "Tongit!";
                winner = game.GetCurrentPlayerIndex();
                ShowWinner(winner);
            }
            else
            {
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

    private void Panel_Click(object sender, EventArgs e)
    {

        if (selectedCard != null && selectedPictureBox != null)
        {
            int index = -1;

            Panel panel = (Panel)sender;

            switch (panel.Name)
            {
                case "player1":
                    index = 0;
                    break;
                case "player2":
                    index = 1;
                    break;
                case "player3":
                    index = 2;
                    break;
                case "player1meld1":
                    index = 3;
                    break;
                case "player1meld2":
                    index = 4;
                    break;
                case "player1meld3":
                    index = 5;
                    break;
                case "player1meld4":
                    index = 6;
                    break;
                case "player2meld1":
                    index = 7;
                    break;
                case "player2meld2":
                    index = 8;
                    break;
                case "player2meld3":
                    index = 9;
                    break;
                case "player2meld4":
                    index = 10;
                    break;
                case "player3meld1":
                    index = 11;
                    break;
                case "player3meld2":
                    index = 12;
                    break;
                case "player3meld3":
                    index = 13;
                    break;
                case "player3meld4":
                    index = 14;
                    break;
            }

            int originalHand = game.FindPlayer(selectedCard);

            if (index >= 3 && index <= 14) {
                if (selectedCards.Count > 1)
                {
                    if (game.CanFormMeld(selectedCards))
                    {
                        // If the cards can form a meld, proceed to add them to the panel
                        foreach (var card in selectedCards)
                        {
                            game.RemoveCard(card, game.FindPlayer(card)); // Assuming this method adjusts for removing a card from the original hand
                            game.AddCardToHand(card, index);
                        }
                        game.orderCardsFromKingToAce(index);

                        cardDisplay.Text = "Meld added!";
                    }
                    else
                    {
                        cardDisplay.Text = "Not a meld.";
                        // cardDisplay.Text = $"{selectedCards.Count}";
                        return; // Exit the method to prevent adding the cards to the meld panel
                    }

                    // Deselect the cards after moving them
                    foreach (var pictureBox in selectedPictureBoxes)
                    {
                        pictureBox.BorderStyle = BorderStyle.None;
                    }
                    selectedPictureBoxes.Clear();
                    selectedCards.Clear();
                } else if (selectedCards.Count == 1 && !game.IsCurrentPlayerHandEmpty(index)) {
                    if (game.FitsInMeld(selectedCard, index)) {
                        game.RemoveCard(selectedCard, originalHand); // Remove the selected card
                        game.AddCardToHand(selectedCard, index);
                        cardDisplay.Text = "Added to meld.";
                    }
                } else {
                    cardDisplay.Text = "Doesn't fit the meld.";
                }

                game.DisplayHands();

                bool emptyHand = game.IsCurrentPlayerHandEmpty(game.GetCurrentPlayerIndex());

                if (emptyHand)
                {
                    // Perform actions based on the hand being empty
                    cardDisplay.Text = "Tongit!";
                    winner = game.GetCurrentPlayerIndex();
                    ShowWinner(winner);
                }
            }

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

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }
}