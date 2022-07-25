using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player Data")]
public class PlayerData : ScriptableObject
{
    //PHYSICS
	[Header("Gravité :")]
	[Tooltip("Remplace la gravité du RigidBody du player")] public float gravityScale;
	public float fallGravityMult;
	public float quickFallGravityMult;

	[Header("Drag :")]
	[Tooltip("Drag en l'air.")] public float dragAmount;
	[Tooltip("Drag sur le sol.")] public float frictionAmount;

	[Header("Physique autre :")]
	[Range(0, 0.5f), Tooltip("Timing sur le quel le joueur peut quand même jump apres être tombé d'une platforme.")] public float coyoteTime;


	//GROUND
	[Header("Déplacement :")]
	[Tooltip("Vitesse maximal que le player peut atteindre en se déplaçant.")] public float runMaxSpeed;
    [Tooltip("Vitesse d'accéleration au sol du joueur.")] public float runAccel;
    [Tooltip("Vitesse de décélaration au sol du joueur.")] public float runDeccel;
    [Range(0, 1), Tooltip("Vitesse de décélaration en l'air du joueur.")] public float accelInAir;
    [Range(0, 1), Tooltip("Vitesse de décélaration en l'air du joueur.")] public float deccelInAir;
	[Space(5)]
	[Range(.5f, 2f)] public float accelPower;   
	[Range(.5f, 2f)] public float stopPower;
	[Range(.5f, 2f)] public float turnPower;


	//JUMP
	[Header("Jump")]
	public float jumpForce;
	[Range(0, 1)] public float jumpCutMultiplier;
	[Space(10)]
	[Range(0, 0.5f), Tooltip("Timing après avoir appuyé sur le bouton de saut où si les conditions sont remplies, un saut sera automatiquement effectué.")] public float jumpBufferTime;

    //Dash
	[Header("Dash :")]
	[Tooltip("Nombre de dash maximum que le player possede.")] public int dashAmount;
	[Tooltip("Vitesse de deplacement durant le dash.")] public float dashSpeed;
    [Tooltip("Durée entre les dash.")] public float dashCooldown;
	[Space(5)]
	public float dashAttackTime;
	public float dashAttackDragAmount;
	[Space(5)]
    [Tooltip("Timing apres avoir fini le drag initial. Permet de rendre plus smooth la fin du dash.")] public float dashEndTime;
	[Range(0f, 1f), Tooltip("Ralentit le joueur pour rendre le dash plus 'responsive'.")] public float dashUpEndMult;
	[Range(0f, 1f), Tooltip("Ralentit l'effet du mouvement du joueur durant un dash.")] public float dashEndRunLerp;
	[Space(5)]
	[Range(0, 0.5f)] public float dashBufferTime;

	//SPHERE
    [Header("Sphere :")] 
    public float sphereDefaultSize; 
    public float sphereDefaultZ; 
    public float sphereMaxSize;
    public float sphereGrowthValue;
    public float sphereGrowthSpeed;

    //OTHER 
    [Header("Autre :")]
    [Tooltip("La vitesse du joueur ne se decrement pas si elle est supérieur à maxSpeed (on laisse le drag le faire ce qui permet une conservation du momentum")] public bool doKeepRunMomentum;

    [Tooltip("Permet au joueur de reset le cooldown du dash en sautant. Ce qui lui permet de 'dash jump dash'.")] public bool doJumpResetDashCooldown;
}
