using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CheckoutBeep : MonoBehaviour
{
    public AudioSource beepSource;
    public GameObject videoPlayer;

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 8)
        {
            beepSource.Play();
        }

        if(col.gameObject.tag == "Alcohol")
        {
            videoPlayer.SetActive(true);
            videoPlayer.GetComponent<VideoPlayer>().url = "Assets/Videos/booze_scanned.mp4";
            videoPlayer.GetComponent<VideoPlayer>().Play();
        }
    }
}
