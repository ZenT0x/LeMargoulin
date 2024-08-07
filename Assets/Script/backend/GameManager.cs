using Mirror;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class GameManager : NetworkBehaviour
{
    private static GameManager instance;
    public int numberOfWrecksCardsPerPlayer = 4;
    public List<GameObject> connectedPlayers = new List<GameObject>();

    public DiscardPile discardPile;
    public WreckDraw wreckDraw;
    public WeatherDraw weatherDraw;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    [SyncVar]
    public int numberOfPlayers = 1;

    void Start()
    {

        if (isServer)
            {
                StartCoroutine(WaitForPlayers());
            }
    }

    private IEnumerator WaitForPlayers()
    {
        yield return new WaitForSeconds(1);
        var playersConnecting = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in playersConnecting)
        {
            PlayerConnected(player);
        }
        InitializeInGame(connectedPlayers);
    }



    [Server]
    public void InitializeInGame(List<GameObject> players)
    {
        numberOfPlayers = players.Count;
        Debug.Log("Initialize Game. Number of players: " + numberOfPlayers);

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

        [Server]
    public void PlayerConnected(GameObject player)
    {
        if (!connectedPlayers.Contains(player))
        {
            connectedPlayers.Add(player);
            Debug.Log("Player" + player + "connected");
        }
    }

        [Server]
    private bool IsAllPlayersConnected()
    {
        if (connectedPlayers.Count == numberOfPlayers)
        {
            return true;
        }
        return false;
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
