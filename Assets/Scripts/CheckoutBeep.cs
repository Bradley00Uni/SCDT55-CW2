using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CheckoutBeep : MonoBehaviour
{
    //DECLARE VARIABLES OF OBJECTS IN SCENE
    public AudioSource beepSource;
    public GameObject self;

    public GameObject videoPlayer;
    public GameObject exitPlayer;
    public GameObject checkoutExit;
    public GameObject cleaningWall;

    public GameObject alcoholLight;
    public GameObject medicineLight;
    public GameObject tagLight;

    //Task Completion Variables
    bool a;
    bool m;
    bool s;

    public Material complete;
    VideoPlayer player;
    VideoPlayer exit;
    string type;

    //RUNS ON SCENE LOAD
    void Start()
    {
        player = videoPlayer.GetComponent<VideoPlayer>();
        exit = exitPlayer.GetComponent<VideoPlayer>();
        exitPlayer.SetActive(false);
    }

    //RUNS WHEN OBJECT COLLIDES WITH SCRIPT SOURCE-OBJECT
    void OnCollisionEnter(Collision col)
    {
        //If the Object is a checkout product
        if (col.gameObject.layer == 8)
        {
            beepSource.Play();
        }

        //Plays different video based on which training object is scanned
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

    //RUNS EVERY FRAME OF SCENE
    void Update()
    {
        //Run if all three training videos have completed
        if (a && m && s)
        {
            exitPlayer.SetActive(true);
            exit.Play();

            //Activates when current video finishes
            exit.loopPointReached += EndSection;
        }
        //Activates when current video finishes
        player.loopPointReached += EndVideo;
    }

    //FUNCTION FOR EDITING COMPLETION "LIGHTS" AND HIDING VIDEO PLAYER
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

    //FUNCTION FOR HIDING VIDEO PLAYER AND EDITING OBJECTS
    void EndSection(UnityEngine.Video.VideoPlayer vid)
    {
        exitPlayer.SetActive(false);
        checkoutExit.SetActive(false);
        self.SetActive(false);
        cleaningWall.SetActive(false);
    }
}