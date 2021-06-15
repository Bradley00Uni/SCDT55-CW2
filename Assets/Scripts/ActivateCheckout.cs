using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateCheckout : MonoBehaviour
{
    //DECLARE VARIABLES OF OBJECTS IN SCENE
    public GameObject checkoutVideo;
    public GameObject checkoutWall;
    public GameObject self;

    VideoPlayer vp;

    //RUNS ON SCENE LOAD
    void Start()
    {
       vp = checkoutVideo.GetComponent<VideoPlayer>();
       checkoutVideo.SetActive(false);
    }

    //RUNS EVERY FRAME OF SCENE
    void Update()
    {
        RaycastHit hit;

        //Activates when user enters the checkout
        if(Physics.SphereCast(transform.position, 1f, Vector3.up, out hit))
        {
            if(hit.collider.tag == "Player")
            {
                ActivateCheckoutScript();
            }
        }
    }

    //FUNCTION FOR ACTIVATING CHECKOUT EXERCISE
    void ActivateCheckoutScript()
    {
            vp.url = Application.persistentDataPath + "/CheckoutVideo.mp4";
            checkoutVideo.SetActive(true);
            checkoutWall.SetActive(true);
            vp.Play();
            self.SetActive(false);
    }
}
