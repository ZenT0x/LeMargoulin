using UnityEngine;

public class Branche : MonoBehaviour
{
    public BrancheManager BrancheManager;
    GameObject branche;
    public bool isTrap = false;
    public GameObject Canva;

    void Start()
    {
        branche = gameObject;
    }

    public void OnButtonPress()
    {
        if (isTrap)
        {
            Debug.Log("Perdu");

            // Appelle JeuxFinis avec nbBranche = 1 avant la réinitialisation
            BrancheManager.nbBranche = 1;
            BrancheManager.JeuxFinis();

            branche.SetActive(false);
            Canva.SetActive(false);
        }
        else
        {
            Debug.Log("Gagné");
            BrancheManager.nbBranche++;
            branche.SetActive(false);
        }
    }
}
