﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptController : MonoBehaviour
{

    public float speed = 0.1f;
    public Transform farLeft;  // End of screen Left
    public Transform farRight;  //End of Screen Right

    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, 0, 0);

            if (transform.position.x > farRight.position.x)
            {
                transform.position = new Vector3(farRight.position.x, transform.position.y, transform.position.z);
            }

            if (transform.position.x < farLeft.position.x)
            {
                transform.position = new Vector3(farLeft.position.x, transform.position.y, transform.position.z);
            }
               
        }
       
    }
    }
    

