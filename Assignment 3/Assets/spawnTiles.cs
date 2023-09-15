using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnTiles : MonoBehaviour
{
    public GameObject startTile;
    public GameObject player;
    //public GameObject startTiles[];

    private void Awake()
    {

        // adding a delegate with no parameters
        GetComponent<Button>().onClick.AddListener(NoParamaterOnclick);

       
    }

    private void NoParamaterOnclick()
    {

        Instantiate(startTile, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        //startTile = (GameObject)Instantiate(startTile, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

    }
}
