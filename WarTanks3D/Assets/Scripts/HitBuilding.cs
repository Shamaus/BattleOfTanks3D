using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBuilding : MonoBehaviour
{
    public GameObject building;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "BulletEnemy")
        {
            Instantiate(building, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
