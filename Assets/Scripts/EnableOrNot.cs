using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOrNot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "RedOrb")
        {
            if (GameMan.gameMan.playerHasRed)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);

            }

        }
        if (gameObject.name == "BlueOrb")
        {
            if (GameMan.gameMan.playerHasBlue)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
