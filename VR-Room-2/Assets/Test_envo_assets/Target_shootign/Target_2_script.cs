using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_2_script : MonoBehaviour
{
    private bool been_hit = false;
    private float speed = 1;

    private float jumpHeight = 0.10f; // Controls the height of the jump
    private float jumpFrequency = 2.0f; // Controls how many jumps you want within the range
    private float startingX;

    // Start is called before the first frame update
    private Target_2_system_script t1_sys;
    void Start()
    {
        t1_sys= transform.parent.parent.gameObject.GetComponent<Target_2_system_script>();
        // multiply the speed by a random number inbetween 0.5 and 1.2
        speed *= UnityEngine.Random.Range(0.5f, 1.2f);

        startingX = transform.localPosition.x;

    }

    // Update is called once per frame
    bool movingRight = true;

    private void FixedUpdate()
    {
        if (movingRight)
        {
            if (transform.localPosition.x < 5.0f)
            {
                float jumpValue = Mathf.Sin((transform.localPosition.x - startingX) * jumpFrequency) * jumpHeight;
                transform.localPosition += new Vector3(0.1f * speed, jumpValue, 0);
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
                float jumpValue = Mathf.Sin((startingX - transform.localPosition.x) * jumpFrequency) * jumpHeight;
                transform.localPosition -= new Vector3(0.1f * speed, jumpValue, 0);
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
