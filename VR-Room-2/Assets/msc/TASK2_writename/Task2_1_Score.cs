using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Task2_1_Score : MonoBehaviour
{

    public float timer;
    public bool task_started = false;
    public bool task_ended = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (task_started && !task_ended)
        {
            timer += Time.deltaTime;
            //get textmeshpro component of the object this string is connected to
        }
    }
    public float return_time()
    {
        return timer;
    }


    public void end_game()
    {
        task_ended = true;
    }

    public void start_game()
    {
        task_started = true;
    }

    public void write_to_file()
    {
        name = "test2-1";
        //put name inside the string itself
        System.IO.File.AppendAllText("./text/" + name + ".txt", timer.ToString());
    }
}
