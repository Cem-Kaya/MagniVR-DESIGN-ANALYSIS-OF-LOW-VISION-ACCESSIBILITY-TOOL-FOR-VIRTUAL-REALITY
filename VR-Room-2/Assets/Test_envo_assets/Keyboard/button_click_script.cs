using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//import textmeshpro
using TMPro;

public class button_click_script : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject input_log;
    //textmeshpro object 
    private GameObject my_text;
    [SerializeField] GameObject room_manager;
    void Start()
    {
        //get the child Text (TMP) gameobject and equatei t to my_text
        //if my_text object is empty
        Transform parent = transform.parent.parent;
        input_log = parent.Find("inputs_log").gameObject;
        my_text = gameObject.transform.Find("input").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void update_log()
    {
        //Debug.Log("updating log");
        //get the text from the my_text object
        //add it to input_log's text
        input_log.GetComponent<TextMeshProUGUI>().text += my_text.GetComponent<TextMeshProUGUI>().text;
        //Debug.Log(input_log.GetComponent<TextMeshProUGUI>().text);
        if (input_log.GetComponent<TextMeshProUGUI>().text == "LETS MAKE VR MORE ACCESSIBLE")
            room_manager.GetComponent<Room_manager_script>().set_teleportation_active(true);
        {
            Debug.Log("signal the next room stuff");
        }
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
