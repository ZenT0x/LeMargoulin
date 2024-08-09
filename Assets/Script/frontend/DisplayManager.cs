using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    public TextMeshProUGUI textWater;
    public TextMeshProUGUI textWood;
    public TextMeshProUGUI textFood;
    public TextMeshProUGUI textTime;

    protected GameManager gameManager;

    void Start()
    {
        // EN : Wait for the GameManager to be initialized to avoid null reference
        // FR : Attend que le GameManager soit initialisé pour éviter les références nulles
        Invoke("getInstanceOfGameManager", 0.1f);
    }

    void getInstanceOfGameManager()
    {
        // TODO: Find a better way to get the GameManager because it will cause code duplication
        gameManager = GameManager.Instance;
    }

    void Update()
    {   
        textFood.text = "Food: " + gameManager.numberOfFood.ToString();
        textWater.text = "Water: " + gameManager.numberOfWater.ToString();
        textWood.text = "Wood: " + gameManager.numberOfWood.ToString();
        textTime.text = "Day: " + gameManager.GetDayOfGame().ToString() + "   " + gameManager.GetHoursOfDay().ToString() + ":" + gameManager.GetMinutesOfDay().ToString();
    }
}
