using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class WetFloor : MonoBehaviour
{
    public GameObject screen;

    VideoPlayer player;

    void Start()
    {
        player = screen.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        
    }
}
