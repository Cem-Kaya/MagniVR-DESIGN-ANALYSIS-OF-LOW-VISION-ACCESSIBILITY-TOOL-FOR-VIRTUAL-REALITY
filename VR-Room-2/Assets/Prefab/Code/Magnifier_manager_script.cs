using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnifier_manager_script : MonoBehaviour
{
	// Developer needs to assign XR_camera an controller from scene explorer
	[SerializeField] private Camera XR_camera;
	[SerializeField] private GameObject left_hand_controller;
	[SerializeField] private GameObject right_hand_controller;

	[SerializeField] private bool hand_state = false;
	
	[SerializeField] int display_state = 1 ;// 0 head, 1 right hand, 2 left hand 
	[SerializeField] int cam_state = 1 ;// 0 head, 1 right hand, 2 left hand 
	
	[SerializeField] bool canvas_exists =true;
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

	public Camera get_XR_camera()
	{
		return XR_camera;
	}

	public GameObject get_hand_controller()
	{
		if (hand_state == false){
			return right_hand_controller;
		}
		else{
			return left_hand_controller;
		}
	}  


	void FixedUpdate(){

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
			to_hand(display, right_hand_controller);


		}
		else if (display_state == 2)
		{
			//get child gameobject of this gameobject named "X"
			GameObject display = transform.Find("Magnifier_display").gameObject;

			//get child named " camera"of this object			
			to_hand(display, left_hand_controller);

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
			to_hand(cam, right_hand_controller);


		}
		else if (cam_state == 2)
		{
			//get child gameobject of this gameobject named "X"
			GameObject cam = transform.Find("Magnifier_cam").gameObject;

			//get child named " camera"of this object			
			to_hand(cam, left_hand_controller);

		}
	}

	void to_hand(GameObject obj, GameObject hand_controller )
	{
	
		Quaternion hand_rot = hand_controller.transform.rotation;
		Vector3 hand_up = hand_controller.transform.up;
		Vector3 hand_pos = hand_controller.transform.position;
		//multipyle camera pos with rotation 
		//Debug.Log("cam pos: " + camera_pos);



		//Debug.Log("cam forward: " + camera_forward);
		//Debug.Log("cam rot: " + camera_rot);
		obj.transform.position = hand_pos + hand_up * 0.2f;
		obj.transform.rotation = hand_rot;
	}

	void to_camera(GameObject obj, Camera XR_camera)
	{
		Quaternion camera_rot = XR_camera.transform.rotation;
		Vector3 camera_forward = XR_camera.transform.forward;
		Vector3 camera_pos = XR_camera.transform.position;
		//multipyle camera pos with rotation 
		//Debug.Log("cam pos: " + camera_pos);

		obj.transform.position = camera_pos + camera_forward * 1f;
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
		//delete the gameobject this script is connected to
		Destroy(canvas);
		canvas_exists = false;

    }
}
