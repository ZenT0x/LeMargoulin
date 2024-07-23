using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class BrancheManager : MonoBehaviour
{
    public GameObject[] tasBranche = new GameObject[5];
    public int nbAlea;
    GameObject brancheActue;
    // Start is called before the first frame update
    void Start()
    {
        ActiverBranche();
    }

    void OnEnable()
    {
        ActiverBranche();
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
}
