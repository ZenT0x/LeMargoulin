using Mirror;
using UnityEngine;
using System.Collections.Generic;

/*public class PlayerDeck : Deck
{
    private List<Card> playerHand = new List<Card>();
    public DiscardPile discardPile;

    public override Card DrawCard()
    {
        Debug.Log("Tirage d'une carte");
        Card drawnCard = base.DrawCard();
        if (drawnCard != null)
        {
            playerHand.Add(drawnCard);
        }
        return drawnCard;
    }*/

/*[Command]
public void CmdUseCard(Card card)
{   
    Debug.Log("Utilisation de la carte en réseau");
    UseCard(card);
}

[Server]
public void UseCard(Card card)
{
    if (playerHand.Contains(card))
    {
        Debug.Log($"Utilisation de la carte : {card.cardName}");
        playerHand.Remove(card);
        discardPile.AddCard(card);
    }
    else
    {
        Debug.Log("La carte n'est pas dans la main du joueur");
    }
}*/
//}
