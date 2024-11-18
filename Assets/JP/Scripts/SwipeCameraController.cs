using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CarConfigurator
{
    class SwipeCameraController : MonoBehaviour
    {
        public TMP_Text debugText;
        public AudioSource speaker;
        //data - Information we need to do our work
        public Camera configuratorCamera;
        public Transform[] angles;
        //index of the next camera in our angles array
        int nextAngle = -1;
        public Transform carPosition;
        private bool canSwivel = false;
        Vector2 startPosition;


        private void Update()
        {
            // Detect swipe input
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                debugText.text = "Recieving Touch At "+touch.position.ToString();

                if (touch.phase == TouchPhase.Began)

                {
                     startPosition = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    Vector2 endPosition = touch.position;
                  float changeInAxis =  endPosition.x - startPosition.x;

                    if (changeInAxis > 20f)
                    {
                        debugText.text = "Change in axis " + changeInAxis;
                        MoveCameraToNextAngle();
                    }
                    else if (changeInAxis < -20f) 
                    {
                        debugText.text = "Change in axis " + changeInAxis;

                        MoveCameraToPreviousAngle();
                    }
                }
                // if swipe is to the right 
                // move camera to next angle
                // if swipe is to the left 
                // move angle to previous angle

            }

            ChangeAngle();



        }

        private void ChangeAngle()
        {
           if(canSwivel == true)
            {
                Transform nextTransform = angles[nextAngle];
                 
                configuratorCamera.transform.position = Vector3.Lerp(configuratorCamera.transform.position, nextTransform.position, Time.deltaTime);

                configuratorCamera.transform.LookAt(carPosition);
            }
        }

        // functionality - what we need to do
        public void MoveCameraToNextAngle()
        {
            speaker.Play();
            canSwivel = true;
            
            //increment nextAngle by 1
            nextAngle = nextAngle + 1;
            debugText.text = "next angle " + nextAngle;



            //if nextAngle has reached the end,go back to the beginning(0)
            if (nextAngle >= angles.Length)
            {
                nextAngle = 0;

            }



            


        }

        public void MoveCameraToPreviousAngle()
        {
            speaker.Play();
            canSwivel = true;

            //increment nextAngle by 1
            nextAngle = nextAngle - 1;
            

            //If nextAngle has reached the beginning, loop
            if ( nextAngle < 0)
            {
                nextAngle = angles.Length - 1;
            }
          

        }



    }

}
