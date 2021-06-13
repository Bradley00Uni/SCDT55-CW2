using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CheckoutBeep : MonoBehaviour
{
    public AudioSource beepSource;
    public GameObject self;

    public GameObject videoPlayer;
    public GameObject exitPlayer;
    public GameObject checkoutExit;
    public GameObject cleaningWall;

    public GameObject alcoholLight;
    public GameObject medicineLight;
    public GameObject tagLight;

    bool a;
    bool m;
    bool s;

    public Material complete;
    VideoPlayer player;
    VideoPlayer exit;
    string type;

    void Start()
    {
        player = videoPlayer.GetComponent<VideoPlayer>();
        exit = exitPlayer.GetComponent<VideoPlayer>();
        exitPlayer.SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            beepSource.Play();
        }

        if (col.gameObject.tag == "Alcohol")
        {
            type = "Alcohol";
            videoPlayer.SetActive(true);
            player.url = Application.persistentDataPath + "/AlcoholVideo.mp4";
            player.Play();
        }
        else if (col.gameObject.tag == "Medicine")
        {
            type = "Medicine";
            videoPlayer.SetActive(true);
            player.url = Application.persistentDataPath + "/MedicineVideo.mp4";
            player.Play();
        }
        else if (col.gameObject.tag == "Security")
        {
            type = "Security";
            videoPlayer.SetActive(true);
            player.url = Application.persistentDataPath + "/SecurityVideo.mp4";
            player.Play();
        }
    }

    void Update()
    {
        if (a && m && s)
        {
            exitPlayer.SetActive(true);
            exit.Play();

            exit.loopPointReached += EndSection;
        }
        player.loopPointReached += EndVideo;
    }


    void EndVideo(UnityEngine.Video.VideoPlayer vid)
    {
        videoPlayer.SetActive(false);

        if (type == "Alcohol")
        {
            a = true;
            alcoholLight.GetComponent<MeshRenderer>().material = complete;
        }
        else if (type == "Medicine")
        {
            m = true;
            medicineLight.GetComponent<MeshRenderer>().material = complete;
        }
        else if (type == "Security")
        {
            s = true;
            tagLight.GetComponent<MeshRenderer>().material = complete;
        }
    }

    void EndSection(UnityEngine.Video.VideoPlayer vid)
    {
        exitPlayer.SetActive(false);
        checkoutExit.SetActive(false);
        self.SetActive(false);
        cleaningWall.SetActive(false);
    }
}