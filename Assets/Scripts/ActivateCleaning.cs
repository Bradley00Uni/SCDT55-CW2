using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateCleaning : MonoBehaviour
{
    //DECLARE VARIABLES OF OBJECTS IN SCENE
    public GameObject self;
    public GameObject screen;
    VideoPlayer player;

    public GameObject deskWall;
    public GameObject spillWall;

    //RUNS ON SCENE LOAD
    void Start()
    {
        screen.SetActive(false);
        player = screen.GetComponent<VideoPlayer>();
    }

    //RUNS EVERY FRAME OF SCENE
    void Update()
    {
        RaycastHit hit;

        //Activates when user enters the aisle
        if (Physics.SphereCast(transform.position, 1f, Vector3.up, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                ActivateCleaningScript();
            }
        }
    }

    //FUNCTION FOR ACTIVATING CLEANING EXERCISE
    void ActivateCleaningScript()
    {
        screen.SetActive(true);
        player.url = Application.persistentDataPath + "/SpillVideo.mp4";
        player.Play();
        self.SetActive(false);
    }
}
