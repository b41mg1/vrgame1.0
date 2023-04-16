using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject rig;
    public void TeleportRig()
    {
        rig.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z); 
    }
}
