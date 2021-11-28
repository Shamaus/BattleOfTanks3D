using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsDamage : MonoBehaviour
{
    public GameObject building;
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "BulletEnemy")
        {
            if (gameObject.tag == "Headquarters" && enemy)
            {
                enemy.GetComponent<UI_Controller>().LoseLevel();
            }
            Instantiate(building, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
