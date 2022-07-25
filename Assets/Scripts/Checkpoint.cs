using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject[] walls;

    [SerializeField] GameObject particles;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameMan.gameMan.playerHasBlue = other.GetComponent<PlayerController>().HasBlue;
            GameMan.gameMan.playerHasRed = other.GetComponent<PlayerController>().HasRed;

            GameMan.gameMan.lastCheckpointPosPlayer = transform.position;

            particles.SetActive(true);


            }
         
        
    }
}
