using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_controller : MonoBehaviour
{
	//write corutine to destroy bullet after 2 seconds
	IEnumerator decay()
	{
		yield return new WaitForSeconds(7);
		Destroy(gameObject);
	}
	// Start is called before the first frame update
	void Start()
	{
		gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 3500);
		StartCoroutine(decay());
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
