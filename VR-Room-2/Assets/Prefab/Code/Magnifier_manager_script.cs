using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR;

public class Magnifier_manager_script : MonoBehaviour
{
	// Developer needs to assign XR_camera an controller from scene explorer
	[SerializeField] private Camera XR_camera;
	[SerializeField] private GameObject left_hand_controller;
	[SerializeField] private GameObject right_hand_controller;

	[SerializeField] private bool hand_state = false;
	[SerializeField] private bool magnifier_toggle = true;

	[SerializeField] int display_state = 1 ;// 0 head, 1 right hand, 2 left hand 
	[SerializeField] int cam_state = 1 ;// 0 head, 1 right hand, 2 left hand 
	
	[SerializeField] bool canvas_exists = true;


	[SerializeField] private InputDevice left_hand_device;
	[SerializeField] private InputDevice right_hand_device;

	private bool right_primary_button_touch = false;
	private bool right_secondary_button_touch = false;
	private bool right_joystick_pressed = false;

	private bool left_primary_button_touch = false;
	private bool left_secondary_button_touch = false;
	private bool left_primary_button_pressed = false;
	private bool left_secondary_button_pressed = false;
	private bool left_joystick_pressed = false;


	private Vector2 left_joystick_2DAxis;
	private Vector2 right_joystick_2DAxis;

	private bool menu_spawnable = true;
	private bool mag_toggleable = true;
	private bool can_zoom = true;

	public void toggle_magnifier()
	{
		if (magnifier_toggle)
		{
			magnifier_toggle = false;
			deactivate_magnifier();
		}
		else
		{
			magnifier_toggle = true;
			activate_magnifier();
			set_state_from_input_device();
		}
	}
	public void adjust_zoom()
	{
		GameObject can_mag = transform.Find("Canvas_magnifier").gameObject;
		GameObject fov_slider = can_mag.transform.Find("FOV Slider").gameObject;
		float max = fov_slider.GetComponent<Slider>().maxValue;
		float min = fov_slider.GetComponent<Slider>().minValue;
		const float adj_size = 2.5f;
		if (right_primary_button_touch && right_secondary_button_touch && left_joystick_pressed) { 
			//if user is pointing upwards with left joystick 2d axis
			if (left_joystick_2DAxis.y >= 0.5f)
			{
				//Debug.Log("zoom in");
				if ((get_camera_fov() - adj_size ) >= min)
				{
					set_camera_fov(get_camera_fov() - adj_size);
				}
			}
			else if(left_joystick_2DAxis.y <= -0.5f)
			{
				//Debug.Log("zoom out");
				if ((get_camera_fov() + adj_size) <= max)
				{
					set_camera_fov(get_camera_fov() + adj_size);
				}
			}

		}
	}


	public void deactivate_magnifier()
	{
		//get parent of the current gameobject
		GameObject mag_display = transform.Find("Magnifier_display").gameObject;
		GameObject mag_cam = transform.Find("Magnifier_cam").gameObject;
		mag_display.SetActive(false);
		mag_cam.SetActive(false);		
	}

	public void activate_magnifier()
	{
		//get parent of the current gameobject
		GameObject mag_display =transform.Find("Magnifier_display").gameObject;
		GameObject mag_cam = transform.Find("Magnifier_cam").gameObject;
		mag_display.SetActive(true);
		mag_cam.SetActive(true);


	}
	

	public int get_display_state(){
		return display_state;
	}
	public void set_display_state(int state){
		display_state = state;
	}

	public int get_cam_state(){
		return cam_state;
	}
	public void set_cam_state(int state){
		cam_state = state;
	}

	public void set_camera_fov(float fov){
		transform.Find("Magnifier_cam").gameObject.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView = fov;
	}
	public float get_camera_fov()
	{
		return transform.Find("Magnifier_cam").gameObject.transform.Find("Camera").gameObject.GetComponent<Camera>().fieldOfView;
	}


	public void set_display_size(float scale)
	{
		GameObject display = transform.Find("Magnifier_display").gameObject; 
		display.transform.localScale = new Vector3(scale/15.0f, scale / 15.0f , 1);
	}
	public float get_display_size()
	{
		GameObject display = transform.Find("Magnifier_display").gameObject;
		return display.transform.localScale.x * 15.0f ;
	}

	public Camera get_XR_camera()
	{
		return XR_camera;
	}

	

	private void get_state_from_input_device()
	{
		List<InputDevice> input_devices = new List<InputDevice>();
		InputDevices.GetDevices(input_devices);

		foreach (var device in input_devices)
		{
			//only debug the right hand and left hand controller
			//characteristics should be held in hand
			//Debug.Log(string.Format("Device found with name '{0}'", device.characteristics, "role str:", device.role.ToString()));

			
			// get left hend 
			//Debug.Log(device.characteristics.ToString());
			if (device.characteristics.ToString() == "HeldInHand, TrackedDevice, Controller, Left")
			{
				left_hand_device = device;
				//Debug.Log("left hand controller found");
			}
			if (device.characteristics.ToString() == "HeldInHand, TrackedDevice, Controller, Right")
			{
				right_hand_device = device;
				//Debug.Log("right hand controller found");
			}


		}
		/////////////////////////////////////////////
		

		if (right_hand_device.TryGetFeatureValue(CommonUsages.primary2DAxis, out right_joystick_2DAxis))
		{
			//Debug.Log(string.Format("Primary 2D Axis for right: {0}", tmp_r));
		}

		if (right_hand_device.TryGetFeatureValue(CommonUsages.primaryTouch, out right_primary_button_touch))
		{
			//Debug.Log(string.Format("right_primary_button_touch: {0}", right_primary_button_touch));
		}
		if (right_hand_device.TryGetFeatureValue(CommonUsages.secondaryTouch, out right_secondary_button_touch))
		{
			//Debug.Log(string.Format("right_primary_button_touch: {0}", right_primary_button_touch));
		}


		if (left_hand_device.TryGetFeatureValue(CommonUsages.primary2DAxis, out left_joystick_2DAxis))
		{
			//Debug.Log(string.Format("Primary 2D Axis for left: {0}", tmp_l));
		}
		if (left_hand_device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out left_joystick_pressed))
		{
		}
		if (left_hand_device.TryGetFeatureValue(CommonUsages.primaryTouch, out left_primary_button_touch))
		{
			//Debug.Log(string.Format("right_primary_button_touch: {0}", right_primary_button_touch));
		}
		if (left_hand_device.TryGetFeatureValue(CommonUsages.secondaryTouch, out left_secondary_button_touch))
		{
			//Debug.Log(string.Format("right_primary_button_touch: {0}", right_primary_button_touch));
		}
		if (left_hand_device.TryGetFeatureValue(CommonUsages.primaryButton, out left_primary_button_pressed))
		{
			//Debug.Log(string.Format("right_primary_button_touch: {0}", right_primary_button_touch));
		}
		if (left_hand_device.TryGetFeatureValue(CommonUsages.secondaryButton, out left_secondary_button_pressed))
		{
			//Debug.Log(string.Format("right_primary_button_touch: {0}", right_primary_button_touch));
		}






	}

	IEnumerator ensure_2_second_press()
	{
		bool never_lifted = true; 
		for(int i =0; i < 100; i++)
		{
			if (! ( right_primary_button_touch  && right_secondary_button_touch && left_primary_button_touch && left_secondary_button_touch))
			{
				never_lifted = false;
				menu_spawnable = true;
				break;
			}
			yield return new WaitForSeconds(0.02f);

		}
		if (never_lifted)
		{
			enable_menu();
			menu_spawnable = true;
		}
		
	}


	IEnumerator ensure_1_second_press()
	{	 		
		yield return new WaitForSeconds(1);
		mag_toggleable = true;
		
		
	}
	IEnumerator ensure_0_2_second_press()
	{
		yield return new WaitForSeconds(0.2f);
		can_zoom = true;
	}



	private void set_state_from_input_device()
	{
		if (menu_spawnable)
		{
			if (right_primary_button_touch && right_secondary_button_touch && left_primary_button_touch && left_secondary_button_touch)
			{
				menu_spawnable = false;
				StartCoroutine(ensure_2_second_press());
				//Debug.Log("spawning menu from set_state_from_input_device");
			}
		}

		if (mag_toggleable){

			if (right_primary_button_touch && right_secondary_button_touch && left_primary_button_pressed && left_secondary_button_pressed)
			{
				mag_toggleable = false;
				StartCoroutine(ensure_1_second_press());
				toggle_magnifier();

			}

		}
		if(can_zoom)
		{
			can_zoom = false;
			StartCoroutine(ensure_0_2_second_press());
			adjust_zoom();
		}




	}


	void FixedUpdate(){
		get_state_from_input_device();
		set_state_from_input_device();
			
	}
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		update_display();
		update_cam();
	}
	
	void update_display()
	{
		if (display_state == 0)
		{
			//get child gameobject of this gameobject named "X"
			GameObject display = transform.Find("Magnifier_display").gameObject;

			//get child named " camera"of this object			
			to_camera(display, XR_camera);


		}
		else if (display_state == 1)
		{
			//get child gameobject of this gameobject named "X"
			GameObject display = transform.Find("Magnifier_display").gameObject;

			//get child named " camera"of this object			
			to_hand_display(display, right_hand_controller);


		}
		else if (display_state == 2)
		{
			//get child gameobject of this gameobject named "X"
			GameObject display = transform.Find("Magnifier_display").gameObject;

			//get child named " camera"of this object			
			to_hand_display(display, left_hand_controller);

		}
	}

	void update_cam()
	{
		if (cam_state == 0)
		{
			//get child gameobject of this gameobject named "X"
			GameObject cam = transform.Find("Magnifier_cam").gameObject;

			//get child named " camera"of this object			
			to_camera(cam, XR_camera);


		}
		else if (cam_state == 1)
		{
			//get child gameobject of this gameobject named "X"
			GameObject cam = transform.Find("Magnifier_cam").gameObject;

			//get child named " camera"of this object			
			to_hand_cam(cam, right_hand_controller);


		}
		else if (cam_state == 2)
		{
			//get child gameobject of this gameobject named "X"
			GameObject cam = transform.Find("Magnifier_cam").gameObject;

			//get child named " camera"of this object			
			to_hand_cam(cam, left_hand_controller);

		}
	}

	
	void to_hand_display(GameObject obj, GameObject hand_controller )
	{
	
		Quaternion hand_rot = hand_controller.transform.rotation;
		Vector3 hand_up = hand_controller.transform.up;
		Vector3 hand_forward = hand_controller.transform.forward;
		Vector3 hand_pos = hand_controller.transform.position;
		//multipyle camera pos with rotation 
		//Debug.Log("cam pos: " + camera_pos);



		//Debug.Log("cam forward: " + camera_forward);
		//Debug.Log("cam rot: " + camera_rot);
		// Add 45 degrees rotation in the x-axis relative to the hand's rotation
		Quaternion x_axis_rotation = Quaternion.Euler(45, 0, 0);
		Quaternion final_rotation = hand_rot * x_axis_rotation;


		obj.transform.position = hand_pos + hand_up * 0.2f - hand_forward *0.1f;
		obj.transform.rotation = final_rotation;
	}
	void to_hand_cam(GameObject obj, GameObject hand_controller)
	{

		Quaternion hand_rot = hand_controller.transform.rotation;
		Vector3 hand_up = hand_controller.transform.up;
		Vector3 hand_forward = hand_controller.transform.forward;
		Vector3 hand_pos = hand_controller.transform.position;
		//multipyle camera pos with rotation 
		//Debug.Log("cam pos: " + camera_pos);



		//Debug.Log("cam forward: " + camera_forward);
		//Debug.Log("cam rot: " + camera_rot);
		// Add 45 degrees rotation in the x-axis relative to the hand's rotation
		

		obj.transform.position = hand_pos + hand_up * 0.2f - hand_forward * 0.1f;
		obj.transform.rotation = hand_rot;
	}

	void to_camera(GameObject obj, Camera XR_camera)
	{
		Quaternion camera_rot = XR_camera.transform.rotation;
		Vector3 camera_forward = XR_camera.transform.forward;
		Vector3 camera_pos = XR_camera.transform.position;
		//multipyle camera pos with rotation 
		//Debug.Log("cam pos: " + camera_pos);

		obj.transform.position = camera_pos + camera_forward * 0.5f;
		obj.transform.rotation = camera_rot;
	}
	public void on_click_update_display_state()
	{
		display_state++ ;
		display_state%= 3 ;
	}

	public void on_click_exit_ui()
	{
		GameObject canvas = transform.Find("Canvas_magnifier").gameObject;
		canvas.SetActive(false);
		canvas_exists = false;

	}

	public void enable_menu()
	{
		GameObject canvas = transform.Find("Canvas_magnifier").gameObject;
		canvas.SetActive(true);
		canvas_exists = true;

		// Calculate the new position for the menu
		Vector3 newPosition = XR_camera.transform.position + XR_camera.transform.forward * 2.0f;

		// Set the new position and rotation of the menu
		canvas.transform.position = newPosition;
		canvas.transform.rotation = XR_camera.transform.rotation;

		//rotate canvas 180 degrees in x axis
		canvas.transform.Rotate(0, 180, 0); 

		// Set the menu to be perpendicular to the parent
		canvas.transform.forward = XR_camera.transform.forward;

	}
}
