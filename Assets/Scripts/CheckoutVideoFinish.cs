using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CheckoutVideoFinish : MonoBehaviour
{
    public GameObject vp;
    VideoPlayer player;

    void Start()
    {
        player = vp.GetComponent<VideoPlayer>();
        vp.SetActive(false);
    }

    void Update()
    {
        player.loopPointReached += EndVideo;
    }

    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        vp.SetActive(false);
    }

}
