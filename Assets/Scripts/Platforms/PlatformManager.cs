using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    

    [SerializeField] PlatformRed platformRed;
    public platformColor currentState;
    [SerializeField] GameObject Platform;

    [SerializeField] GameObject[] Visuals;

    public bool isPresent = true;

    [SerializeField] float cooldown = .5f;
    public bool hasCooldown = true;

    public bool hasCollided;

    public enum platformColor
    {
        Neutral,
        Red,
        BlueSwitch,
        BlueAppeared,
        BlueDisappeared
    }

    // Start is called before the first frame update
    void Start()
    {
       ColorPlatform(platformColor.Neutral);
    }

    // Update is called once per frame
    void Update()
    {
        ColorPlatform(currentState);
    }

    public void ColorPlatform(platformColor state)
    {
        switch (state)
        {
            case platformColor.Neutral:
                //On désactive le script faisant bouger la plateforme rouge
                platformRed.enabled = false;

                //La plateforme est présente
                isPresent = true;
                
                //On active le visuel neutre
                Visuals[0].SetActive(true);
                Visuals[1].SetActive(false);
                Visuals[2].SetActive(false);
                Visuals[3].SetActive(false);

                //On reset le tag et le layer
                Platform.tag = "Platform";
                Platform.layer = 3;

                break;
            
            case platformColor.Red:

                //La plateforme est toujours présente
                isPresent = true;

                //On active le visuel rouge
                Visuals[0].SetActive(false);
                Visuals[1].SetActive(true);
                Visuals[2].SetActive(false);
                Visuals[3].SetActive(false);

                //On active le script faisant bouger la plateforme
                platformRed.enabled = true;
                //Quand la plateforme fait un AR, elle repasse en neutre et on réinitialise son compteur d'AR
                if (platformRed.counter == 1)
                {
                     platformRed.counter = 0;
                     currentState = platformColor.Neutral;
                }
                break;


            case platformColor.BlueSwitch:

                if (isPresent)
                {
                    currentState = platformColor.BlueDisappeared;
                }
                else
                {
                    currentState = platformColor.BlueAppeared;
                }
                
                break;

            case platformColor.BlueDisappeared:

                //Si la plateforme est rouge, on désactive son script pour l'arrêter à sa position + quand le script sera activé elle continuera son chemin
                platformRed.enabled = false;

                //La plateforme n'est plus présente
                isPresent = false;

                //On change le tag et le layer (le layer ignorera le layer Player)
                Platform.tag = "HiddenPlatform";
                Platform.layer = 7;

                //GameObject.Find("Player").transform.SetParent(null);

                //On active le visuel rouge
                Visuals[0].SetActive(false);
                Visuals[1].SetActive(false);
                Visuals[2].SetActive(false);
                Visuals[3].SetActive(true);

                //On set up un cooldown pour éviter que la plateforme passe en Blue Appeared 
                hasCooldown = false;
                StartCoroutine(SetCooldown(cooldown));

                break;
            case platformColor.BlueAppeared:
                platformRed.enabled = false;
                isPresent = true;
                Platform.tag = "Platform";
                Platform.layer = 3;
                hasCooldown = false;

                Visuals[0].SetActive(false);
                Visuals[1].SetActive(false);
                Visuals[2].SetActive(true);
                Visuals[3].SetActive(false);

                StartCoroutine(SetCooldown(cooldown));

                break;


        }

    }


    IEnumerator SetCooldown(float t)
    {
        yield return new WaitForSeconds(t);
        hasCooldown = true;
    }
}
