using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class Head_tracker : MonoBehaviour
{
	// Start is called before the first frame update
	// User needs to initialize XR Rig gameobject from scene explorer
	[SerializeField] GameObject XRRig_object;
	XROrigin XROrigin_script;
	Camera XR_camera;


	private void get_XROrigin_script()
	{
		XROrigin_script = XRRig_object.GetComponent<XROrigin>();
	}


	void Start()
	{
		get_XROrigin_script();
	}

	public InputDevice hmd;
	private void FixedUpdate()
	{


		if(hmd!=null){
			Vector3 device_pos;
			Vector3 eye_pos;
			Quaternion device_rot;
			Quaternion eye_rot;

			Debug.Log("device pos: " + device_pos);			
			Debug.Log("eye pos: " + eye_pos);
			gameObject.transform.position = device_pos;
			gameObject.transform.rotation = device_rot;
		} 

	}


	// Update is called once per frame
	void Update()
	{
		
	}
}
