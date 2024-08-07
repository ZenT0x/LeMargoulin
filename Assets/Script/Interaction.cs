using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private bool canPlay = true;
    private bool isBois = false;
    private bool isBouffe = false;
    public GameObject childBois;
    public GameObject childBouffe;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (isBois)
            {
                if (childBois.activeSelf)
                {
                    childBois.SetActive(false);
                    canPlay = false;
                }
                else if (canPlay)
                {
                    childBois.SetActive(true);
                }
            }
            if (isBouffe)
            {
                if (childBouffe.activeSelf)
                {
                    childBouffe.SetActive(false);
                    canPlay = false;
                }
                else if (canPlay)
                {
                    childBouffe.SetActive(true);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HitBoxBois") && canPlay)
        {
            isBois = true;
            childBois = col.transform.Find("CanvasBois")?.gameObject; // Replace with the actual child name
        }
        if (col.CompareTag("HitBoxBouffe") && canPlay)
        {
            isBouffe = true;
            childBouffe = col.transform.Find("CanvasBouffe")?.gameObject; // Replace with the actual child name
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("HitBoxBois"))
        {
            isBois = false;
            childBois.SetActive(false);
            canPlay = false;
        }
        if (col.CompareTag("HitBoxBouffe"))
        {
            isBouffe = false;
            childBouffe.SetActive(false);
            canPlay = false;
        }
    }
}
