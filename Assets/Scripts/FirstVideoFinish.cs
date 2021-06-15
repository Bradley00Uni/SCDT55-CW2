using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FirstVideoFinish : MonoBehaviour
{
    //DECLARE VARIABLES OF OBJECTS IN SCENE
    public GameObject entrance;
    public GameObject entranceblock;
    public GameObject checkoutblock;
    VideoPlayer entranceplayer;

    //RUNS ON SCENE LOAD
    void Start()
    {
        entranceplayer = entrance.GetComponent<VideoPlayer>();
    }

    //RUNS EVERY FRAME OF SCENE
    void Update()
    {
        entranceplayer.loopPointReached += StartTraining;
    }

    //FUNCTION TO OPEN UP SIMULATION SPACE ONCE INTRODUCTION HAS FINISHED
    void StartTraining(UnityEngine.Video.VideoPlayer vid)
    {
        entrance.SetActive(false);
        entranceblock.SetActive(false);
        checkoutblock.SetActive(false);
    }

}