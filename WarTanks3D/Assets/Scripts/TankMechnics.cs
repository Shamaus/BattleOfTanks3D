using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankMechnics : MonoBehaviour
{
    // Основные параметры
    public Transform shotPoint;

    // Время для перезарядки
    private float nextTime = 0.0f;
    private float timeRate = 2f;

    // Ссылки на компоненты
    public GameObject bullet;
    public GameObject explosions;

    public void Shot()
    {
        if ((Time.time > nextTime) && gameObject.activeSelf)
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            nextTime = Time.time + timeRate;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "BulletEnemy")
        {
            if (gameObject.tag == "Enemy" && other.gameObject.tag == "Bullet")
            {
                gameObject.GetComponentInParent<UI_Controller>().DestroyEnemy();
                Explode(other.gameObject);
            }
            if (gameObject.tag == "Player" && other.gameObject.tag == "BulletEnemy")
            {
                gameObject.GetComponentInParent<UI_Controller>().LoseLevel();
                Explode(other.gameObject);
            }
        } 
    }

    private void Explode(GameObject other)
    {
        Instantiate(explosions, transform.position, transform.rotation);
        Destroy(other);
        Destroy(gameObject);
    }
}

