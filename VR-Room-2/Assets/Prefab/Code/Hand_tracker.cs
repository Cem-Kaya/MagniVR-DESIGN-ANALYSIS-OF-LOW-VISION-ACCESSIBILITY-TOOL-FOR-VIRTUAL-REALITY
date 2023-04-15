using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_tracker : MonoBehaviour
{
	// Start is called before the first frame update
	GameObject hand_controller;

	void Start()
	{
		
	}

	// Update is called once per frame


	void Update()
	{
	//	// get perants scipt 
	//	hand_controller = GetComponentInParent<Magnifier_manager_script>().get_hand_controller();

	//	Quaternion hand_rot = hand_controller.transform.rotation;
	//	Vector3 hand_up = hand_controller.transform.up;
	//	Vector3 hand_pos = hand_controller.transform.position;
	//	//multipyle camera pos with rotation 
	//	//Debug.Log("cam pos: " + camera_pos);



	//	//Debug.Log("cam forward: " + camera_forward);
	//	//Debug.Log("cam rot: " + camera_rot);
	//	gameObject.transform.position = hand_pos + hand_up * 0.2f;
	//	gameObject.transform.rotation = hand_rot;
	}
}
