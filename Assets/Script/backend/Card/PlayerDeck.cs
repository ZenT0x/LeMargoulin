using Mirror;
using UnityEngine;
using System.Collections.Generic;

public class PlayerDeck : NetworkBehaviour
{
    private Deck deck = new Deck();
    public  List<Card> playerHand = new List<Card>();

    public DiscardPile discardPile;
    public WreckDraw wreckDraw;

    void Start()
    {

    }



    public override void OnStartServer()
    {
        base.OnStartServer();
    }

    public void Shuffle()
    {
        deck.Shuffle();
    }

    public void  DrawWreckCard()
    {
        playerHand.Add(deck.DrawCard());
        Debug.Log("Tirage de carte épave");
    }

    [Command]
    public void CmdUseCard(Card card)
    {
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
    }

    public void AddCard(Card card)
    {
        deck.AddCard(card);
    }

    public void ResetDeck(List<Card> newCards)
    {
        deck.ResetDeck(newCards);
    }
}
