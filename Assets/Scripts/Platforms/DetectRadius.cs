using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRadius : MonoBehaviour
{
    PlatformManager platformMan;


    // Start is called before the first frame update
    void Start()
    {
        platformMan = GetComponentInParent<PlatformManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Platform" && platformMan.isPresent)
        {
            if(other.gameObject.tag == "RedRadius")
            {
                platformMan.currentState = PlatformManager.platformColor.Red;
            }

            if (other.gameObject.tag == "BlueRadius" && platformMan.hasCooldown)
            {
                platformMan.currentState = PlatformManager.platformColor.BlueSwitch;
            }
        }

        if (gameObject.tag == "HiddenPlatform")
        {
            if (other.gameObject.tag == "BlueRadius" && platformMan.hasCooldown)
            {
                platformMan.currentState = PlatformManager.platformColor.BlueSwitch;
            }
        }
    }

}
