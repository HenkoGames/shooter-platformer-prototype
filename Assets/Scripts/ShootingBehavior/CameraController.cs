using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;
    public Transform target;
    public Transform player;
    [Space]
    public float maxRange;
    private Camera camComp;
    public Joystick joystick;

    private Vector3 vectorBuffer;
    private Vector3 camGoal;
    void Awake()
    {
        camComp = cam.gameObject.GetComponent<Camera>();
        target.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        findGoal();
        changeCamPos();
    }

    //Function that search for place where camera should be
    //You can change camGoal variable to cam.transform.position for instant position change 
    private void findGoal()
    {
        if (joystick.Direction.magnitude > 0.1f) {
            vectorBuffer.x = joystick.Direction.x*maxRange;
            vectorBuffer.y = joystick.Direction.y*maxRange;
            vectorBuffer.z = target.position.z;
            target.localPosition = vectorBuffer;


            vectorBuffer = Vector3.Lerp(target.position, player.position, 0.5f);
            vectorBuffer.z = cam.position.z;
            camGoal = vectorBuffer;


            if(!target.gameObject.activeSelf)target.gameObject.SetActive(true);


        }
        else
        {
            target.position = player.position;
            vectorBuffer = player.position;
            vectorBuffer.z = cam.position.z;
            camGoal = vectorBuffer;
            target.gameObject.SetActive(false);
        }
    }
    private void changeCamPos()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, camGoal, 0.05f);
    }
}
