using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettingsMovementScript : MonoBehaviour
{

    private Vector3 mainMenuCameraPosition;

    private Vector3 optionsMenuCameraPosition;


    private bool moveToSettings = false;

    private float speed = 0.1f;



    /* functions */
    void Start()
    {
        mainMenuCameraPosition = new Vector3(0f, 1f, -9f);

        optionsMenuCameraPosition = new Vector3(204f, 1f, -9f);
    }


    public void settingsSlideChange()
    {
        if (moveToSettings) //true
        {
            FindObjectOfType<AudioManagerScript>().BackSound();

            moveToSettings = false;
        }
        else if(!moveToSettings) //false
        {
            FindObjectOfType<AudioManagerScript>().SettingsSound();

            moveToSettings = true;
        }
    }


    void Update()
    {
        if (moveToSettings)
        {
            transform.position = Vector3.Lerp(transform.position, optionsMenuCameraPosition, speed);
        }
        else
        {           
            transform.position = Vector3.Lerp(transform.position, mainMenuCameraPosition, speed);
        }     
    }
}