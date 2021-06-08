using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateCleaning : MonoBehaviour
{
    public GameObject self;
    public GameObject screen;
    VideoPlayer player;

    public GameObject deskWall;
    public GameObject spillWall;

    void Start()
    {
        screen.SetActive(false);
        player = screen.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(transform.position, 1f, Vector3.up, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                ActivateCleaningScript();
            }
        }
    }

    void ActivateCleaningScript()
    {
        screen.SetActive(true);
        player.url = Application.persistentDataPath + "/SpillVideo.mp4";
        player.Play();
        self.SetActive(false);
    }
}
