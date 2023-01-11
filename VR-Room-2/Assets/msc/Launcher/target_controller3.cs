using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_controller3 : MonoBehaviour
{
	// Start is called before the first frame update
	bool been_hit = false;
	void Start()
	{
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
			write_to_file("hit on " + time + "\n");
			

			Destroy(gameObject);
			
		}
	}
}
