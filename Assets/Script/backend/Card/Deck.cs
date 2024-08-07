using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public virtual void Shuffle(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public virtual Card DrawCard()
    {
        Debug.Log("Drawing card");
        if (cards.Count == 0) {
            Debug.LogError("No cards left in deck");
            return null;
        }
        Card drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }

    public virtual void AddCard(Card card)
    {
        cards.Add(card);
    }

    public virtual void ResetDeck(List<Card> newCards)
    {
        Debug.Log("Resetting deck");
        cards = new List<Card>(newCards);
        Shuffle(cards);
    }
}
