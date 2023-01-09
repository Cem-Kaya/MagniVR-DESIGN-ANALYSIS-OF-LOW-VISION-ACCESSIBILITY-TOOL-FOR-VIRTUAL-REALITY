using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import textmeshpro
using TMPro;

public class button_click_script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject input_log;
    //textmeshpro object 
    public GameObject my_text;
    void Start()
    {
        //get the child Text (TMP) gameobject and equatei t to my_text
        //if my_text object is empty
        
        my_text = gameObject.transform.Find("input").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void update_log()
    {
        //get the text from the my_text object
        //add it to input_log's text
        input_log.GetComponent<TextMeshProUGUI>().text += my_text.GetComponent<TextMeshProUGUI>().text;
    }
    
    public void update_log_backspace()
    {
        //delete the last character from the input_log's text
        //get all chars except for the las tchar of input_log
        //if length of input_log.text isn't 0
        if (input_log.GetComponent<TextMeshProUGUI>().text.Length != 0)
        {
            //get all chars except for the last char of input_log
            input_log.GetComponent<TextMeshProUGUI>().text = input_log.GetComponent<TextMeshProUGUI>().text.Substring(0, input_log.GetComponent<TextMeshProUGUI>().text.Length - 1);
        }

     
    }

    public void update_log_space()
    {
        //delete the last character from the input_log's text
        //get all chars except for the las tchar of input_log
        //if length of input_log.text isn't 0
        if (input_log.GetComponent<TextMeshProUGUI>().text.Length != 0)
        {
            //get all chars except for the last char of input_log
            input_log.GetComponent<TextMeshProUGUI>().text += " ";
        }


    }

}
