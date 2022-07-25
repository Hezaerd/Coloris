using UnityEngine;

[ExecuteInEditMode]
public class ParallaxPlacer : MonoBehaviour
{
    [SerializeField] private ParallaxSettings Settings;
    [SerializeField] private SpriteRenderer[] ParallaxObjects;

    void LateUpdate()
    {
        for (int i = ParallaxObjects.Length - 1; i >= 0; i--)
        {
            Transform poT = ParallaxObjects[i].transform;
            poT.localPosition = new Vector3(i * Settings.XOffset, i * Settings.YOffset, i * Settings.ZOffset);
            ParallaxObjects[i].color = new Color(ParallaxObjects[i].color.r, ParallaxObjects[i].color.g,
                ParallaxObjects[i].color.b,
                Settings.MinAlpha + ((Settings.MaxAlpha - Settings.MinAlpha) / ParallaxObjects.Length * (ParallaxObjects.Length - 1 - i)));
        }
    }
}