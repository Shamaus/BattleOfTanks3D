using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsDamage : MonoBehaviour
{
    public GameObject building;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("123");
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("456");
            Instantiate(building, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
