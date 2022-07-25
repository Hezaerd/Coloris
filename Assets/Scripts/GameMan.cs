using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public static GameMan gameMan;

    public bool playerHasRed;
    public bool playerHasBlue;



    public Vector3 lastCheckpointPosPlayer;

    public bool wall_0;
    public bool wall_1;
    public bool wall_2;

    private void Awake()
    {
        if(gameMan == null)
        {
            gameMan = this;
            DontDestroyOnLoad(gameMan);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
