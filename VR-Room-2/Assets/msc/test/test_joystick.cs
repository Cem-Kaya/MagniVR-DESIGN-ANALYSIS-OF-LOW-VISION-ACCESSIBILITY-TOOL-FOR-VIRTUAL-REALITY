using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class test_joystick : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		
	}
	public void joy_stick()
	{
		Debug.Log("joy_stick");
	}
	public void joy_stick2(float x)
	{
		Debug.Log("x: " + x);
	}
	// Update is called once per frame
	void Update()
	{
		var inputDevices = new List<UnityEngine.XR.InputDevice>();
		UnityEngine.XR.InputDevices.GetDevices(inputDevices);

		foreach (var device in inputDevices)
		{
			//Debug.Log(string.Format("Device found with name '{0}'", device.name));
			//only debug the right hand and left hand controller
			//characteristics should be held in hand
			Debug.Log(string.Format("Device found with name '{0}'", device.characteristics));
			//debug primary2daxis vector values
			Vector2 primary2DAxis;
			if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out primary2DAxis))
			{
				Debug.Log(string.Format("Primary 2D Axis: {0}", primary2DAxis));
			}
		}
	}
}
