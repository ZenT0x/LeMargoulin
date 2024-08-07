using Mirror;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;

public class GameManager : NetworkBehaviour
{
    public List<GameObject> connectedPlayers = new List<GameObject>();

    // EN : Variables that point to the different objects
    // FR : Variables qui pointent vers les différents objets
    public DiscardPile discardPile;
    public WreckDraw wreckDraw;
    public WeatherDraw weatherDraw;
    private static GameManager instance;

    // EN : Varaibles of the game
    // FR : Variables du jeu
    [HideInInspector]
    public int numberOfWrecksCardsPerPlayer = 4;

    [SyncVar] 
    public int numberOfWood;

    [SyncVar]
    public int numberOfFood;

    [SyncVar]
    public int numberOfWater;

    [SyncVar]
    public int numberOfPlayers;

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

    void Start()
    {
        if (isServer)
            {
                // EN : We wait a little bit to make sure that all players are connected
                // FR : On attend un peu pour être sûr que tous les joueurs sont connectés
                Invoke("FindPlayerAndLaunch", 0.1f); 
            }
    }
    private void FindPlayerAndLaunch()
    {
        var playersFound = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in playersFound)
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

    void Update(){

    }
}
