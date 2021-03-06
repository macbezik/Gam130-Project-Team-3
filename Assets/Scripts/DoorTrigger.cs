﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject movingObject;

    Animator objectAnimation;

    private void Start()
    {
        objectAnimation = movingObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player collided with trigger");

        objectAnimation.SetBool("OpenDoor", true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player has left the trigger");

        objectAnimation.SetBool("OpenDoor", false);
    }
}
