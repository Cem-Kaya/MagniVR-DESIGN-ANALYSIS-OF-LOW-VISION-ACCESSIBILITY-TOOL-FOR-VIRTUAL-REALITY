using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class target_controller1 : MonoBehaviour
{
	// Start is called before the first frame update
	bool been_hit = false;
	void Start()
	{
		try
		{
			if (!Directory.Exists("./text"))
			{
				Directory.CreateDirectory("./text");
			}

		}
		catch (IOException ex)
		{
			Console.WriteLine(ex.Message);
	    }



		been_hit = false;
	}
	
	// function to write to the text file
	public void write_to_file(string text)
	{
		System.IO.File.AppendAllText("./text/tmp.txt", text);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	// on collusion 
	public void OnCollisionEnter(Collision collision)
	{
		//Debug.Log("name"+collision.gameObject.name);
		if (collision.gameObject.name == "Projectile_Dart(Clone)" && !been_hit ) {
			been_hit = true;
			// get time 
			string time = System.DateTime.Now.ToString("HH:mm:ss.fff");
			write_to_file("hit1 on " + time + "\n");
			

			Destroy(gameObject);
			
		}
	}
}
