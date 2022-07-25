using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedWall : MonoBehaviour
{
    [SerializeField] GameObject parent;

    [SerializeField] GameObject wall;

    [SerializeField] bool open;
    [SerializeField] bool redOrb;


    private void Start()
    {

        switch (parent.name)
        {
            case "ClosedWall":
                if (GameMan.gameMan.wall_0 == true)
                {
                    wall.SetActive(true);
                }

                break;
            case "ClosedWall (1)":
                if (GameMan.gameMan.wall_1 == true)
                {
                    wall.SetActive(true);
                }
                break;
            case "ClosedWall (2)":
                if (GameMan.gameMan.wall_2 == true)
                {
                    wall.SetActive(true);
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (open)
            {
                switch (parent.name)
                {
                    case "ClosedWall":
                        GameMan.gameMan.wall_0 = true;
                        break;
                    case "ClosedWall (1)":
                        GameMan.gameMan.wall_1 = true;

                        break;
                    case "ClosedWall (2)":
                        GameMan.gameMan.wall_2 = true;

                        break;
                }
                wall.SetActive(true);
            }
            else
            {
                if (redOrb)
                {
                    if (other.GetComponent<PlayerController>().HasRed)
                    {
                        wall.SetActive(false);

                    }

                }
                if (other.GetComponent<PlayerController>().HasBlue)
                {
                    wall.SetActive(false);

                }

            }
        }
    }
}
