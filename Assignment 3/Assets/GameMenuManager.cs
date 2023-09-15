using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty showButton;
    private bool active = false;
    private float spawnDistance = 4;
    public Transform head;
    public GameObject player;
    public bool build = false;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("/GameMenu/Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        build = player.GetComponent<ModeManager>().Buildmode;
        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;

        if (showButton.action.WasPerformedThisFrame() && build)
        {
            active = !active;
            menu.SetActive(active);
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }


        
    }
}
