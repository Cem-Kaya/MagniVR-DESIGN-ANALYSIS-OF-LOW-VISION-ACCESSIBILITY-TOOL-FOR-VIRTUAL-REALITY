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
        
    }
}
