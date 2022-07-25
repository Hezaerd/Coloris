using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformRed : MonoBehaviour
{
    [SerializeField] PlatformManager platformMan;

    [SerializeField] private Transform startPos;
    [SerializeField] private Transform targetPos;

    [SerializeField] public float speed = 5f;

    public int counter;
    private bool back;
    private bool forth;

    // Start is called before the first frame update
    void OnEnable()
    {
        counter = 0;
        back = true;
        forth = false;
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (back)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
            if (transform.position == targetPos.position || platformMan.hasCollided == true)
            {
                back = false;
                forth = true;
                platformMan.hasCollided = false;
            }
        }

        if (forth)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos.position, speed * Time.deltaTime);
            if (transform.position == startPos.position)
            {
                counter++;
                back = false;
                forth = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.layer == 3)
        {
            back = true;
            forth = false;
            platformMan.hasCollided = true;
        }
    }
}
