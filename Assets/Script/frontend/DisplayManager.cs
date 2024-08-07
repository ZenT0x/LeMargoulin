using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public TextMeshProUGUI textWater;
    public TextMeshProUGUI textWood;
    public TextMeshProUGUI textFood;

    protected GameManager gameManager;

    void Start()
    {
        // EN : Wait for the GameManager to be initialized
        // FR : Attend que le GameManager soit initialisé
        Invoke("getInstanceOfGameManager", 0.1f);
    }

    void getInstanceOfGameManager()
    {
        gameManager = GameManager.Instance;
    }

    void Update()
    {   
        textFood.text = "Food: " + gameManager.numberOfFood.ToString();
        textWater.text = "Water: " + gameManager.numberOfWater.ToString();
        textWood.text = "Wood: " + gameManager.numberOfWood.ToString();
    }
}
