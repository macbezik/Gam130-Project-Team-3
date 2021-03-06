﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    bool InsideViewrange = false;
    bool IsBeingDetected = false;

    public GameObject playerObject;
    public float cameraViewRange;

    public GameObject light1, light2;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    void Update()
    {
        if(InsideViewrange)
        {
            Debug.Log("inside view range");
            HandleRaycast();
        }

    }

    void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if(player != null)
        {
            InsideViewrange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            InsideViewrange = false;
        }
    }




    private void HandleRaycast()
    {
     
        RaycastHit hit;

        if (Physics.Raycast(transform.position, (playerObject.transform.position - transform.position), out hit))
        {

            if (hit.collider.tag == "Player")
            {
                
                Debug.DrawRay(transform.position, (playerObject.transform.position - transform.position), Color.red);
                IsBeingDetected = true;
                this.gameObject.GetComponent<Animator>().SetBool("SeePlayer", true);
                StartCoroutine(CheckDetection());
            }
            else
            {
                Debug.Log("not being detected");
                IsBeingDetected = false;
                StopCoroutine(CheckDetection());
            }

        }
    }

    void DetectedPlayer()
    {
        if (IsBeingDetected)
        {
            Debug.Log("Game Over");
            // can add the ending bit here
        }
        else
        {
            this.gameObject.GetComponent<Animator>().SetBool("SeePlayer", false);
            light1.SetActive(true);
            light2.SetActive(false);
            return;
        }
  
    }

    IEnumerator CheckDetection()
    {
        light1.SetActive(false);
        light2.SetActive(true);
        yield return new WaitForSeconds(3);
        DetectedPlayer();
    }

}
