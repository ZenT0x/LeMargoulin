using Mirror;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : NetworkBehaviour
{
    public PlayerDeck playerDeckPrefab;
    public DiscardPile discardPilePrefab;
    public WreckDraw wreckDrawPrefab;
    public WeatherDraw weatherDrawPrefab;

    private PlayerDeck playerDeck;
    private DiscardPile discardPile;
    private WreckDraw wreckDraw;
    private WeatherDraw weatherDraw;

    [SyncVar]
    public int numberOfPlayers;

    [Server]
    public void Initialize(List<GameObject> players)
    {
        numberOfPlayers = players.Count;

        playerDeck = Instantiate(playerDeckPrefab);
        discardPile = Instantiate(discardPilePrefab);
        wreckDraw = Instantiate(wreckDrawPrefab);
        weatherDraw = Instantiate(weatherDrawPrefab);

        NetworkServer.Spawn(playerDeck.gameObject);
        NetworkServer.Spawn(discardPile.gameObject);
        NetworkServer.Spawn(wreckDraw.gameObject);
        NetworkServer.Spawn(weatherDraw.gameObject);

        playerDeck.discardPile = discardPile;

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
            playerDeck.UseCard(card);
        }
        else
        {
            playerDeck.CmdUseCard(card);
        }
    }

    public Card RetrieveCardFromDiscard()
    {
        return discardPile.RetrieveCard();
    }
}
