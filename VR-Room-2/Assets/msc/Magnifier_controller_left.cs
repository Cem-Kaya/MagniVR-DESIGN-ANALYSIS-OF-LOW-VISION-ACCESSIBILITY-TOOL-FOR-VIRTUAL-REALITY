using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnifier_controller_left : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		//find mag_control and give this object to Magnifier on that object
		GameObject mag_control = GameObject.Find("Mag_control");
		//
		mag_control.GetComponent<make_magnifier_hide>().left_hand_magnifier = gameObject;
		//disable this object
		gameObject.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
