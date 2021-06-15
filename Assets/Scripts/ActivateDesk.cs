using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateDesk : MonoBehaviour
{
    //DECLARE VARIABLES OF OBJECTS IN SCENE
    public GameObject self;
    public GameObject wall;
    public GameObject screen;

    VideoPlayer player;

    //RUNS ON SCENE LOAD
    void Start()
    {
        player = screen.GetComponent<VideoPlayer>();
        screen.SetActive(false);
        wall.SetActive(false);
    }

    //RUNS EVERY FRAME OF SCENE
    void Update()
    {
        RaycastHit hit;

        //Activates when user passes the desk
        if (Physics.SphereCast(transform.position, 1f, Vector3.up, out hit))
        {
            if (hit.collider.tag == "Player"){ActivateDeskScript();}
        }

        //Activates when current video finishes
        player.loopPointReached += EndVideo;
    }

    //FUNCTION FOR ACTIVATING DESK EXERCISE
    void ActivateDeskScript()
    {
        screen.SetActive(true);
        player.url = Application.persistentDataPath + "/DeskVideo.mp4";
        player.Play();

        wall.SetActive(true);
        self.SetActive(false);
    }

    //FUNCTION FOR HIDING VIDEO PLAYER AND EDITING OBJECTS
    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        wall.SetActive(false);
        screen.SetActive(false);
    }
}
