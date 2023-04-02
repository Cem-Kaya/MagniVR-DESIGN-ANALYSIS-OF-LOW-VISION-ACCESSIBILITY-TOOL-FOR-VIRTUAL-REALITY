using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_tracker : MonoBehaviour
{
	// Start is called before the first frame update
	private Camera XR_camera;

	
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		XR_camera = GetComponentInParent<Magnifier_manager_script>().get_XR_camera();
		if ( Vector3.Magnitude(XR_camera.transform.position - transform.position) >3.5f  )
		{
			transform.position = (XR_camera.transform.position*0.01f  + 0.99f*transform.position)  ;
		}

	}
}
