using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour {

    public OVRInput.Controller controller;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)) {
            Quaternion controllerRotation = new Quaternion();
            controllerRotation = OVRInput.GetLocalControllerRotation(controller);
            Vector3 speedVector = new Vector3(speed, speed, speed);
            speedVector = controllerRotation * speedVector;
            transform.Translate(speedVector * Time.deltaTime, Space.World);
            //Debug.Log(speedVector);
        }

    }
}
