using UnityEngine;
 
[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    public GravityData _data;

    private Rigidbody _rb;
 
    private void OnEnable ()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
    }
 
    private void FixedUpdate ()
    {
        var gravity = _data.globalGravity * _data.gravityScale * Vector3.up;
        _rb.AddForce(gravity, ForceMode.Acceleration);
    }
}