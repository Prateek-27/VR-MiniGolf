using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class inHole : MonoBehaviour
{
    public GameObject player;
    public GameObject xr;
    public ModeManager mm;
    public GameObject ball;
    public AudioSource source;


    public bool hole = false;
    public bool xrinhole;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("GolfB"))
        {
            ball = other.gameObject;
            Debug.Log("HOLE!");
            xrinhole = xr.GetComponent<ModeManager>().inhole;
            hole = true;
            xr.GetComponent<PlayMode>().inhole = true;
            Debug.Log("fromhole inhoel" + xr.GetComponent<ModeManager>().inhole);
            Win();
            Destroy(other.gameObject);
        }
    }

    void Win()
    {
        source.Play();
        xr.GetComponent<ModeManager>().playMode = false;
    }

    private void Start()
    {
        xr = player.transform.GetChild(3).gameObject;
        mm = xr.GetComponent<ModeManager>();
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        
        //Debug.Log("fromhole inhoel" + xrinhole);
        mm.inhole = true;
    }
}
