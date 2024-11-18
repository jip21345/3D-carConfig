using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintManager : MonoBehaviour
{
    //reference to car's mesh renderer to change the color 
    public MeshRenderer carBodyRenderer;

    // references to the array of materials that we made 
    public Material[] carmaterials;

    public Image[] paintbuttons;


    private void Start()
    {
        //get the list of car materials 
        // for each material in the list 

        for (int i = 0; i < paintbuttons.Length; i++) 
        
        {

            paintbuttons[i].color = carmaterials[i].color;
        
        
        
        }


        //set the color of the correspoding paint button

        
    }


    public void SetCarPaint(int paintindex)
    {
        carBodyRenderer.material = carmaterials[paintindex];  
    }


}
