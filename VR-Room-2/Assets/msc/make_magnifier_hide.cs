using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_magnifier_hide : MonoBehaviour
{

	public GameObject right_hand_magnifier;
    public GameObject left_hand_magnifier;
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
        //find gameobject named VR_Hand_Colorful_Left_My and give its Quad child to left_hand_magnifier
        left_hand_magnifier = GameObject.Find("VR_Hand_Colorful_Left_My").transform.Find("Quad").gameObject;
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
			else if(state == 2)
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
					
                    //right_hand_magnifier.SetActive(false);
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
