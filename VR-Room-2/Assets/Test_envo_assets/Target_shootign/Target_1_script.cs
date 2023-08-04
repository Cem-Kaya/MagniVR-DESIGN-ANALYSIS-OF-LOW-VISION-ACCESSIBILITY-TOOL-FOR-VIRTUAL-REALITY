using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_1_script : MonoBehaviour
{
    bool been_hit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    bool movingRight = true;

    private void FixedUpdate() 
    { 
        //Debug.Log(transform.localPosition.x);

        if (movingRight)
        {
            if (transform.localPosition.x < 5.0f)
            {
                transform.localPosition += new Vector3(0.1f, 0, 0);
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            if (transform.localPosition.x > -5.0f)
            {
                transform.localPosition -= new Vector3(0.1f, 0, 0);
            }
            else
            {
                movingRight = true;
            }
        }
    }
    // on collusion 
    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("name"+collision.gameObject.name);
        if (collision.gameObject.name == "Projectile_Dart(Clone)" && !been_hit)
        {
            been_hit = true;
            // get time 

            Destroy(gameObject);

        }
    }
}
