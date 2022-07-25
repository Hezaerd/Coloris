using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coloredNPC : MonoBehaviour
{
    [SerializeField] GameObject white;
    [SerializeField] GameObject colored;

    // Start is called before the first frame update
    void Start()
    {
        if (GameMan.gameMan.playerHasRed)
        {
            white.SetActive(false);
            colored.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
