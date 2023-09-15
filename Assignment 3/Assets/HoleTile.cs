using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleTile : MonoBehaviour
{
    public GameObject HTile;
    public GameObject player;

    private void Awake()
    {

        // adding a delegate with no parameters
        GetComponent<Button>().onClick.AddListener(NoParamaterOnclick);


    }

    private void NoParamaterOnclick()
    {

        Instantiate(HTile, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
    }
}
