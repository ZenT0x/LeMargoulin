using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyManager : NetworkBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    public GameObject owner;
    public GameObject LocalPlayer;
    public GameObject startButton;

    void Start()
    {
        // EN : Hide the start button for all players at the beginning
        // FR : Cache le bouton de démarrage pour tous les joueurs au début
        startButton.SetActive(false);
        Invoke("UselessFunction", 0.1f);
    }

    private void UselessFunction() {}
 
    void Update()
    {
        var PlayerFoundInLobby = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in PlayerFoundInLobby)
        {
            if (!players.Contains(player))
            {
                players.Add(player);
                owner = players[0];
            }
        }
        // If the owner of the lobby is the local player, show the start button
        if (owner == NetworkClient.localPlayer.gameObject)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }
    public void StartGame()
    {
        if (isServer)
        {
            RpcStartGame();
        }
    }

    [ClientRpc]
    void RpcStartGame()
    {
        if (isServer)
        {
            // Change scene for all players
            NetworkManager.singleton.ServerChangeScene("Game");
        }
    }
}
