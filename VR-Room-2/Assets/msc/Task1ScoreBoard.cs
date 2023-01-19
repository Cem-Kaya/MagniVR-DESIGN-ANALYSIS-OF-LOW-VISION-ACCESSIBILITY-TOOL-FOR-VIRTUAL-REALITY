using System.Collections;
using System.Collections.Generic;
using System.Threading;
//import testmeshproGUI to use the GUI
using TMPro;
using UnityEngine;

public class Task1ScoreBoard : MonoBehaviour
{
	// Start is called before the first frame update
	public float timer = 0.0f;
	public bool task_started = false;
	public bool task_ended = false;
	TextMeshProUGUI textMesh;


	void Start()
	{
		textMesh = GetComponent<TextMeshProUGUI>();

	}

	// Update is called once per frame
	void Update()
	{
		if (task_started && !task_ended)
		{
			timer += Time.deltaTime;
			//get textmeshpro component of the object this string is connected to
			textMesh.text = "Score: " + timer.ToString("F2");
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
		task_ended = false;
		timer = 0.0f;
	}

	public void write_to_file()
	{
		name = "test1-1";
		//put name inside the string itself
		string filePath = Application.persistentDataPath + name +".txt";
		string time = System.DateTime.Now.ToString("HH:mm:ss.fff");

		System.IO.File.AppendAllText(filePath, textMesh.text+"  "+ time);
	}
}
