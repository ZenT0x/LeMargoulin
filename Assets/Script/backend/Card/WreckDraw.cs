using UnityEngine;

public class WreckDraw : Deck
{
    public override Card DrawCard()
    {
        Debug.Log("Tirage de carte d'épave");
        return base.DrawCard();
    }
}
