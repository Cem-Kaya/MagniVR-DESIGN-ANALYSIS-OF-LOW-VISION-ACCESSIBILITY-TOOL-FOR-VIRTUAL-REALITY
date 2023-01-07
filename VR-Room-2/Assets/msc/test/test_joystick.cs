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
		
	}
}
