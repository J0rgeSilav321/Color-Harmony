using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cardPrefab;
    [SerializeField]
    public List<Card> deck = new List<Card>();
    public Transform[] cardSlots;

    public bool[] availableCardSlots;
    public int numberOfPlayers = 2; // Change this to the desired number of players
    private List<CardController> selectedCards = new List<CardController>();
    
    public int currentTurn = 1; // Initialize with the first player
    private const int maxSelectedCards = 3;
    void Start()
    {
        // Draw three cards when the game starts if the hand is empty
        
            DrawThreeCardsToFirstSlots();
        

        // Set the initial turn to player 1
        currentTurn = 1;
    }


   public void SubmitSelectedCards()
{
    int selectedCount = selectedCards.Count;
    

    if (selectedCount > 0 && selectedCount <= maxSelectedCards)
    {
        Debug.Log("Submitted " + selectedCount + " selected card(s!");

        foreach (var card in selectedCards)
        {
            int index = card.handIndex;
            card.Deactivate();
             Debug.Log(index) ;
             int hands = card.handIndex;
             Debug.Log(hands);
            // Use the hand index as the selected index
            availableCardSlots[index] = true;
        }
      
        // Clear the selected cards list
        selectedCards.Clear();
    }
    else
    {
        Debug.Log("Please select exactly 3 cards before submitting.");
    }
}



    void Update()
    {
        // Example: Check if the hand is empty during the update loop
        
        if (AreAllSlotsAvailable())
    {
        DrawThreeCardsToFirstSlots();
        Debug.Log("All slots are available. Drawing three cards...");
        
    }
    }


    bool AreAllSlotsAvailable()
{
    // Check if all slots in the availableCardSlots array are true
    for (int i = 0; i < availableCardSlots.Length; ++i)
    {
        if (!availableCardSlots[i])
        {
            // If any slot is not available, return false
            return false;
        }
    }

    // If all slots are available, return true
    return true;
}











     public bool IsCardSelected(CardController card)
    {
        return selectedCards.Contains(card);
    }

    // Method to handle card selection
    public void SelectCard(CardController card, bool isSelected)
    {
        if (isSelected)
        {
            if (selectedCards.Count < maxSelectedCards)
            {
                selectedCards.Add(card);
            }
            else
            {
                isSelected = false; // Prevent selecting more than the limit
            }
        }
        else
        {
            selectedCards.Remove(card);
        }
    }


    public void DrawCard()
    {
        if (deck.Count >= 1)
        {
            Card randCard = deck[Random.Range(0, deck.Count)];
            
            // Check if there are available slots
            bool foundSlot = false;

            for (int i = 0; i < availableCardSlots.Length; ++i)
            {
                if (availableCardSlots[i])
                {
                    foundSlot = true;

                    // Assuming Card has a GameObject property
                    randCard.gameObject.SetActive(true);
                    randCard.transform.position = cardSlots[i].position;
                     // Get the CardController from the drawn card
                CardController cardController = randCard.GetComponent<CardController>();

                // Check if cardController is not null before accessing properties
                if (cardController != null)
                {
                    // Set the hand index directly on the CardController
                    cardController.handIndex = i;
                }
                    availableCardSlots[i] = false;
                    deck.Remove(randCard);
                    break;
                }
            }

       

            // Switch to the next turn
          //  SwitchTurn();
        }
    }

    private void DrawThreeCardsToFirstSlots()
    {
        for (int i = 0; i < Mathf.Min(3, cardSlots.Length); ++i)
        {
            if (i < deck.Count)
            {

                
                Card randCard = deck[i];
                CardController cardController = randCard.GetComponent<CardController>();
                // Assuming Card has a GameObject property
                randCard.gameObject.SetActive(true);

                randCard.transform.position = cardSlots[i].position;
                   if (cardController != null)
                {
                    // Set the hand index directly on the CardController
                    cardController.handIndex = i;
                }


                availableCardSlots[i] = false;
            }
        }

        // Make other two slots available
        for (int i = 3; i < availableCardSlots.Length; ++i)
        {
            availableCardSlots[i] = true;
        }

        // Remove drawn cards from the deck
        deck.RemoveRange(0, Mathf.Min(3, deck.Count));
    }

    public void SwitchTurn()
    {
        // Increment the turn counter and reset it to 1 if it exceeds the number of players
        currentTurn = (currentTurn % numberOfPlayers) + 1;
        Debug.Log("Switched to Turn " + currentTurn);
    }

    public bool IsHandEmpty()
    {
        return System.Array.TrueForAll(availableCardSlots, slot => !slot);
    }


    





}


