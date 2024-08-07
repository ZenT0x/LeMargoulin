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
        Invoke("getInstanceOfGameManager", 0.1f);
        
        textWater = GameObject.Find("Text Water").GetComponent<TextMeshProUGUI>();
        textWood = GameObject.Find("Text Wood").GetComponent<TextMeshProUGUI>();
        textFood = GameObject.Find("Text Food").GetComponent<TextMeshProUGUI>();
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
