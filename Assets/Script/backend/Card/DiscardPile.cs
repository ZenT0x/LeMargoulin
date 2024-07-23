using UnityEngine;
using System.Collections.Generic;

public class DiscardPile : MonoBehaviour
{
    private List<Card> discardPile = new List<Card>();

    public void AddCard(Card card)
    {
        discardPile.Add(card);
        Debug.Log($"Carte ajoutée à la pile de défausse : {card.cardName}");
    }

    public Card RetrieveCard()
    {
        if (discardPile.Count == 0)
        {
            Debug.Log("La pile de défausse est vide.");
            return null;
        }

        Card retrievedCard = discardPile[0];
        discardPile.RemoveAt(0);
        Debug.Log($"Carte récupérée de la pile de défausse : {retrievedCard.cardName}");
        return retrievedCard;
    }

    public List<Card> RetrieveAllCards()
    {
        List<Card> allCards = new List<Card>(discardPile);
        discardPile.Clear();
        Debug.Log("Toutes les cartes ont été récupérées de la pile de défausse.");
        return allCards;
    }
}
