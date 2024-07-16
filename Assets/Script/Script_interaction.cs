using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_interaction : MonoBehaviour
{
    private bool IsPlayerOnTrigger = false;
    public GameObject Siphano;
    // Start is called before the first frame update
    void Start()
    {
        Siphano.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerOnTrigger)
        {
            if (Input.GetKeyDown("e"))
            {
                if (Siphano.activeSelf)
                {
                    Siphano.SetActive(false);
                }
                else
                {
                    Siphano.SetActive(true);
                    Debug.Log("Ca marche");
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IsPlayerOnTrigger = true;
            Transform childTransform = transform.GetChild(0);
            childTransform.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IsPlayerOnTrigger = false;
            Siphano.SetActive(false);
            Transform childTransform = transform.GetChild(0);
            childTransform.gameObject.SetActive(false);
        }
    }
}
