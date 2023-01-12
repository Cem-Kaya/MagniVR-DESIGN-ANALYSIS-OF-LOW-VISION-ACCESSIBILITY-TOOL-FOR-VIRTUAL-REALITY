using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class target_controller3 : MonoBehaviour
{
	// Start is called before the first frame update
	bool been_hit = false;
	void Start()
	{

		System.Random tmp = new System.Random();
		tmp.Next(0, 5);
		rnd = tmp.Next(0, 3);		
		ang = tmp.Next(0, (int)(tmp.Next(0, 3) * tmp.Next(0, 3) * tmp.Next(0, 3) * tmp.Next(0, 3)));
		rnd2 = tmp.Next(0, 10);
		been_hit = false;
	}
	float ang = 0 ;

	// function to write to the text file
	public void write_to_file(string text)
	{
		System.IO.File.AppendAllText("./text/tmp.txt", text);
	}

	// Update is called once per frame
	void Update()
	{

	}
	float rnd; 
	float rnd2;
	float rnd3;
	private void FixedUpdate()
	{ 
		ang += 0.01f * rnd2;
		transform.position +=  (0.005f +0.01f* rnd) * new Vector3(Mathf.Cos(ang), Mathf.Sin(ang), 0);
		ang = ang % (2 * Mathf.PI); // numeric stability 
		//Debug.Log(transform.position.y);

	}
	// on collusion 
	public void OnCollisionEnter(Collision collision)
	{
		//dir *= -1;
		//Debug.Log("name"+collision.gameObject.name);
		if (collision.gameObject.name == "Projectile_Dart(Clone)" && !been_hit)
		{
			been_hit = true;
			// get time 
			string time = System.DateTime.Now.ToString("HH:mm:ss.fff");
			write_to_file("hit3 on " + time + "\n");


			Destroy(gameObject);

		}
	}
}
