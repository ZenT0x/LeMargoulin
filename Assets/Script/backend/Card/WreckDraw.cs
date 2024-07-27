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
        Debug.Log($"Tentative de chargement des cartes depuis le chemin : {path}");
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
        Shuffle();
        Debug.Log($"{loadedCards.Length} cartes chargées depuis {path} et mélangées.");
    }

    public override Card DrawCard()
    {
        Card drawnCard = base.DrawCard();
        Debug.Log($"Tirage de carte épave : {drawnCard.cardName}");
        return drawnCard;
    }
}

