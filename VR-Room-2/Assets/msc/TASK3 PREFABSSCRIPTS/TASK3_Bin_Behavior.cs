using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TASK3_Bin_Behavior : MonoBehaviour
{
    //object_1 is baseball
    public (bool, string) object_1 = (false, "Baseball_Ball");
    public (bool, string) object_2 = (false, "Book_B_Red");
    public (bool, string) object_3 = (false, "Container_Bottle_Blue");

    public GameObject game_finished_indication;


    public float total_time = 0;
    public bool task3_ended = false;
    public bool task3_started = false;
    public List<(bool, string)> objects_to_be_found = new List<(bool,string)>();
    // Start is called before the first frame update
    void Start()
    {
        //when adding a new object just add the object as seen above and add it here
        //add object_1 to objects_to_be_found
       
        objects_to_be_found.Add(object_1);
        objects_to_be_found.Add(object_2);
        objects_to_be_found.Add(object_3);
    }

    // Update is called once per frame
    void Update()
    {
        //update total time
        if (task3_started && !task3_ended)
        {
            total_time += Time.deltaTime;
        }
        //if all objects are found, end the task
        int found_obj_num = 0;
        foreach ((bool, string) obj in objects_to_be_found)
        {
            if (obj.Item1)
            {
                found_obj_num++;
            }
        }
        if (!task3_ended && found_obj_num == objects_to_be_found.Count)
        {
            //make task ended indication active
            game_finished_indication.SetActive(true);
            task3_ended = true;
            write_to_file();
        }
        
        
    }


    //on collusion with an object, debug yes
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

    public void Start_game()
    {
        task3_started = true;
    }

    //print to file
    public void write_to_file()
    {
        name = "test3-1";
        //put name inside the string itself
        System.IO.File.AppendAllText("./text/" + name + ".txt", total_time.ToString());
    }
}
