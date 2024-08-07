using UnityEngine;

public class WeatherDraw : Deck
{
    public string resourcePath = "Cards/objects/weather";

    void Start()
    {
        Initialize(resourcePath);
    }

    public void Initialize(string path)
    {
        Debug.Log($"Chargement des cartes weather depuis le chemin : {path}");
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
        // EN : Use the base class method to draw a card
        // FR : Utilise la méthode de la classe de base pour tirer une carte
        Card drawnCard = base.DrawCard();
        Debug.Log($"Tirage de carte météo : {drawnCard.cardName}");
        return drawnCard;
    }
}
