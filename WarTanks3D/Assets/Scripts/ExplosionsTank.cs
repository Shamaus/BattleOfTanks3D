using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsTank : MonoBehaviour
{
    public GameObject explosions;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey("space"))
        {
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((gameObject.tag == "Player" && other.gameObject.tag == "BulletEnemy") || (gameObject.tag == "Enemy" && other.gameObject.tag == "Bullet"))
        {
            Instantiate(explosions, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
