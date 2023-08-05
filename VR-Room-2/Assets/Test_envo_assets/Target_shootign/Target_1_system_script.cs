using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_1_system_script : MonoBehaviour
{
    // Start is called before the first frame update
    public int amount = 5;
    [SerializeField] GameObject room_manager;

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
            Debug.Log("ALL TARGETS HOT SHOT");
            room_manager.GetComponent<Room_manager_script>().set_teleportation_active(true);

        }
    }
}
