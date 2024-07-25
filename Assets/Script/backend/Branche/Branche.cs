using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branche : MonoBehaviour
{
    GameObject branche;
    public bool isTrap = false;
    public GameObject Canva;
    // Start is called before the first frame update
    void Start()
    {
        branche = gameObject;
    }

    public void OnButtonPress()
    {
        if (isTrap)
        {
            Debug.Log("Perdu");
            branche.SetActive(false);
            Canva.SetActive(false);
        }
        else
        {
            Debug.Log("Gagné");
            branche.SetActive(false);
        }
    }
}
