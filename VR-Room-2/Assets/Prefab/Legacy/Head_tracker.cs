using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class Head_tracker : MonoBehaviour
{


	private Camera XR_camera;

	void Start()
	{
	
	}

	private void FixedUpdate()
	{


		


	}


	// Update is called once per frame
	void Update()
	{
		// get perants scipt 
		XR_camera = GetComponentInParent<Magnifier_manager_script>().get_XR_camera();

		Quaternion camera_rot = XR_camera.transform.rotation;
		Vector3 camera_forward = XR_camera.transform.forward;
		Vector3 camera_pos = XR_camera.transform.position;
		//multipyle camera pos with rotation 
		//Debug.Log("cam pos: " + camera_pos);



		//Debug.Log("cam forward: " + camera_forward);
		//Debug.Log("cam rot: " + camera_rot);
		gameObject.transform.position = camera_pos + camera_forward * 1f;
		gameObject.transform.rotation = camera_rot;

	}
}
