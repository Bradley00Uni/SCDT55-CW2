using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WetFloor : MonoBehaviour
{
    //DECLARE VARIABLES OF OBJECTS IN SCENE
    public GameObject screen;
    public GameObject self;
    public GameObject mop;

    public GameObject deskWall;
    public GameObject spillWall;

    VideoPlayer player;

    //Task Completion Variables
    bool m;
    bool v;
    int mopCount;

    //RUNS ON SCENE LOAD
    void Start()
    {
        player = screen.GetComponent<VideoPlayer>();
        mopCount = 0;
        m = false; v = false;

        deskWall.SetActive(true);
        spillWall.SetActive(true);
    }

    //RUNS EVERY FRAME OF SCENE
    void Update()
    {
        //If mop has collided with spill 4 times
        if (mopCount >= 4)
        {
            mop.SetActive(false);
            self.SetActive(false);
            mopCount = 0;
            m = true;
        }

        //If mopping incomplete | If mopping complete but video hasnt
        if (!m)
        {
            player.loopPointReached += EndVideo;
        }
        else if (m && !v)
        {
            EndSection();
        }
    }

    //RUNS WHEN OBJECT COLLIDES WITH SCRIPT SOURCE-OBJECT
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cleaning") { mopCount++; }
    }

    //FUNCTION FOR ENDING TRAINING SECTION
    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        screen.SetActive(false);

        //If Both video and mopping are complete
        if(m && v)
        {
            Close();
        }
    }

    //FUNCTION FOR HIDING VIDEO PLAYER AND EDITING OBJECTS
    void EndSection()
    {
        player.url = Application.persistentDataPath + "/SpillEndVideo.mp4";
        screen.SetActive(true);
        player.Play();
        v = true;
    }

    //REMOVAL OF BARRIERS
    void Close()
    {
        screen.SetActive(false);
        deskWall.SetActive(false);
        spillWall.SetActive(false);
    }
}