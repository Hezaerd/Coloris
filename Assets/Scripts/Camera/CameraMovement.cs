using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    [SerializeField] Transform target;
    Vector3 offset;
    public int smoothing = 4;
    public bool smooth = false;

    public float y = 5;
    public float z = -120;


    void Start()
    {
        target = target.transform;
        transform.position = new Vector3 (target.position.x, target.position.y + y, z);
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 componentPosition = target.position + offset;

        if (smooth)
        {
            transform.position = Vector3.Lerp(transform.position, componentPosition, smoothing * Time.deltaTime);
        }
        else
        {
            transform.position = componentPosition;
        }
    }
}
