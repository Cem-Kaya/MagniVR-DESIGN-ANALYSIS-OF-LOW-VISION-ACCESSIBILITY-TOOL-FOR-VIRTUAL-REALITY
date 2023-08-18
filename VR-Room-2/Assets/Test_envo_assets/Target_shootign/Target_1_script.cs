using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_1_script : MonoBehaviour
{
    private bool been_hit = false;
    private float speed = 1;
    // Start is called before the first frame update
    private Target_1_system_script t1_sys;
    void Start()
    {
        t1_sys= transform.parent.parent.gameObject.GetComponent<Target_1_system_script>();
        // multiply the speed by a random number inbetween 0.5 and 1.2
        speed *= UnityEngine.Random.Range(0.4f, 1.0f);

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
                transform.localPosition += new Vector3(0.1f, 0, 0)* speed;
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
                transform.localPosition -= new Vector3(0.1f, 0, 0)* speed;
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
            t1_sys.targetr_shoot();
            Destroy(gameObject);

        }
    }
}
