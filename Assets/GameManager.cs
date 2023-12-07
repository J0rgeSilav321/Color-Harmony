using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Deck deck;
    private Hand hand;
    public GameObject cardPrefab;

    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = this.transform.Find("UI").gameObject.GetComponent<Canvas>();

        hand = this.gameObject.GetComponent<Hand>();
        deck = this.gameObject.GetComponent<Deck>();
        deck.InitDeck();
        hand.InitHand();
        foreach(Card c in hand.cardlist){
            Instantiate(cardPrefab, new Vector3(0,0,1),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
