using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FirstVideoFinish : MonoBehaviour
{
    public GameObject entrance;
    public GameObject entranceblock;
    public GameObject checkoutblock;
    VideoPlayer entranceplayer;

    void Start()
    {
        entranceplayer = entrance.GetComponent<VideoPlayer>();
    }
    
    void Update()
    {
        entranceplayer.loopPointReached += StartTraining;
    }

    void StartTraining(UnityEngine.Video.VideoPlayer vid)
    {
        entrance.SetActive(false);
        entranceblock.SetActive(false);
        checkoutblock.SetActive(false);
    }

}