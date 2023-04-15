using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Ui_tracker : MonoBehaviour
{
	// Start is called before the first frame update
	private Camera XR_camera;
	private GameObject magnifier_manager;
	private Magnifier_manager_script mag_man_script;
	private int display_state ;
	private int cam_state ;

	public void on_zoom_slider_value_changed (float value)
	{
		mag_man_script.set_camera_fov(value);
		set_zoom_slider_ui();
	}
	public void on_display_size_slider_value_changed(float value)
	{
		mag_man_script.set_display_size(value);
		set_display_slider_ui();
		
	}

	private void set_zoom_slider_ui()
	{
		// have to scale to right range
		float current_fov = mag_man_script.get_camera_fov();
		
		GameObject slider_parent = transform.Find("FOV Slider").gameObject;
		GameObject handle_slide_area = slider_parent.transform.Find("Handle Slide Area").gameObject;
		GameObject obj_text = handle_slide_area.transform.Find("Percentage_Display").gameObject;
		TextMeshProUGUI text = obj_text.GetComponent<TextMeshProUGUI>();
		float min = slider_parent.GetComponent<Slider>().minValue;
		float max = slider_parent.GetComponent<Slider>().maxValue;

		slider_parent.GetComponent<Slider>().value = current_fov;
		current_fov = ((current_fov - min ) / (max - min)) * 100.0f;
		text.text = current_fov.ToString("F0") + "%";


	}

	private void set_display_slider_ui()
	{
		// have to scale to right range
		float current_display_size = mag_man_script.get_display_size();

		GameObject slider_parent = transform.Find("Display Size Slider").gameObject;
		GameObject handle_slide_area = slider_parent.transform.Find("Handle Slide Area").gameObject;
		GameObject obj_text = handle_slide_area.transform.Find("Percentage_Display").gameObject;
		TextMeshProUGUI text = obj_text.GetComponent<TextMeshProUGUI>();
		float min = slider_parent.GetComponent<Slider>().minValue;
		float max = slider_parent.GetComponent<Slider>().maxValue;

		slider_parent.GetComponent<Slider>().value = current_display_size;
		current_display_size = ((current_display_size - min) / (max - min)) * 100.0f;
		text.text = current_display_size.ToString("F0") + "%";
	}

	public void toggle_magnifier()
	{
		mag_man_script.toggle_magnifier();
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
	private void Awake()
	{
		magnifier_manager = transform.parent.gameObject;
		mag_man_script = magnifier_manager.GetComponent<Magnifier_manager_script>();
	}

	void Start()
	{
		//get the object's parent

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
	
	//
	private void OnEnable()
	{
		set_zoom_slider_ui();
		set_display_slider_ui();

	}

}

