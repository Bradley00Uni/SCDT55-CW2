using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateDesk : MonoBehaviour
{
    public GameObject self;
    public GameObject wall;
    public GameObject screen;

    VideoPlayer player;

    void Start()
    {
        player = screen.GetComponent<VideoPlayer>();
        screen.SetActive(false);
        wall.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 1f, Vector3.up, out hit))
        {
            if (hit.collider.tag == "Player"){ActivateDeskScript();}
        }

        player.loopPointReached += EndVideo;
    }

    void ActivateDeskScript()
    {
        screen.SetActive(true);
        player.url = "Assets/Videos/DeskVideo.mp4";
        player.Play();

        wall.SetActive(true);
        self.SetActive(false);
    }

    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        wall.SetActive(false);
        screen.SetActive(false);
    }
}
