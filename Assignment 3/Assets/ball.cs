using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private GameObject club;
    //[SerializeField] private GameObject player;
    private Rigidbody rb;
    Vector3 direction;
    public GameObject xr;
    float force = 5f;
    public bool hit;
    public int hitcount = 0;
    public bool motion = true;
    float speed;
    public float distance = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        rb = GetComponent<Rigidbody>();
        club = GameObject.Find("/Complete XR Origin Set Up/XR Origin/CameraOffset/RightHand (Teleport Locomotion)/GolfClub");
        xr = GameObject.Find("/Complete XR Origin Set Up/XR Origin/");

        //direction = player.transform.forward;
        //club = GameObject.Find("/XR Origin/CameraOffset/RightHand(Teleport Locomotion)/GolfClubHolder/GolfClub/");
        //player = GameObject.Find("/XR Origin/");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 cameraPosition = Camera.main.transform.position;
        //Vector3 cameraForward = Camera.main.transform.forward;
        //Vector3 cameraDirection = Camera.main.transform.forward;

        Vector3 clubDirection = club.transform.forward;
        Vector3 directionHit = new Vector3(clubDirection.x, 0f, clubDirection.z);

        //Vector3 horizontalDirection = new Vector3(cameraDirection.x, 0f, cameraDirection.z);

        // Get a point in the direction that the camera is looking
        //Vector3 lookPosition = cameraPosition + cameraForward * distance;

        if (hitcount > 3)
        {
            hitcount = 0;
        }

        if (hit == true)
        {
            rb.AddForce(directionHit * force, ForceMode.Impulse);
            
            
        }

        
    }
    
 
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "GolfClub")
        {
            //direction = player.transform.forward;
            motion = true;
            hit = true;
            hitcount+= 1;


        }

        //Debug.Log(other.name);

        if (other.gameObject.name.StartsWith("Grid"))
        {
            Debug.Log("Out of Bounds!");
            //Destroy(gameObject);
            //Instantiate(gameObject, new Vector3(xr.transform.position.x, xr.transform.position.y, xr.transform.position.z), Quaternion.identity);
            //xr.GetComponent<PlayMode>().golfball = Instantiate(gameObject, new Vector3(xr.transform.position.x, xr.transform.position.y, xr.transform.position.z), Quaternion.identity);

            //transform.position = xr.GetComponent<PlayMode>().ballTrsf.position;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "GolfClub")
        {
            hit = false;
        }

        }


}
