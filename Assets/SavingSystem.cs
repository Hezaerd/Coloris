using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SavingSystem : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] GameObject MainCam;

    [SerializeField] GameObject Checkpoint;
    


    // Start is called before the first frame update
    void Start()
    {
        Player.transform.position = Checkpoint.transform.position;
        //MainCam.transform.position = Checkpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

     
    }

    public void SetCheckpoint(GameObject obj)
    {
        Checkpoint = obj;
    //    startPlayerPos = player;
     //   startCamPos = cam;
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
