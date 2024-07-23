using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private bool IsPlayerOnTrigger = false;
    public GameObject Canva;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerOnTrigger)
        {
            if (Input.GetKeyDown("e"))
            {
                Canva.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IsPlayerOnTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IsPlayerOnTrigger = false;
        }
    }
}
