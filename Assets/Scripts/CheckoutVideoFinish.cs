using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CheckoutVideoFinish : MonoBehaviour
{
    //DECLARE VARIABLES OF OBJECTS IN SCENE
    public GameObject vp;
    VideoPlayer player;

    //RUNS ON SCENE LOAD
    void Start()
    {
        player = vp.GetComponent<VideoPlayer>();
    }

    //RUNS EVERY FRAME OF SCENE
    void Update()
    {
        //Activates when current video finishes
        player.loopPointReached += EndVideo;
    }

    //FUNCTION FOR HIDING VIDEO PLAYER
    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        vp.SetActive(false);
    }
}
