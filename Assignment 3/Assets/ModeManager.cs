using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ModeManager : MonoBehaviour
{
    public GameObject player;
    public GameObject maincam;
    public GameObject leftray;
    public GameObject righttele;
    public GameObject club;
    public GameObject canvas;
    public GameObject startTileCurr;



    public bool walkMode = true;
    public bool Buildmode = false;
    public bool playMode = false;
    public bool enter = false;
    public bool inhole;

    public InputActionProperty YButton;
    public Transform head;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("/GameMenu/Canvas");
        inhole = false;
        //canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (YButton.action.WasPerformedThisFrame())
        {
            Debug.Log(YButton.action);
            Debug.Log("Y Pressed!");
            if (Buildmode == false)
            {
                //Debug.Log("ACTIVATE!");
                Buildmode = true;
                // Activate Ray and Canvas
                leftray.SetActive(true);
                canvas.SetActive(true);

            }

            else if (Buildmode == true)
            {
                //Debug.Log("DEACTIVATE!");
                Buildmode = false;
                // Activate Ray and Canvas
                leftray.SetActive(false);
                canvas.SetActive(false);

            }

        }
       
        playMode = gameObject.GetComponent<PlayMode>().onStart;
       
        
        //Debug.Log("FROM ModeManager (playmode): "+playMode);
        

        //Debug.Log(playMode);

        if (playMode == true)
        {
            //Debug.Log("PLAY MODE!");
            
            startTileCurr = gameObject.GetComponent<PlayMode>().startTileCurrent;
            club.SetActive(true);
            //walkMode = false;
            //Buildmode = false;
            //leftray.SetActive(false);
            //righttele.SetActive(false);


        }

        else if (playMode == false)
        {
            club.SetActive(false);
            
            

        }


    }
}
