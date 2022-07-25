using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Altar : MonoBehaviour
{
    public float timerEnd = 3f;
    [SerializeField] GameObject Neutral;
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Complete;
    [SerializeField] GameObject EndingVFX;

    [SerializeField] AudioClip OrbSound;

    // Start is called before the first frame update
    void Start()
    {
        if (GameMan.gameMan.playerHasRed)
        {
            Neutral.SetActive(false);
            Red.SetActive(true);
            Complete.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (other.GetComponent<PlayerController>().HasRed && !other.GetComponent<PlayerController>().HasBlue)
            {
                Neutral.SetActive(false);
                Red.SetActive(true);
                Complete.SetActive(false);
            }

            if (other.GetComponent<PlayerController>().HasBlue)
            {
                               
                StartCoroutine(Ending(timerEnd));

            }

        }
    }

    IEnumerator Ending(float timer)
    {
        GetComponent<AudioSource>().Play();
        EndingVFX.SetActive(true);
        Neutral.SetActive(false);
        Red.SetActive(false);
        Complete.SetActive(true);
        yield return new WaitForSeconds(timerEnd);
        SceneManager.LoadScene(2);
    }
}
