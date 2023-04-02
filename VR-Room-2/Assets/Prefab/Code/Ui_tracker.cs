using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_tracker : MonoBehaviour
{
	// Start is called before the first frame update
	private Camera XR_camera;
	private GameObject magnifier_manager;
	private Magnifier_manager_script mag_man_script;
	private int display_state ;
	private int cam_state ;

	public void onSliderValueChanged(float value)
	{
		mag_man_script.set_camera_fov(value);
		Debug.Log(value);
	}


	public void change_display_state(int x)
	{
		mag_man_script.set_display_state(x);
		get_states();
		current_display_state();
	}

	public void change_cam_state(int x)
	{
		mag_man_script.set_cam_state(x);
		get_states();
		current_cam_state();
	}
	void get_states(){
		display_state = mag_man_script.get_display_state();
		cam_state = mag_man_script.get_cam_state();
	}

	void current_display_state()
	{
		for (int i = 0; i < 3; i++) {

			GameObject imaget = transform.Find("Image").gameObject;
			GameObject display_locationt = imaget.transform.Find("Display Location").gameObject;
			GameObject display_location_statet = display_locationt.transform.Find((i == 0 ? "Head" : i == 1 ? "Right Hand" : "Left Hand")).gameObject;
			Button active_buttont = display_location_statet.GetComponent<Button>();

			var current_statet = active_buttont.colors;
			current_statet.normalColor = Color.white;
			active_buttont.colors = current_statet;

		}
		GameObject image = transform.Find("Image").gameObject;
		GameObject display_location = image.transform.Find("Display Location").gameObject;
		GameObject display_location_state = display_location.transform.Find((display_state == 0? "Head": display_state==1 ? "Right Hand": "Left Hand")).gameObject;
		Button active_button = display_location_state.GetComponent<Button>();

		var current_state = active_button.colors;
		current_state.normalColor = Color.green;
		active_button.colors = current_state;

	}


	void current_cam_state()
	{
		for (int i = 0; i < 3; i++)
		{

			GameObject imaget = transform.Find("Image").gameObject;
			GameObject display_locationt = imaget.transform.Find("Camera Location").gameObject;
			GameObject display_location_statet = display_locationt.transform.Find((i == 0 ? "Head" : i == 1 ? "Right Hand" : "Left Hand")).gameObject;
			Button active_buttont = display_location_statet.GetComponent<Button>();

			var current_statet = active_buttont.colors;
			current_statet.normalColor = Color.white;
			active_buttont.colors = current_statet;

		}
		
		GameObject image = transform.Find("Image").gameObject;
		GameObject display_location = image.transform.Find("Camera Location").gameObject;
		GameObject display_location_state = display_location.transform.Find((cam_state == 0 ? "Head" : cam_state == 1 ? "Right Hand" : "Left Hand")).gameObject;
		Button active_button = display_location_state.GetComponent<Button>();

		var current_state = active_button.colors;
		current_state.normalColor = Color.green;
		active_button.colors = current_state;

	}
	void Start()
	{
		//get the object's parent
		magnifier_manager = transform.parent.gameObject;
		mag_man_script = magnifier_manager.GetComponent<Magnifier_manager_script>();
		get_states();

		// 0 head, 1 right hand, 2 left hand 
		current_display_state();
		current_cam_state();
		

	}

	// Update is called once per frame
	void Update()
	{
		XR_camera = GetComponentInParent<Magnifier_manager_script>().get_XR_camera();
		if ( Vector3.Magnitude(XR_camera.transform.position - transform.position) >2.5f  )
		{
			transform.position = (XR_camera.transform.position*0.01f  + 0.99f*transform.position)  ;
		}

	}
}
