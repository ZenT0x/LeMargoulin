using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbyManager : NetworkBehaviour
{
    public GameObject owner;
    public List<GameObject> players = new List<GameObject>();
    public GameObject LocalPlayer;

    public GameObject startButton;


    void Start()
    {
        startButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var allPlayers = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in allPlayers)
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
}
