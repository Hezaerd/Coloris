using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsBackOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 3 && GetComponent<PlayerController>().enabled == false && GetComponent<CustomGravity>().enabled == false)
        {
            GetComponent<CustomGravity>().enabled = true;
            GetComponent<PlayerController>().enabled = true;
        }


    }

}
