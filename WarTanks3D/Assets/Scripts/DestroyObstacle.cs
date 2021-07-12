using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    public GameObject obstacleMain;
    public GameObject obstacleSec;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tank")
        {
            if (obstacleMain) Instantiate(obstacleMain, transform.position, transform.rotation);
            if (obstacleSec) Instantiate(obstacleSec, transform.position, obstacleSec.transform.rotation);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            if (obstacleMain) Instantiate(obstacleMain, transform.position, transform.rotation);
            if (obstacleSec) Instantiate(obstacleSec, transform.position, obstacleSec.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
