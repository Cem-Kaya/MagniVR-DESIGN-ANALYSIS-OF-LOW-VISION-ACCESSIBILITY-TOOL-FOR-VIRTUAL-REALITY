using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_magnifier_hide : MonoBehaviour
{

	public GameObject magnifier;
	public GameObject seeing_vr_magnifier;
	public bool button1 = false;
	public bool button2 = false;
	public bool button3 = false;
	bool mag_state = true;
	//0 is our, 1 is SeeingVR, 2 is nothing
	public int state = 0;

	// Start is called before the first frame update
	void Start()
	{

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
	bool pressable = true;

	//write coroutine function IENUMERATOR
	IEnumerator wait()
	{

		yield return new WaitForSeconds(1.5f);
		pressable = true;
	}
	private void FixedUpdate()
	{
		//debounce  	   
		if (button1 == true && button2 == true && pressable)
		{
			pressable = false;
			StartCoroutine(wait());
			if (state == 0)
			{
				if (mag_state == true)
				{
					magnifier.SetActive(false);
					mag_state = false;
				}
				else
				{
					magnifier.SetActive(true);
					mag_state = true;

				}
			}
			else if (state == 1)
			{
				if (mag_state == true)
				{
					seeing_vr_magnifier.SetActive(false);
					mag_state = false;
				}
				else
				{
					seeing_vr_magnifier.SetActive(true);
					mag_state = true;

				}







				//start courotine


			}





		}
	}

    public void state_change(int sta)
    {
        state = sta;
    }
}
