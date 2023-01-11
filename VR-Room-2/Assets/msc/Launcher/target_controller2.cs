using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_controller2 : MonoBehaviour
{
	// Start is called before the first frame update
	bool been_hit = false;
	void Start()
	{
		been_hit = false;
	}
	Vector3 dir = new Vector3(0, 1, 0);

	// function to write to the text file
	public void write_to_file(string text)
	{
		System.IO.File.AppendAllText("./text/tmp.txt", text);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate()
	{
		if (transform.position.y > 3.795f)
		{
			dir = new Vector3(0, -1, 0);
		}
		else if (transform.position.y < 2.144)
		{
			dir = new Vector3(0, 1, 0);
		}
		transform.position += 0.005f * dir;

	}
	// on collusion 
	public void OnCollisionEnter(Collision collision)
	{
		//dir *= -1;
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
