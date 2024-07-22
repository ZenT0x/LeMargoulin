using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Deplacement : NetworkBehaviour
{
    GameObject Joueur;
    public float vitesse;
    private Animator animator;

    [SyncVar(hook = nameof(OnIsMovingChanged))]
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        Joueur = gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        bool wasMoving = isMoving;
        isMoving = false;

        if (Input.GetKey("w"))
        {
            Vector3 position = Joueur.transform.position;
            position.y = position.y + vitesse * Time.deltaTime;
            Joueur.transform.position = position;
            isMoving = true;
        }
        if (Input.GetKey("s"))
        {
            Vector3 position = Joueur.transform.position;
            position.y = position.y - vitesse * Time.deltaTime;
            Joueur.transform.position = position;
            isMoving = true;
        }
        if (Input.GetKey("a"))
        {
            Vector3 position = Joueur.transform.position;
            position.x = position.x - vitesse * Time.deltaTime;
            Joueur.transform.position = position;
            isMoving = true;
        }
        if (Input.GetKey("d"))
        {
            Vector3 position = Joueur.transform.position;
            position.x = position.x + vitesse * Time.deltaTime;
            Joueur.transform.position = position;
            isMoving = true;
        }

        if (wasMoving != isMoving)
        {
            CmdUpdateIsMoving(isMoving);
        }
    }

    [Command]
    void CmdUpdateIsMoving(bool newIsMoving)
    {
        isMoving = newIsMoving;
        RpcUpdateIsMoving(newIsMoving); // Ensure all clients update their animation state
    }

    [ClientRpc]
    void RpcUpdateIsMoving(bool newIsMoving)
    {
        OnIsMovingChanged(isMoving, newIsMoving); // Ensure local client updates its animation state
    }

    void OnIsMovingChanged(bool oldIsMoving, bool newIsMoving)
    {
        animator.SetBool("IsMoving", newIsMoving);
    }
}
