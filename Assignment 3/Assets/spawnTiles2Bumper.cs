using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnTiles2Bumper : MonoBehaviour
{
    public GameObject B2Tile;
    public GameObject player;

    private void Awake()
    {

        // adding a delegate with no parameters
        GetComponent<Button>().onClick.AddListener(NoParamaterOnclick);


    }

    private void NoParamaterOnclick()
    {

        Instantiate(B2Tile, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
    }
}
