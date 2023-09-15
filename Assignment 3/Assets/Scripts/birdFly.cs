using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFly : MonoBehaviour
{
    private float horizontalSpeed = 2f; //0.25f;
    //private float VerticalSpeed = 1f;
    //private float Altitude = 0.01f;
    private float loopDist = 35.0f;
    private float distTravelled = 0.0f;
    public Vector3 userDirection = Vector3.right;
    //public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        //pos = transform.position; //initial position
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = transform.forward;
        transform.position += moveDirection * Time.deltaTime * horizontalSpeed;
        //distTravelled += (moveDirection * Time.deltaTime * horizontalSpeed).x;
        distTravelled += Time.deltaTime * horizontalSpeed;
        //Debug.Log(distTravelled);
        if (distTravelled > loopDist || distTravelled < 0)
        {
            // Create a Quaternion representing a rotation of 180 degrees around the y-axis
            //Quaternion rotation = Quaternion.Euler(0, -90, 0);
            // Set the object's rotation to the new Quaternion
            //transform.rotation = rotation;
            transform.RotateAround(transform.position, transform.up, 180f);
            distTravelled = 0;
        }

        //Debug.Log(moveDirection * Time.deltaTime * horizontalSpeed);
        //pos += (Vector3.forward * horizontalSpeed * Time.deltaTime);   //right or left movement
        //pos.y += Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Altitude;  //Up-down movement
        //transform.position = pos;
        //Vector3 moveDirection = transform.forward.normalized;
        // Vector3 moveAmount = moveDirection * Time.deltaTime * horizontalSpeed;
        //Debug.Log(horizontalSpeed);
        //Debug.Log(Time.deltaTime);
        //transform.position += moveAmount;
    }
}
