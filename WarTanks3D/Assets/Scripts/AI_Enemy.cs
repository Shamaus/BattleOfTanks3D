using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{
    // Настройки поиска
    [Range(0, 360)] public float viewAngle;
    public float viewDistance;
    public float detectionDistance;
    public Transform enemyEye;
    public Transform targetPlayer;
    public Transform targetBase;

    private NavMeshAgent agent;
    private float rotationSpeed;
    private Transform agentTransform;


    EnemyTankMechnics EnemyTank;
    private float nextTime = 0.0f;
    private float timeRate = 2f;
    private Vector3 vectorMove;


    // Start is called before the first frame update
    void Start()
    {
        EnemyTank = FindObjectOfType<EnemyTankMechnics>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        rotationSpeed = agent.angularSpeed;
        agentTransform = agent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer)
        {
            float distanceToPlayer = Vector3.Distance(targetPlayer.transform.position, agent.transform.position);
            if ((distanceToPlayer <= detectionDistance) || IsInView())
            {
                MoveToTarget(targetPlayer);
                RotateToTarget(targetPlayer);
            }
        }
       if (targetBase)
        {
            MoveToTarget(targetBase);
        }
        
        drawView();
    }


    private bool IsInView()
    {
        float realAngle = Vector3.Angle(enemyEye.forward, targetPlayer.position - enemyEye.position);
        RaycastHit hit;
        if (Physics.Raycast(enemyEye.transform.position, targetPlayer.position - enemyEye.position, out hit, viewDistance))
        {
            Debug.Log("Вижу");
            if (realAngle < viewAngle / 2f && Vector3.Distance(enemyEye.position, targetPlayer.position) <= viewDistance && hit.transform == targetPlayer.transform)
            {
                Debug.Log("Вижу лучше");
                if (Time.time > nextTime)
                {
                    EnemyTank.shot();
                    nextTime = Time.time + timeRate;
                }
                return true;
            }
        }
        Debug.Log("Не Вижу");
        return false;
    }

    private void MoveToTarget(Transform target)
    {
        agent.SetDestination(target.position);
        agent.Equals
        //EnemyTank.ch_controller.Move((enemyEye.position - EnemyTank.transform.position) * Time.deltaTime);
    }
    
    private void RotateToTarget(Transform target)
    {
        Vector3 lookVector = target.position - agentTransform.position;
        lookVector.y = 0;
        if (lookVector == Vector3.zero) return;
        agentTransform.rotation = Quaternion.RotateTowards(
            agentTransform.rotation, 
            Quaternion.LookRotation(lookVector,Vector3.up), 
            rotationSpeed * Time.deltaTime
            );
    }
    private void drawView()
    {
        Vector3 left = enemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 right = enemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Debug.DrawLine(enemyEye.position, left);
        Debug.DrawLine(enemyEye.position, right);
    }

}
