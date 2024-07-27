using Mirror;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : NetworkBehaviour
{
    public int numberOfWrecksCardsPerPlayer = 4;

    public List<GameObject> allPlayers;

    public DiscardPile discardPile;
    public WreckDraw wreckDraw;
    public WeatherDraw weatherDraw;

    [SyncVar]
    public int numberOfPlayers;

    void Start()
    {
        if (isServer)
        {
            allPlayers = GameObject.FindGameObjectsWithTag("Player").ToList();
            Initialize(allPlayers);
        }
    }

    [Server]
    public void Initialize(List<GameObject> players)
    {
        numberOfPlayers = players.Count;

        foreach (GameObject player in players)
        {
            PlayerDeck playerDeck = player.GetComponent<PlayerDeck>();
            for (int i = 0; i < numberOfWrecksCardsPerPlayer; i++)
            {
                playerDeck.DrawWreckCard();
            }
        }
       



        StartGame(players);
    }

    [Server]
    void StartGame(List<GameObject> players)
    {

    }

    public void UseCard(Card card)
    {
        if (isServer)
        {
            //playerDeck.UseCard(card);
        }
        else
        {
            //playerDeck.CmdUseCard(card);
        }
    }

    public Card RetrieveCardFromDiscard()
    {
        return discardPile.RetrieveCard();
    }
}
