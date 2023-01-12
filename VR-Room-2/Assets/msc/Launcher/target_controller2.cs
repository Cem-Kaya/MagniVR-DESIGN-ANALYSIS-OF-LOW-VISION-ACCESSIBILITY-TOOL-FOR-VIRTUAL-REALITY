using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class target_controller2 : MonoBehaviour
{
	// Start is called before the first frame update
	bool been_hit = false;
	void Start()
	{

		System.Random tmp = new System.Random();
		tmp.Next(0, 5);
		rnd = tmp.Next(0, 5);
		been_hit = false;
	}
	Vector3 dir = new Vector3(0, 1, 0);

	// function to write to the text file
	public void write_to_file(string text)
	{
		string filePath = Application.persistentDataPath + "/vrdata.txt";
		System.IO.File.AppendAllText(filePath, text);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	float rnd;

	private void FixedUpdate()
	{
		if (transform.position.y > 11.095f)
		{
			dir = new Vector3(0, -1, 0);
		}
		else if (transform.position.y < 9.52)
		{
			dir = new Vector3(0, 1, 0);
		}
		transform.position += 0.01f * dir * rnd ;
		//Debug.Log(transform.position.y);

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
			write_to_file("hit2 on " + time + "\n");
			

			Destroy(gameObject);
			
		}
	}
}
