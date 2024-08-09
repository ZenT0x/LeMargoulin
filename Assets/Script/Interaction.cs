using UnityEngine;

public class Interaction : MonoBehaviour
{
    protected BrancheManager brancheManager;
    public bool canPlay = true;
    private bool isBois = false;
    public int nbBoisActue = 0;
    private bool isBouffe = false;
    public GameObject childBois;
    public GameObject childBouffe;

    void Start()
    {
        Invoke("getInstanceOfBrancheManager", 0.1f);
    }

    void getInstanceOfBrancheManager()
    {
        brancheManager = BrancheManager.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (isBois)
            {
                if (childBois.activeSelf)
                {
                    // Si le joueur quitte l'interaction volontairement
                    brancheManager.JeuxFinis();
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
            childBois = col.transform.Find("CanvasBois")?.gameObject; // Remplacez par le vrai nom du Canvas
        }
        if (col.CompareTag("HitBoxBouffe") && canPlay)
        {
            isBouffe = true;
            childBouffe = col.transform.Find("CanvasBouffe")?.gameObject; // Remplacez par le vrai nom du Canvas
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("HitBoxBois"))
        {
            // Appelle JeuxFinis quand le joueur quitte la zone
            if (col.CompareTag("HitBoxBois"))
            {
                brancheManager.JeuxFinis();
            }

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
