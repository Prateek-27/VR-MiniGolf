using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnTiles2BumperS : MonoBehaviour
{
    public GameObject B2STile;
    public GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {

        // adding a delegate with no parameters
        GetComponent<Button>().onClick.AddListener(NoParamaterOnclick);


    }

    private void NoParamaterOnclick()
    {

        Instantiate(B2STile, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
    }
}
