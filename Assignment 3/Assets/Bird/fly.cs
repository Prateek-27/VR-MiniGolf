using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    public float horizontalSpeed = 0.01f;
    public float VerticallSpeed = 1f;
    public float Altitude = 0.01f;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

        pos = transform.position; //initial position
    }

    // FixedUpdate used when working with physics 
    void FixedUpdate()
    {
        pos.z += horizontalSpeed;   //right or left movement
        pos.y += Mathf.Sin(Time.realtimeSinceStartup*VerticallSpeed)*Altitude;  //Up-down movement
        transform.position = pos;
    }
}
