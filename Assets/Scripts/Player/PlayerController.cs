using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~ Variables ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

    #region DATA
    [Header("Data")]
    [SerializeField] private PlayerData _data;

    #endregion

    #region COMPONENTS
    public Rigidbody Rb { get; private set; }
    public CustomGravity Gravity { get; private set; }
    [Header("Components")]
    [SerializeField] public GameObject playerBlueSphere;
    [SerializeField] public GameObject playerRedSphere;
    [SerializeField] private UnityEngine.Camera _mainCamera;
    [SerializeField] private PowerTools.SpriteAnim _animations;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _soundDash;
    [SerializeField] private AudioClip _soundJump;
    [SerializeField] private AudioClip _soundOrb;
    [SerializeField] private AudioClip _redNPCSound;
    [SerializeField] private AudioClip _blueNPCSound;
    #endregion

    #region NPC

    private GameObject triggeringNPC;

    private int _blueDialog;
    private int _redDialog;

    #endregion


    #region STATE PARAMETERS

    public bool _IsTriggering { get; private set; }
    public bool _WantInteract { get; private set; }

    public bool IsRed { get; set; }
    public bool IsBlue { get; set; }
    public bool HasRed { get;  set; }
    public bool HasBlue { get;  set; }

    public bool IsFacingRight { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsDashing { get; private set; }

    public float LastOnGroundTime { get; private set; }
    public float LastDashCooldown { get; private set; }

    public int _dashesLeft;
    private float _dashStartTime;
    private Vector3 _lastDashDir;
    private bool _dashAttacking;
    #endregion

    #region INPUT PARAMETERS
    public float LastPressedJumpTime { get; private set; }
    public float LastPressedDashTime { get; private set; }
    #endregion

    #region CHECK PARAMETERS
    [Header("Checks")] 
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField, Tooltip("NE PAS CHANGER LE Z !")] private Vector3 _groundCheckSize;
    [SerializeField] private float _groundCheckRadius;

    private Collider _groundCollider;
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _groundLayer;
    private Vector2 _moveVector;
    #endregion

    #region ANIMATION
    private Animator anim;
    #endregion

    /*~~~~~~~~~~~~~~~~~~~~~~~~~~ Function ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

    #region AWAKE UPDATES
    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        Gravity = GetComponent<CustomGravity>();
        anim = GetComponentInChildren<Animator>();

        HasBlue = false;
        HasRed = false;

        playerBlueSphere.SetActive(false);
        playerRedSphere.SetActive(false);

        _blueDialog = 0;
        _redDialog = 0;
    }

    private void Update()
    {
        #region TIMERS
        LastOnGroundTime -= Time.unscaledDeltaTime;
        LastPressedJumpTime -= Time.unscaledDeltaTime;
        LastPressedDashTime -= Time.unscaledDeltaTime;
        LastDashCooldown -= Time.unscaledDeltaTime;

        #endregion

        #region GENERAL CHECKS
        if (_moveVector.x != 0)
        {
            CheckDirectionToFace(_moveVector.x > 0);
        }
        #endregion

        #region COLLISIONS CHECKS
        if (!IsDashing && !IsJumping)
        {
            //Ground Check
            if (Physics.CheckSphere(_groundCheckPoint.position, _groundCheckRadius, _groundLayer))
            {
                LastOnGroundTime = _data.coyoteTime;
            }
        }
        #endregion

        #region GRAVITY
        if (!IsDashing)
        {
            if (Rb.velocity.y >= 0)
            {
                SetGravityScale(_data.gravityScale);
            }
            else if (_moveVector.y < 0)
            {
                SetGravityScale(_data.gravityScale * _data.quickFallGravityMult);
            }
            else
            {
                SetGravityScale(_data.gravityScale * _data.fallGravityMult);
            }
        }
        #endregion

        #region JUMP CHECKS
        if (IsJumping && Rb.velocity.y < 0)
        {
            IsJumping = false;
        }

        if (!IsDashing)
        {
            //Jump
            if (CanJump() && LastPressedJumpTime > 0)
            {
                IsJumping = true;
                Jump();
            }
        }
        #endregion

        #region DASH CHECKS
        if (DashAttackOver())
        {
            if (_dashAttacking)
            {
                _dashAttacking = false;
                StopDash(_lastDashDir); // On commence a stopper le dash
            }
            else if (Time.time - _dashStartTime > _data.dashAttackTime + _data.dashEndTime)
            {
                IsDashing = false; // Reset Dash state
            }
        }

        if (CanDash() && LastPressedDashTime > 0)
        {
            LastDashCooldown = _data.dashCooldown;
            if (_moveVector != Vector2.zero)
            {
                _lastDashDir = _moveVector;
            }
            else
            {
                _lastDashDir = IsFacingRight ? Vector2.right : Vector2.left;
            }

            _dashStartTime = Time.time;
            _dashesLeft--;
            _dashAttacking = true;

            IsDashing = true;
            IsJumping = false;

            StartDash(_lastDashDir);
        }
        #endregion

        #region RESET BALL
        // YEA I KNOW I CAN DO WAY MORE OPTIMISED/CLEAN BUT I DON'T HAVE TIME :d
        if (playerBlueSphere.transform.localScale.x >= _data.sphereMaxSize)
        {
            playerBlueSphere.transform.DOKill();
            ResetSphere(playerBlueSphere);
            StopAllCoroutines();
            playerBlueSphere.SetActive(false);
            IsBlue = false;
            StartCoroutine(setTimeScale(1, 0.1f, Time.timeScale));
        }
        if (playerRedSphere.transform.localScale.x >= _data.sphereMaxSize)
        {
            playerRedSphere.transform.DOKill();
            ResetSphere(playerRedSphere);
            StopAllCoroutines();
            playerRedSphere.SetActive(false);
            IsRed = false;
            StartCoroutine(setTimeScale(1, 0.1f, Time.timeScale));
        }
        #endregion

        #region CHECK NPC
        if (_IsTriggering)
        {
            if (_WantInteract)
            {
                if (triggeringNPC.name == "BlueNPC" && HasBlue)
                {
                    _audioSource.clip = _blueNPCSound;
                    _audioSource.Play();

                    print("Blue NPC INTERACTED");
                    if (_blueDialog == 0)
                    {
                        triggeringNPC.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    if (_blueDialog == 1)
                    {
                        triggeringNPC.transform.GetChild(1).gameObject.SetActive(false);
                        triggeringNPC.transform.GetChild(2).gameObject.SetActive(true);
                    }
                    if (_blueDialog == 2)
                    {
                        triggeringNPC.transform.GetChild(2).gameObject.SetActive(false);
                        triggeringNPC.transform.GetChild(3).gameObject.SetActive(true);
                    }
                    if (_blueDialog == 3)
                    {
                        triggeringNPC.transform.GetChild(3).gameObject.SetActive(false);
                        triggeringNPC.transform.GetChild(1).gameObject.SetActive(false);
                        triggeringNPC.transform.GetChild(4).gameObject.SetActive(true);
                        triggeringNPC.transform.GetChild(5).gameObject.SetActive(true);
                    }
                    if (_blueDialog == 4)
                    {
                        triggeringNPC.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
                if (triggeringNPC.name == "RedNPC")
                {
                    _audioSource.clip = _redNPCSound;
                    _audioSource.Play();

                    print("Red NPC INTERACTED");
                    if (_redDialog == 0)
                    {
                        triggeringNPC.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    if (_redDialog == 1)
                    {
                        triggeringNPC.transform.GetChild(1).gameObject.SetActive(false);
                        triggeringNPC.transform.GetChild(2).gameObject.SetActive(true);
                    }
                    if (_redDialog == 2)
                    {
                        triggeringNPC.transform.GetChild(2).gameObject.SetActive(false);
                        triggeringNPC.transform.GetChild(3).gameObject.SetActive(true);
                    }
                    if (_redDialog == 3)
                    {
                        triggeringNPC.transform.GetChild(3).gameObject.SetActive(false);
                        triggeringNPC.transform.GetChild(0).gameObject.SetActive(false);
                        triggeringNPC.transform.GetChild(4).gameObject.SetActive(true);
                        triggeringNPC.transform.GetChild(5).gameObject.SetActive(true);
                    }
                    if (_redDialog == 4)
                    {
                        triggeringNPC.transform.GetChild(4).gameObject.SetActive(false);
                    }
                }
                if (triggeringNPC.name == "BlueOrb" && !HasBlue)
                {
                    print("Pickedup BlueOrb");
                    _audioSource.clip = _soundOrb;
                    _audioSource.Play();
                    GameMan.gameMan.playerHasBlue = true;
                    HasBlue = true;
                    triggeringNPC.SetActive(false);
                }
                if (triggeringNPC.name == "RedOrb" && !HasRed)
                {
                    print("Pickedup RedOrb");
                   _audioSource.clip = _soundOrb;
                    _audioSource.Play();
                    GameMan.gameMan.playerHasRed = true;
                    HasRed = true;
                    triggeringNPC.SetActive(false);

                }

            }
        }
        #endregion
    }

    private void FixedUpdate()
    {
        #region ANIMATIONS BOOL
        anim.SetBool("Walk", (0 + _moveVector.x) /(0 + _moveVector.x) >= 1);
        anim.SetBool("Grounded",Physics.CheckSphere(_groundCheckPoint.position, _groundCheckRadius, _groundLayer));
        anim.SetBool("Dash", IsDashing);
        #endregion

        #region DRAG
        if (IsDashing)
        {
            Drag(DashAttackOver() ? _data.dragAmount : _data.dashAttackDragAmount);
        }
        else if (LastOnGroundTime <= 0)
        {
            Drag(_data.dragAmount);
        }
        else
        {
            Drag(_data.frictionAmount);
        }
        #endregion

        #region RUN
        if (!IsDashing)
        {
            Run(1);
        }
        else if (DashAttackOver())
        {
            Run(_data.dashEndRunLerp);
        }
        #endregion
    }
    #endregion

    #region INPUT CALLBACKS
    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
             LastPressedJumpTime = _data.jumpBufferTime;
        }
        else if (value.canceled)
        {
            if (CanJumpCut())
            {
                JumpCut();
            }
        }
    }
    public void OnDash(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            LastPressedDashTime = _data.dashBufferTime;
        }
    }
    public void OnMovementChange(InputAction.CallbackContext value)
    {
        _moveVector = value.ReadValue<Vector2>();
    }
    
    public void OnTriggerLeft(InputAction.CallbackContext value) // Blue trigger
    {

        if (HasBlue)
        {
            if (!IsRed)
            {
                if (value.started)
                {   
                    StartCoroutine(setTimeScale(0.35f, 0.1f, Time.timeScale));
                    playerBlueSphere.SetActive(true);
                    StartCoroutine(SphereScaling(playerBlueSphere));
                    IsBlue = true;
                }
                if (value.canceled)
                {
                    playerBlueSphere.transform.DOKill();
                    ResetSphere(playerBlueSphere);
                    StopAllCoroutines();
                    playerBlueSphere.SetActive(false);
                    IsBlue = false;
                    StartCoroutine(setTimeScale(1, 0.1f, Time.timeScale));
                }
            }
        }
    }

    public void OnTriggerRight(InputAction.CallbackContext value) // Red trigger
    {
        if (HasRed)
        {
            if (!IsBlue)
            {
                if (value.started)
                {
                    StartCoroutine(setTimeScale(0.35f, 0.1f, Time.timeScale));
                    playerRedSphere.SetActive(true);
                    StartCoroutine(SphereScaling(playerRedSphere));
                    IsRed = true;
                }
                if (value.canceled)
                {
                    playerRedSphere.transform.DOKill();
                    ResetSphere(playerRedSphere);
                    StopAllCoroutines();
                    playerRedSphere.SetActive(false);
                    IsRed = false;
                    StartCoroutine(setTimeScale(1, 0.1f, Time.timeScale));
                }
            }
        }
    }

    public void OnInterract(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            _WantInteract = true;
        }
        if (value.canceled)
        {
            _WantInteract = false;

            if (triggeringNPC.name == "BlueNPC" && HasBlue)
            {
                _blueDialog++;
            }
            if (triggeringNPC.name == "RedNPC" && HasRed)
            {
                _redDialog++;
            }
        }
    }
    #endregion


    #region NPC
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            _IsTriggering = true;
            triggeringNPC = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            _IsTriggering = false;
            triggeringNPC = null;
        }
    }
    #endregion

    #region MOVEMENT METHODS

    public void SetGravityScale(float scale)
    {
        Gravity._data.gravityScale = scale;
    }

    private void Turn()
    {
        var scale = transform.localScale; // flip le gameObject entier
        scale.x *= -1;
        transform.localScale = scale;

        IsFacingRight = !IsFacingRight;
    }
    private void Drag(float amount)
    {
        Vector2 force = amount * Rb.velocity.normalized;
        force.x = Mathf.Min(Mathf.Abs(Rb.velocity.x), Mathf.Abs(force.x));
        force.y = Mathf.Min(Mathf.Abs(Rb.velocity.y), Mathf.Abs(force.y));
        force.x *= Mathf.Sign(Rb.velocity.x);
        force.y *= Mathf.Sign(Rb.velocity.y);

        Rb.AddForce(-force, ForceMode.Impulse);
    }

    private void Run(float lerpAmount)
	{
		var targetSpeed = _moveVector.x * _data.runMaxSpeed;
		var speedDif = targetSpeed - Rb.velocity.x;

		#region Acceleration Rate
		float accelRate;

        if (LastOnGroundTime > 0)
        {
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _data.runAccel : _data.runDeccel;
        }
        else
        {
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? _data.runAccel * _data.accelInAir : _data.runDeccel * _data.deccelInAir;
        }

		if (((Rb.velocity.x > targetSpeed && targetSpeed > 0.01f) || (Rb.velocity.x < targetSpeed && targetSpeed < -0.01f)) && _data.doKeepRunMomentum)
		{
			accelRate = 0;
		}
		#endregion

		#region Velocity Power
		float velPower;
		if (Mathf.Abs(targetSpeed) < 0.01f)
		{
			velPower = _data.stopPower;
		}
		else if (Mathf.Abs(Rb.velocity.x) > 0 && (Mathf.Sign(targetSpeed) != Mathf.Sign(Rb.velocity.x)))
		{
			velPower = _data.turnPower;
		}
		else
		{
			velPower = _data.accelPower;
		}
		#endregion

		var movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
		movement = Mathf.Lerp(Rb.velocity.x, movement, lerpAmount);

        Rb.AddForce(movement * Vector2.right);

        if (_moveVector.x != 0)
        {
			CheckDirectionToFace(_moveVector.x > 0);
        }
	}
    
    private void Jump()
    {
        if (_data.doJumpResetDashCooldown)
        {
            LastDashCooldown = -1;
        }

       // _audioSource.clip = _soundJump;
       // _audioSource.Play();

        //ensures we can't call a jump multiple times from one press
        LastPressedJumpTime = 0;
        LastOnGroundTime = 0;

        #region Perform Jump
        var force = _data.jumpForce;
        if (Rb.velocity.y < 0)
            force -= Rb.velocity.y;

        Rb.AddForce(Vector2.up * force, ForceMode.Impulse);
        #endregion
    }

    private void JumpCut()
    {
        //applies force downward when the jump button is released. Allowing the player to control jump height
        Rb.AddForce((1 - _data.jumpCutMultiplier) * Rb.velocity.y * Vector3.down, ForceMode.Impulse);
    }

    private void StartDash(Vector3 dir)
    {

        LastOnGroundTime = 0;
        LastPressedDashTime = 0;

        SetGravityScale(0);

        //_audioSource.clip = _soundDash;
       // _audioSource.Play();

        Rb.velocity = dir.normalized * _data.dashSpeed;

        CameraShake();
        
        if (_data.doJumpResetDashCooldown)
        {
            LastDashCooldown = -1;
        }
    }

    private void StopDash(Vector3 dir)
    {
        SetGravityScale(_data.gravityScale);

        if (dir.y > 0)
        {
            if (dir.x == 0)
                Rb.AddForce((1 - _data.dashUpEndMult) * Rb.velocity.y * Vector3.down, ForceMode.Impulse);
            else
                Rb.AddForce((1 - _data.dashUpEndMult) * .7f * Rb.velocity.y * Vector3.down, ForceMode.Impulse);
        }
    }
    #endregion

    #region CHECK METHODS
    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != IsFacingRight)
        {
            Turn();
        }
    }
    private bool CanJump()
    {
        return LastOnGroundTime > 0 && !IsJumping;
    }

    public bool PubCanJump()
    {
        return LastOnGroundTime > 0 && !IsJumping;
    }

    private bool CanJumpCut()
    {
        return IsJumping && Rb.velocity.y > 0;
    }
    public bool CanDash()
    {
        if (_dashesLeft < _data.dashAmount && LastOnGroundTime > 0 && LastDashCooldown < 0)
        {
            _dashesLeft = _data.dashAmount;
        }
        return _dashesLeft > 0;


    }
    private bool DashAttackOver()
    {
        return IsDashing && Time.time - _dashStartTime > _data.dashAttackTime;
    }
    #endregion
    
    #region SPHERES
    private IEnumerator SphereScaling(GameObject sphere) // JE VEUX PAS UTILISER DE COROUTINE MAIS PAR MANQUE DE TEMPS JE LE FAIS QUAND MEME (pour le moi du futur)
    {
        while (sphere.transform.localScale.x < _data.sphereMaxSize)
        {
            sphere.transform.DOScale(new Vector3(sphere.transform.localScale.x + _data.sphereGrowthValue, sphere.transform.localScale.y + _data.sphereGrowthValue, sphere.transform.localScale.z), _data.sphereGrowthSpeed);
            yield return null;  
        }
    }

    IEnumerator setTimeScale(float speed, float lerpTime, float startTimeScale)
    {
        float timer = 0;
        while (timer < lerpTime)
        {
            timer += Time.unscaledDeltaTime;
            float step = Mathf.Lerp(startTimeScale, speed, timer / lerpTime);
            Time.timeScale = step;
            yield return null;
        }
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        Time.timeScale = speed;
    }
    private void ResetSphere(GameObject sphere)
    {
        sphere.transform.localScale = new Vector3(_data.sphereDefaultSize, _data.sphereDefaultSize, _data.sphereDefaultZ);

    }
    #endregion

    #region CAMERA
    private void CameraShake()
    {
        //UnityEngine.Camera.main.transform.DOComplete();
        //UnityEngine.Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
    }
    #endregion
    
    #region DEBUG DRAWING
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundCheckPoint.position, _groundCheckRadius);
    }
    #endregion
}