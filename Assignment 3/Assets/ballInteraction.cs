using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballInteraction : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "GolfBall")
        {
            Debug.Log(col.gameObject.name);
            GetComponent<Rigidbody>().isKinematic = true;
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "GolfBall")
        {
            Debug.Log(col.gameObject.name);
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
