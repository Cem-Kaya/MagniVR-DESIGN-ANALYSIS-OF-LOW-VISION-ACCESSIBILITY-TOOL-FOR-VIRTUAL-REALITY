using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TASK3_Bin_Behavior : MonoBehaviour
{
    //object_1 is baseball
    public (bool, string) object_1 = (false, "Baseball_Ball");
    public (bool, string) object_2 = (false, "Baseball_Ball (1)");
    
    public float total_time = 0;
    public bool task3_ended = false;
    public List<(bool, string)> objects_to_be_found = new List<(bool,string)>();
    // Start is called before the first frame update
    void Start()
    {
        //when adding a new object just add the object as seen above and add it here
        //add object_1 to objects_to_be_found
        objects_to_be_found.Add(object_1);
        objects_to_be_found.Add(object_2);
    }

    // Update is called once per frame
    void Update()
    {
        //update total time
        if (!task3_ended)
        {
            total_time += Time.deltaTime;
        }
        total_time += Time.deltaTime;
        //if all objects are found, end the task
        int found_obj_num = 0;
        foreach ((bool, string) obj in objects_to_be_found)
        {
            if (obj.Item1)
            {
                found_obj_num++;
            }
        }
        if (found_obj_num == objects_to_be_found.Count)
        {
            task3_ended = true;
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
}
