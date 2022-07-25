using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.collider);
        }
    }

}
