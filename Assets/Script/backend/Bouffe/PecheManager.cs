using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PecheManager : MonoBehaviour
{
    public int nbPoisson;
    float nbCliqueActue = 0;
    float nbCliqueNec = 0.60f;
    public Image BarreProg;
    int alea;
    bool perdu;
    public GameObject Canva;

    void Start()
    {
        // Initialiser la barre de progression à 0
        BarreProg.fillAmount = 0;
        nbPoisson = 0;
    }
    void OnEnable()
    {
        BarreProg.fillAmount = 0;
        nbPoisson = 0;
    }

    public void OnButtonClick()
    {
        if (nbCliqueActue >= nbCliqueNec)
        {
            if (nbPoisson == 0)
            {
                nbCliqueActue = 0;
                nbPoisson = nbPoisson + 1;
            }
            else
            {
                nbCliqueActue = 0;
                if (nbPoisson == 1)
                {
                    alea = UnityEngine.Random.Range(1, 3);
                    if (alea == 1)
                    {
                        nbPoisson = nbPoisson + 1;
                        Debug.Log("Gagné");
                    }
                    else
                    {
                        Debug.Log("Perdu");
                        Canva.SetActive(false);
                    }
                }
                else
                {
                    alea = UnityEngine.Random.Range(1, 4);
                    if (alea == 1)
                    {
                        nbPoisson = nbPoisson + 1;
                        Debug.Log("Gagné");
                        Canva.SetActive(false);
                    }
                    else
                    {
                        Debug.Log("Perdu");
                        Canva.SetActive(false);
                    }
                }
            }
        }
        else
        {
            nbCliqueActue += 0.05f; // Incrémentation simple
        }

        // Mise à jour de la barre de progression après chaque clic
        BarreProg.fillAmount = nbCliqueActue / nbCliqueNec;
    }

    void Update()
    {
        // Mise à jour de la barre de progression en fonction de nbCliqueActue
        BarreProg.fillAmount = nbCliqueActue / nbCliqueNec;
    }
}
