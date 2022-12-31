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

}
