using Mirror;
using UnityEngine;
using System.Collections.Generic;

public class PlayerDeck : NetworkBehaviour
{
    public Deck deck;
    public  List<Card> playerHand;

    protected GameManager gameManager;
    protected DiscardPile discardPile;
    protected WreckDraw wreckDraw;
    
    void Start()
    {
        gameManager = GameManager.Instance;
        discardPile = gameManager.discardPile;
        wreckDraw = gameManager.wreckDraw;

        playerHand = new List<Card>();
    }

    public void Shuffle()
    {
        deck.Shuffle(playerHand);
    }

    public void  DrawWreckCard()
    {
        playerHand.Add(wreckDraw.DrawCard());
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
