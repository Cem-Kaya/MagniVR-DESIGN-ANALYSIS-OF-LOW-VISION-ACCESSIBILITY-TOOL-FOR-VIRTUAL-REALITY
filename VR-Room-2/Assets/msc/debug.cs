using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when the ray of the vr controller hits something Debug.Log what it is
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    }



}
