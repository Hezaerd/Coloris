using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetUp : MonoBehaviour
{
    [SerializeField] GameObject Process;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMan.gameMan.playerHasRed && (gameObject.name == "Global Volume Red"))
        {
            Process.SetActive(false);
        }
        else
        {
            if (GameMan.gameMan.playerHasBlue && (gameObject.name == "Global Volume Blue"))
            {
                Process.SetActive(false);
            }
        }
    }
}
