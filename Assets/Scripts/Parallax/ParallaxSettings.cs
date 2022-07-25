using UnityEngine;

[CreateAssetMenu(menuName = "Data/Parallax Data")]
public class ParallaxSettings : ScriptableObject
{
    public float XOffset;
    public float YOffset;
    public float ZOffset;
    [Range(0f, 1f)]
    public float MinAlpha;

    [Range(0f, 1f)]
    public float MaxAlpha;
}