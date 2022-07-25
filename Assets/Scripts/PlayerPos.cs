using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameMan.gameMan.lastCheckpointPosPlayer;

       GetComponent<PlayerController>().HasBlue = GameMan.gameMan.playerHasBlue;
       GetComponent<PlayerController>().HasRed = GameMan.gameMan.playerHasRed;

        //if hasred -> access red struff

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<PlayerController>().HasBlue = GameMan.gameMan.playerHasBlue;
        GetComponent<PlayerController>().HasRed = GameMan.gameMan.playerHasRed;
    }


}
