using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    //Le joueur sera envoyé dans une direction déterminée
    [SerializeField] float speed = 10;
    [SerializeField] Transform targetPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector3 direction;
            direction = (targetPos.position - collision.gameObject.transform.position).normalized;

            collision.gameObject.GetComponent<CustomGravity>().enabled = false;

            collision.gameObject.GetComponent<Rigidbody>().velocity = direction * speed;

            collision.gameObject.GetComponent<PlayerController>()._dashesLeft = 1;

            collision.gameObject.GetComponent<PlayerController>().enabled = false;

        }
    }

}
