using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] PlatformManager platformMan;


    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Platform")
        {
            if (collision.collider.tag == "Player")
            {
                collision.collider.transform.SetParent(this.transform);
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }

  
}
