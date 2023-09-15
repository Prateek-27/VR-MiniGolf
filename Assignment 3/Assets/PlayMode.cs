using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayMode : MonoBehaviour
{
    public bool onStart = false;
    public GameObject startTileCurrent;
    public GameObject golfball;

    public GameObject leftloco;
    public bool motion;
    public GameObject xr;
    public bool flag;
    public bool inhole = false;
    public AudioSource source;
    public Transform ballTrsf;

    public GameObject righttele;
    public InputActionProperty AButton;
    public GameObject club; 

    public Transform startpos;

    private bool created = false;
    private List<GameObject> startList = new List<GameObject>();

    void OnControllerColliderHit(ControllerColliderHit col)
    {

        startpos = xr.transform;

        

        if (col.collider.gameObject.name.StartsWith("Start"))
        {


            //Debug.Log(col.collider.gameObject);
            col.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            startTileCurrent = col.gameObject;
            onStart = true;

            /*
            if (AButton.action.WasPerformedThisFrame())
            {
                Debug.Log(AButton.action);
                Debug.Log("A Pressed!");
                if (onStart == true)
                {
                    
                    //Debug.Log("ACTIVATE!");
                    onStart = false;
                    // Activate Ray and Canvas
                    club.SetActive(false);

                }
            }
            */
                //Debug.Log(startList.IndexOf(startTileCurrent));
                if (!created && startList.IndexOf(startTileCurrent) < 0)
                //if (!created )
                {
                golfball = Instantiate(golfball, new Vector3(startTileCurrent.transform.position.x, startTileCurrent.transform.position.y, startTileCurrent.transform.position.z), Quaternion.identity);
                golfball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                
                created = true;
            }

            //xr.transform.position = new Vector3(startTileCurrent.transform.position.x , startTileCurrent.transform.position.y, startTileCurrent.transform.position.z);
            xr.transform.position = new Vector3(startTileCurrent.transform.position.x, xr.transform.position.y, startTileCurrent.transform.position.z);
            //xr.transform.position = new Vector3(xr.transform.position.x + golfball.transform.forward.x, xr.transform.position.y, xr.transform.position.z + golfball.transform.forward.z);
            
           
            startList.Add(col.gameObject);
            created = false;
        }




    }


    // Start is called before the first frame update
    void Start()
    {
        xr = GameObject.Find("/Complete XR Origin Set Up/XR Origin/");
        leftloco = GameObject.Find("/Complete XR Origin Set Up/XR Origin/CameraOffset/LeftHand (Smooth locomotion)");
        source = GetComponent<AudioSource>();
        


    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(!golfball.GetComponent<ball>().motion);
        if (golfball != null)
        {
            ballTrsf = golfball.transform;
            if (golfball.GetComponent<ball>().hit)
            {
                flag = true;
                ballTrsf = golfball.transform;
                xr.transform.position = new Vector3(golfball.transform.position.x, golfball.transform.position.y + 0.1f, golfball.transform.position.z);
            }

            if (flag == true && golfball != null)
            {
                if (golfball.GetComponent<Rigidbody>().IsSleeping())
                {
                    if (golfball.GetComponent<ball>().hitcount == 3)
                    {
                        Lose();
                        golfball.GetComponent<ball>().hitcount = 0;
                        
                    }
                    //ballTrsf = golfball.transform;
                    xr.transform.position = new Vector3(golfball.transform.position.x, golfball.transform.position.y + 0.1f, golfball.transform.position.z);
                    flag = false;
                }
            }

            
        }
        


        if (golfball == null)
        {
            Debug.Log("Works!");
            onStart = false;
            //xr.transform.position = startpos.position;
        }

        
    }

    void Lose()
    {
        StartCoroutine(DelayFunction());
        Debug.Log("LOSE");
        
        onStart = false;
        Destroy(golfball);

    }
    IEnumerator DelayFunction()
    {
        yield return new WaitForSeconds(4);
        source.Play();
    }
}
