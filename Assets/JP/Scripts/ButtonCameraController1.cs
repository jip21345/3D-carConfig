using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarConfigurator
{
    class ButtonCameraController : MonoBehaviour
    {
        public AudioSource speaker;
        //data - Information we need to do our work
        public Camera configuratorCamera;
        public Transform[] angles;
        //index of the next camera in our angles array
        int nextAngle = -1;
        public Transform carPosition;
        private bool canSwivel = false;


        private void Update()
        {

            if (canSwivel == true)
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




            //if nextAngle has reached the end,go back to the beginning(0)
            if (nextAngle >= angles.Length)
            {
                nextAngle = 0;

            }



            


        }

        public void MoveCameraToPreviousAngle()
        {

            Debug.Log("BYE");

        }



    }

}
