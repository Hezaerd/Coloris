using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveControlsBack : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<CustomGravity>().enabled = true;

            //Changer le component par le character controler + planement
            collider.gameObject.GetComponent<PlayerController>().enabled = true;

        }
    }
}
