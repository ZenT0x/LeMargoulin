using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
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
                childBois.SetActive(!childBois.activeSelf); // Toggle the active state
            }
            if (isBouffe)
            {
                childBouffe.SetActive(!childBouffe.activeSelf); // Toggle the active state
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HitBoxBois"))
        {
            isBois = true;
            childBois = col.transform.Find("CanvasBois")?.gameObject; // Replace with the actual child name
        }
        if (col.CompareTag("HitBoxBouffe"))
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
        }
        if (col.CompareTag("HitBoxBouffe"))
        {
            isBouffe = false;
            childBouffe.SetActive(false);
        }
    }
}
