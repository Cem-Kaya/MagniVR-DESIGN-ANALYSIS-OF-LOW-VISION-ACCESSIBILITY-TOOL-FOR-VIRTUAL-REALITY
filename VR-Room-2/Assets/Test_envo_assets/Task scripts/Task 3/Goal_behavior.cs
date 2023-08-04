using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_behavior : MonoBehaviour
{
    // Start is called before the first frame update

    public (bool, string) object_1 = (false, "Book_A_Red");
    public (bool, string) object_2 = (false, "Clock_Digital");
    public (bool, string) object_3 = (false, "Hat_Witch_Blue");

    public (bool, string) object_4 = (false, "Book_A_Blue"); //this was notebook pink if for some reason it breaks use that
    public (bool, string) object_5 = (false, "Speaker_Boombox");
    public (bool, string) object_6 = (false, "Tennis_Ball_Green");
    public bool task3_ended = false;
    [SerializeField] GameObject room_manager;


    public int roomid;

    public List<(bool, string)> objects_to_be_found = new List<(bool, string)>();
    void Start()
    {
        if (roomid == 1)
        {
            objects_to_be_found.Add(object_1);
            objects_to_be_found.Add(object_2);
            objects_to_be_found.Add(object_3);
        }

        if (roomid == 2)
        {
            objects_to_be_found.Add(object_4);
            objects_to_be_found.Add(object_5);
            objects_to_be_found.Add(object_6);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        //if all objects are found, end the task
        int found_obj_num = 0;
        foreach ((bool, string) obj in objects_to_be_found)
        {
            if (obj.Item1)
            {
                //Debug.Log(obj.Item2 + " found");
                found_obj_num++;
            }
        }
        if (!task3_ended && found_obj_num == objects_to_be_found.Count)
        {
            //make task ended indication active
            task3_ended = true;
            Debug.Log("Task 2 ended");

            room_manager.GetComponent<Room_manager_script>().set_teleportation_active(true);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if the collided object's name is in objects_to_be_found, set the bool to true
        List<(bool, string)> to_be_changed = new List<(bool, string)>();
        foreach ((bool, string) obj in objects_to_be_found)
        {
            if (collision.gameObject.name == obj.Item2)
            {
                to_be_changed.Add((true, obj.Item2));
            }
            else
            {
                to_be_changed.Add(obj);
            }
        }

        objects_to_be_found = new List<(bool, string)>(to_be_changed);

    }
}
