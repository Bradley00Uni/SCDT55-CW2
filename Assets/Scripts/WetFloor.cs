using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WetFloor : MonoBehaviour
{
    public GameObject screen;
    public GameObject self;
    public GameObject mop;

    public GameObject deskWall;
    public GameObject spillWall;

    int mopCount;
    VideoPlayer player;

    void Start()
    {
        player = screen.GetComponent<VideoPlayer>();
        mopCount = 0;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cleaning"){mopCount++;}
    }

    void Update()
    {
        player.loopPointReached += EndVideo;

        if(mopCount >= 4)
        {
            mop.SetActive(false);
            self.SetActive(false);
            mopCount = 0;
        }

        if(!mop.activeSelf && !screen.activeSelf)
        {
            deskWall.SetActive(false);
            spillWall.SetActive(false);
        }
    }

    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        screen.SetActive(false);
    }
}
