using System.Collections.Generic;
using UnityEngine;

public class WreckDraw : Deck
{
    public string resourcePath = "Cards/objects/wreck";

    void Start()
    {
        Initialize(resourcePath);
    }

    public void Initialize(string path)
    {
        Debug.Log($"Chargement des cartes wreck depuis le chemin : {path}");
        Card[] loadedCards = Resources.LoadAll<Card>(path);
        Debug.Log($"Nombre de cartes chargées : {loadedCards.Length}");
        if (loadedCards.Length == 0)
        {
            Debug.LogError($"Aucune carte trouvée dans le chemin : {path}");
            return;
        }

        foreach (Card card in loadedCards)
        {
            AddCard(card);
        }
        Shuffle(cards);
        Debug.Log($"{loadedCards.Length} cartes chargées depuis {path} et mélangées.");
    }

    public override Card DrawCard()
    {
        // EN : Use the base class method to draw a card
        // FR : Utilise la méthode de la classe de base pour tirer une carte
        Card drawnCard = base.DrawCard();
        Debug.Log($"Tirage de carte épave : {drawnCard.cardName}");
        return drawnCard;
    }
}

