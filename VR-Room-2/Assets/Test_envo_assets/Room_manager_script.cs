using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class Room_manager_script : MonoBehaviour
{

    public bool teleportation_active = false;
    public bool teleportation_state_inactive = true;
    AudioSource audio_source;
    [SerializeField] GameObject[] teleport_buttons;

    // Start is called before the first frame update

    private void Awake()
    {
        teleportation_state_inactive = true;
    }

    void Start()
    {
        //File_manager fm = File_manager.get_singelton();
        //fm.WriteToFile("test_string");

		audio_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(teleportation_active == true && teleportation_state_inactive == false) { 
            //make teleport buttons active
            foreach (GameObject teleport_button in teleport_buttons)
            {
                teleport_button.SetActive(true);
            }
            teleportation_state_inactive = true;
            audio_source.Play();
        }
        else if(teleportation_active == false && teleportation_state_inactive == true)
        {
            //make teleport buttons inactive
            teleportation_state_inactive = false;
            foreach (GameObject teleport_button in teleport_buttons)
            {
                teleport_button.SetActive(false);
            }
        }
    }

    public void set_teleportation_active(bool teleportation_active)
    {
        this.teleportation_active = teleportation_active;
    }



    public bool get_teleportation_active()
    {
        return teleportation_active;
    }


}
