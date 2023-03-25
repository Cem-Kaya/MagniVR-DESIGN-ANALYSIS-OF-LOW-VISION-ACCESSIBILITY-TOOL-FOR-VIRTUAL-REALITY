using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Head_tracker : MonoBehaviour
{
	// hello uwu woo wee its time to roll babyyy 
	// Start is called before the first frame update
	void Start()
	{
		
	}

	public InputDevice hmd;
	private void FixedUpdate()
	{

		var inputDevices = new List<InputDevice>();
		InputDevices.GetDevices(inputDevices);

		foreach (var device in inputDevices)
		{
			// Debug.Log(device.characteristics.ToString());
			if (device.characteristics.ToString() == "HeadMounted, TrackedDevice") {
				hmd  = device;
			}

		}
		if(hmd!=null){
			Vector3 device_pos;
			Vector3 eye_pos;
			Quaternion device_rot;
			Quaternion eye_rot;
			hmd.TryGetFeatureValue(CommonUsages.devicePosition, out device_pos);
			hmd.TryGetFeatureValue(CommonUsages.centerEyePosition, out  eye_pos);
			hmd.TryGetFeatureValue(CommonUsages.deviceRotation, out device_rot);
			hmd.TryGetFeatureValue(CommonUsages.centerEyeRotation, out eye_rot);


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
