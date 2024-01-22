using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject playerModel;
    public AudioSource dieSound;
    public GameObject mainCamera;
    public GameObject levelControl;
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        playerModel.GetComponent<Animator>().Play("Die");
        levelControl.GetComponent<DistanceController>().enabled = true;
        dieSound.Play();
        mainCamera.GetComponent<Animator>().enabled = true;
    }
}
