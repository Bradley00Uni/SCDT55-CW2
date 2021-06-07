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

    bool m;
    bool v;

    int mopCount;
    VideoPlayer player;

    void Start()
    {
        player = screen.GetComponent<VideoPlayer>();
        mopCount = 0;
        m = false; v = false;

        deskWall.SetActive(true);
        spillWall.SetActive(true);
    }

    void Update()
    {
        if (mopCount >= 4)
        {
            mop.SetActive(false);
            self.SetActive(false);
            mopCount = 0;
            m = true;
        }

        if (!m)
        {
            player.loopPointReached += EndVideo;
        }
        else if (m && !v)
        {
            EndSection();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Cleaning") { mopCount++; }
    }

    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        screen.SetActive(false);

        if(m && v)
        {
            Close();
        }
    }

    void EndSection()
    {
        player.url = "Assets/Videos/SpillEndVideo.mp4";
        screen.SetActive(true);
        player.Play();
        v = true;
    }

    void Close()
    {
        screen.SetActive(false);
        deskWall.SetActive(false);
        spillWall.SetActive(false);
    }
}