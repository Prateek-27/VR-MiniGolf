using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    public int posX;
    public int posY;
    private Vector3 gridSize = new Vector3(4, 0.1f, 4);
    float angle;
    float diff;



    // Saves reference to gameobject that's placed on this cell
    public GameObject objectInThisGridSpace = null;

    public bool isOccupied = false;

    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }

 

    void OnTriggerEnter(Collider col)
    {
        isOccupied = true;

        objectInThisGridSpace = col.gameObject;
        isOccupied = true;



        //Debug.Log(col.gameObject.name);
        col.gameObject.transform.position = new Vector3(transform.position.x + 1, col.transform.position.y + 0.005f, transform.position.z + 1);
        //col.transform.eulerAngles = new Vector3(col.transform.eulerAngles.x, col.transform.eulerAngles.y, col.transform.eulerAngles.z);

        
        //Debug.Log(gameObject.transform.position);
        //Debug.Log(transform.position);



        // Adjust the rotation of the other object
   
        angle = col.transform.rotation.eulerAngles.y;

        diff =angle - transform.rotation.eulerAngles.y;

        //Debug.Log(diff);

        if (diff >= 0 && diff < 90)
        {
            col.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }

        else if (diff >= 90 && diff <180)
        {
            col.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y+90, 0f);
        }

        else if (diff >= 180 && diff < 270)
        {
            col.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 180, 0f);
        }

        else if (diff >= 270 && diff < 360)
        {
            col.transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y + 270, 0f);
        }

      

    }
    void OnTriggerExit(Collider col)
    {
        //Debug.Log(col.gameObject.name);
        isOccupied = false;
      
        //Debug.Log(gameObject.transform.position);
        //Debug.Log(transform.position);
    }

}
