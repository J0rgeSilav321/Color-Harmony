using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleColorCard : Card
{
    private CardType cardType;
    private Color color;

    public SingleColorCard(Color color): base(CardType.SingleColor){
        this.cardType=CardType.SingleColor;
        this.color=color;
    }
    

}