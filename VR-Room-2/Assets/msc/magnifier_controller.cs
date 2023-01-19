using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnifier_controller : MonoBehaviour
{

 
	// Start is called before the first frame update
	void Start()
	{
		//find mag_control and give this object to Magnifier on that object
		GameObject mag_control = GameObject.Find("Mag_control");
		//
		mag_control.GetComponent<make_magnifier_hide>().right_hand_magnifier = transform.Find("Magnifier").gameObject;

	}

	//string filePath = Application.persistentDataPath + "/vrdata.txt";
	//System.IO.File.AppendAllText(filePath, text);
	//
	// Update is called once per frame
	void Update()
	{
		
	}
}
