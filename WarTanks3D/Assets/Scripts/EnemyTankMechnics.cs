using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTankMechnics : MonoBehaviour
{
    // Основные параметры
    public float speedMove;
    public Transform shotPoint;

    // Параметры геймплейя
    private float gravityForce;
    private Vector3 vectorMove; // Напрвление движение персонажа

    // Ссылки на компоненты
    public CharacterController ch_controller;
    public GameObject bullet;

    void Start()
    {
        ch_controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        CharacterMove();
        GamingGravity();

        if (Input.GetKeyUp("e"))
        {
            shot();
        }
    }


    void CharacterMove()
    {
        // Движение персонажа по X Y
        vectorMove = Vector3.zero;
        vectorMove.x = Input.GetAxis("Horizontal") * speedMove;
        vectorMove.z = Input.GetAxis("Vertical") * speedMove;

        // Планый поворот при ходьбе
        if (Vector3.Angle(Vector3.forward, vectorMove) > 1f || Vector3.Angle(Vector3.forward, vectorMove) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, vectorMove, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        vectorMove.y = gravityForce;

        ch_controller.Move(vectorMove * Time.deltaTime);
    }

    void GamingGravity()
    {
        if (!ch_controller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
    }

    public void shot()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }

}

