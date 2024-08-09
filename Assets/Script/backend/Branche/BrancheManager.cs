using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class BrancheManager : MonoBehaviour
{
    protected GameManager gameManager;
    public GameObject[] tasBranche = new GameObject[5];
    public int nbAlea;
    GameObject brancheActue;
    public Interaction interaction;
    public int nbBranche;
    private BrancheManager() { }
    private static BrancheManager instance;
    public static BrancheManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BrancheManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("getInstanceOfGameManager", 0.1f);
        nbBranche = 1;
        ActiverBranche();
    }

    void OnEnable()
    {
        Invoke("getInstanceOfGameManager", 0.1f);
        nbBranche = 1;
        ActiverBranche();
    }
    public void JeuxFinis()
    {
        Debug.Log("J'ai ramassé tout ce BOIS FDP DE TA GRAND MERE LA PUTE");
        gameManager.numberOfWood = gameManager.numberOfWood + nbBranche;
    }

    void ActiverBranche()
    {
        nbAlea = UnityEngine.Random.Range(0, 5);
        for (int i = 0; i < 5; i++)
        {
            brancheActue = tasBranche[i];
            Branche brancheScript = brancheActue.GetComponent<Branche>();
            brancheScript.isTrap = false;
            if (i == nbAlea)
            {
                brancheScript.isTrap = true;
            }
            brancheActue.SetActive(true);
        }
    }

    void getInstanceOfGameManager()
    {
        gameManager = GameManager.Instance;
    }
}
