using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ActivateCheckout : MonoBehaviour
{
    public GameObject checkoutVideo;
    public GameObject checkoutWall;
    public GameObject self;

    VideoPlayer vp;

    void Start()
    {
        checkoutVideo.SetActive(false);
       vp = checkoutVideo.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        RaycastHit hit;

        if(Physics.SphereCast(transform.position, 1f, Vector3.up, out hit))
        {
            if(hit.collider.tag == "Player")
            {
                ActivateCheckoutScript();
            }
        }
    }

    void ActivateCheckoutScript()
    {
            vp.url = "Assets/Videos/CheckoutVideo.mp4";
            checkoutVideo.SetActive(true);
            checkoutWall.SetActive(true);
            vp.Play();
            self.SetActive(false);
    }
}
