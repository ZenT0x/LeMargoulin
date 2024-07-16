using Mirror;
using UnityEngine;

public class script_playersetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
    }
}
