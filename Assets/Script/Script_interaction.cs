using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_interaction : MonoBehaviour
{
    private bool IsPlayerOnTrigger = false;
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
            Transform childTransform = transform.GetChild(0);
            childTransform.gameObject.SetActive(false);
        }
    }
}
