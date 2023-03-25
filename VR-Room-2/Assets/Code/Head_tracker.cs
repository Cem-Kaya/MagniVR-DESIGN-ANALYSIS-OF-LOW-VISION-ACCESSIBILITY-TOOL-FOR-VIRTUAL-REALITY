using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class Head_tracker : MonoBehaviour
{
	// Developer needs to assign XR_camera an controller from scene explorer
	[SerializeField] private Camera XR_camera;
	[SerializeField] private GameObject left_hand_controller;
	[SerializeField] private GameObject right_hand_controller;




	void Start()
	{
	
	}

	private void FixedUpdate()
	{

		Quaternion camera_rot = XR_camera.transform.rotation;
        Vector3 camera_forward = XR_camera.transform.forward;
        Vector3 camera_pos = XR_camera.transform.position;
        //multipyle camera pos with rotation 
		Debug.Log("cam pos: " + camera_pos);
		

		
		Debug.Log("cam forward: " + camera_forward);			
		Debug.Log("cam rot: " + camera_rot);
		gameObject.transform.position = camera_pos + camera_forward * 0.3f;
		gameObject.transform.rotation = camera_rot;

        


    }


	// Update is called once per frame
	void Update()
	{
		
	}
}
