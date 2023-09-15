using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCol : MonoBehaviour
{
    public int posX;
    public int posY;



    // Saves reference to gameobject that's placed on this cell
    public GameObject objectInThisGridSpace = null;

    public bool isOccupied = false;

    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }
    // Start is called before the first frame update

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);

        //float minx = Mathf.Clamp(transform.position.x, minValue, maxValue)

        //col.gameObject.transform.position = new Vector3(transform.position.x, col.transform.position.y, transform.position.z);
        //col.transform.eulerAngles = new Vector3(col.transform.eulerAngles.x, col.transform.eulerAngles.y, col.transform.eulerAngles.z);

        isOccupied = true;
        Debug.Log(gameObject.transform.position);
        Debug.Log(transform.position);
    }
    void OnTriggerExit(Collider col)
    {
        Debug.Log(col.gameObject.name);
        isOccupied = false;

        Debug.Log(gameObject.transform.position);
        Debug.Log(transform.position);
    }

}
