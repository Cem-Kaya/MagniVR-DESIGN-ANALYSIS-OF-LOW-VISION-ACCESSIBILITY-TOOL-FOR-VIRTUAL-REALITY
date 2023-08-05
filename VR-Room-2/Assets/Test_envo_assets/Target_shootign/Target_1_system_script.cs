using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_1_system_script : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void targetr_shoot()
    {
        amount--;
        if (amount <= 0)
        {
            Debug.Log("taget got shoot");
        }
    }
}
