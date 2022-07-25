using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Gravity Data")]
public class GravityData : ScriptableObject
{
    public float gravityScale = 1.0f;
    public float globalGravity = -9.81f;

}