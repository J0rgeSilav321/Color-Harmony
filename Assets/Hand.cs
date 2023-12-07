using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public List<Card> cardlist = new List<Card>();
    private Deck deck;

    // Start is called before the first frame update
    public void InitHand()
    {
        deck = this.gameObject.GetComponent<Deck>();
        cardlist.AddRange(deck.drawCard(5));
    }
}
