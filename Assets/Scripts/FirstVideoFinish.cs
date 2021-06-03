using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FirstVideoFinish : MonoBehaviour
{
    public GameObject vp;
    public GameObject entrance;
    public GameObject entranceblock;
    public GameObject checkoutblock;
    VideoPlayer player;
    VideoPlayer entranceplayer;

    void Start()
    {
        player = vp.GetComponent<VideoPlayer>();
        entranceplayer = entrance.GetComponent<VideoPlayer>();
    }
    
    void Update()
    {
        player.loopPointReached += EndVideo;
        entranceplayer.loopPointReached += StartTraining;
    }

    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        vp.SetActive(false);
    }

    void StartTraining(UnityEngine.Video.VideoPlayer vid)
    {
        entrance.SetActive(false);
        entranceblock.SetActive(false);
        checkoutblock.SetActive(false);
    }

}