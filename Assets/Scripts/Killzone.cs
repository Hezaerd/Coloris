using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Killzone : MonoBehaviour
{
    [SerializeField] float timerDeath = 0.8f;
    [SerializeField] Transform Player;

    [SerializeField] Transform positionDeath;
    [SerializeField] GameObject DeathParticles;

    int index;
    private void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject.transform;
            Player.GetComponent<PlayerController>().enabled = false;
            Player.GetComponentInChildren<SpriteRenderer>().enabled = false;
            StartCoroutine(PlayerDeath(timerDeath));
        }
    }

    IEnumerator PlayerDeath(float timerDeath)
    {
        Debug.Log("in coco");
        Instantiate(DeathParticles, Player.transform);
        
        yield return new WaitForSeconds(timerDeath);

        SceneManager.LoadScene(index);

    }
}
