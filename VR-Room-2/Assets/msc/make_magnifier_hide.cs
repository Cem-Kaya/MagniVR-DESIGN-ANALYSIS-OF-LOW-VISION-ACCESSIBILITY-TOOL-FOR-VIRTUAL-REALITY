using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class make_magnifier_hide : MonoBehaviour
{

	public GameObject right_hand_magnifier;
	public GameObject left_hand_magnifier;
	public GameObject seeing_vr_magnifier;
	public bool button1 = false;
	public bool button2 = false;
	public bool button3 = false;
	bool mag_state = true;
	//0 is our, 1 is SeeingVR, 2 lefthand 3 nothing
	public int state = 0;
	public InputDevice left_hand_controller;
	public InputDevice right_hand_controller;

	// Start is called before the first frame update
	void Start()
	{

		//find gameobject named VR_Hand_Colorful_Left_My and give its Quad child to left_hand_magnifier
		//left_hand_magnifier = GameObject.Find("VR_Hand_Colorful_Left_My").transform.Find("Quad").gameObject;
	}

	public void button1_true()
	{
		button1 = true;

	}
	public void button2_true()
	{
		button2 = true;

	}
	public void button3_true()
	{
		button3 = true;

	}

	public void button1_false()
	{
		button1 = false;
	}
	public void button2_false()
	{
		button2 = false;

	}

	public void button3_false()
	{
		button3 = false;

	}

	// Update is called once per frame
	void Update()
	{

	}
	void turn_off_mag_children(GameObject mag)
	{
		foreach (Transform child in mag.transform)
		{
			if (child.name != "zoom_camera")
			{
				child.gameObject.SetActive(false);
			}
		}
	}

	void turn_on_mag_children(GameObject mag)
	{
		foreach (Transform child in mag.transform)
		{
			if (child.name != "zoom_camera")
			{
				child.gameObject.SetActive(true);
			}
		}
	}

	bool pressable = true;

	//write coroutine function IENUMERATOR
	IEnumerator wait()
	{

		yield return new WaitForSeconds(1.5f);
		pressable = true;
	}
	IEnumerator wait2()
	{

		yield return new WaitForSeconds(0.1f);
		pressable = true;
	}


	private void FixedUpdate()
	{
		var inputDevices = new List<InputDevice>();
		InputDevices.GetDevices(inputDevices);

		foreach (var device in inputDevices)
		{
			//Debug.Log(string.Format("Device found with name '{0}'", device.name));
			//only debug the right hand and left hand controller
			//characteristics should be held in hand
			//Debug.Log(string.Format("Device found with name '{0}'", device.characteristics, "role str:", device.role.ToString()));
			//Debug.Log(device.role.ToString());
			//debug primary2daxis vector values
			Vector2 primary2DAxis;
			// get left hend 
			if (device.role.ToString() == "LeftHanded")
			{
				left_hand_controller = device;
				//Debug.Log("left hand controller found");
			}
			if (device.role.ToString() == "RightHanded")
			{
				right_hand_controller = device;
				//Debug.Log("right hand controller found");
			}


		}
		//device.role.ToString()
		/////////////////////////////////////////////
		///

		Vector2 tmp_r;
		Vector2 tmp_l;
		if (left_hand_controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out tmp_l))
		{
			//Debug.Log(string.Format("Primary 2D Axis for left: {0}", tmp_l));
		}
		if (right_hand_controller.TryGetFeatureValue(CommonUsages.primary2DAxis, out tmp_r))
		{
			//Debug.Log(string.Format("Primary 2D Axis for right: {0}", tmp_r));
		}

		if (button1 == false && button2 == true && pressable && (Mathf.Abs(tmp_l.y) >= 0.8)  )
		{
			pressable = false;
			StartCoroutine(wait2());
			//min = 2
			if (tmp_l.y >= 0.8)
			{
				if (state == 0 || state==2)
				{
					if (right_hand_magnifier.transform.Find("zoom_camera").gameObject.GetComponent<Camera>().fieldOfView <= 130 - 2)
					{
						//Debug.Log("state is "+state + "also fow is " + right_hand_magnifier.transform.Find("zoom_camera").gameObject.GetComponent<Camera>().fieldOfView);
						//seeing_vr_magnifier.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView += 2;
						right_hand_magnifier.transform.Find("zoom_camera").gameObject.GetComponent<Camera>().fieldOfView += 2;

					}
				}
				else if (state == 1)
				{
					if (seeing_vr_magnifier.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView <= 130 - 2)
					{
						seeing_vr_magnifier.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView += 2;
						//right_hand_magnifier.transform.Find("zoom_camera").gameObject.GetComponent<Camera>().fieldOfView += 2;

					}
				}
				//Debug.Log("Changed FOW");
			}
			else if (tmp_l.y <= -0.8)
			{
				if (state == 0 || state == 2)
				{
					if (right_hand_magnifier.transform.Find("zoom_camera").gameObject.GetComponent<Camera>().fieldOfView >= 2 + 2)
					{
						//seeing_vr_magnifier.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView -= 2;
						// samthing is wierd here
						//Debug.Log("zooming in seeing vr" + seeing_vr_magnifier.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView);
						right_hand_magnifier.transform.Find("zoom_camera").gameObject.GetComponent<Camera>().fieldOfView -= 2;
					}
				}

				else if (state == 1)
				{
					if (seeing_vr_magnifier.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView >= 2 + 2)
					{
						seeing_vr_magnifier.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView -= 2;
						// samthing is wierd here
						//Debug.Log("zooming in seeing vr" + seeing_vr_magnifier.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView);
						//right_hand_magnifier.transform.Find("zoom_camera").gameObject.GetComponent<Camera>().fieldOfView -= 2;
					}
				}
				
				//Debug.Log("Changed FOW");
			}

		}

		//debounce  	   
		if (button1 == true && button2 == true && pressable)
		{
			pressable = false;
			StartCoroutine(wait());
			if (state == 0)
			{
				if (mag_state == true)
				{
					//right_hand_magnifier.SetActive(false);
					//disable all children of right hand magnifier except for zoom_camera
					turn_off_mag_children(right_hand_magnifier);
					seeing_vr_magnifier.SetActive(false);
					left_hand_magnifier.SetActive(false);
					mag_state = false;
				}
				else
				{
					//right_hand_magnifier.SetActive(true);
					turn_on_mag_children(right_hand_magnifier);
					seeing_vr_magnifier.SetActive(false);
					left_hand_magnifier.SetActive(false);
					mag_state = true;

				}
			}
			else if (state == 1)
			{
				if (mag_state == true)
				{
					seeing_vr_magnifier.SetActive(false);
					left_hand_magnifier.SetActive(false);

					turn_off_mag_children(right_hand_magnifier);
					//right_hand_magnifier.SetActive(false);
					mag_state = false;
				}
				else
				{
					seeing_vr_magnifier.SetActive(true);
					left_hand_magnifier.SetActive(false);

					//right_hand_magnifier.SetActive(false);
					turn_off_mag_children(right_hand_magnifier);
					mag_state = true;

				}


				//start courotine

			}
			//left hand magnifier
			else if (state == 2)
			{

				if (mag_state == true)
				{
					seeing_vr_magnifier.SetActive(false);
					left_hand_magnifier.SetActive(false);

					turn_off_mag_children(right_hand_magnifier);
					//right_hand_magnifier.SetActive(false);
					mag_state = false;
				}
				else
				{
					seeing_vr_magnifier.SetActive(false);
					left_hand_magnifier.SetActive(true);
					//right_hand_magnifier.SetActive(true);
					turn_off_mag_children(right_hand_magnifier);
					mag_state = true;

				}
			}
			else if (state == 3)
			{
				seeing_vr_magnifier.SetActive(false);
				turn_off_mag_children(right_hand_magnifier);
				left_hand_magnifier.SetActive(false);

				mag_state = false;
			}




		}
	}

	public void state_change(int sta)
	{
		state = sta;
	}
}
