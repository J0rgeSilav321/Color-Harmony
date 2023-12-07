using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Deck : MonoBehaviour
{

    private List<Card> cardlist = new List<Card>();
    private List<Card> remainingCards = new List<Card>();

    public void InitDeck(){
        //(cardlist.Add()       LOAD FROM JSON/CSV
        //TEMP FIX
        cardlist.Add(new SingleColorCard(Color.blue));
        cardlist.Add(new SingleColorCard(Color.red));
        cardlist.Add(new SingleColorCard(Color.yellow));
        cardlist.Add(new SingleColorCard(Color.green));
        cardlist.Add(new SingleColorCard(Color.cyan));
        cardlist.Add(new SingleColorCard(Color.white));
        cardlist.Add(new SingleColorCard(Color.magenta));
        remainingCards.AddRange(cardlist);
    }

    public List<Card> drawCard(int x){
        List<Card> ret = new List<Card>();
        Debug.Log(cardlist.Count-x);
        for (int i = remainingCards.Count - x; i < remainingCards.Count; ++i)
        {
            Debug.Log(remainingCards[i].ToString());
            ret.Add(remainingCards[i]);
        }
        remainingCards = remainingCards.Except(ret).ToList();
        return ret;
    }

    public void shuffleDeck(){

    }
}
