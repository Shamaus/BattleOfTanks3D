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

    public Transform targetPoint;
    public Transform targetPoint2;
    public Transform targetPoint3;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        rotationSpeed = agent.angularSpeed;
        agentTransform = agent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget(targetPoint);
        //DrawView();
    }


    private bool IsInView(Transform target)
    {
        float realAngle = Vector3.Angle(enemyEye.forward, target.position - enemyEye.position);
        RaycastHit hit;
        if (Physics.Raycast(enemyEye.transform.position, target.position - enemyEye.position, out hit, viewDistance))
        {
            if (realAngle < viewAngle / 2f && Vector3.Distance(enemyEye.position, target.position) <= viewDistance && hit.transform == target.transform)
            {
                return true;
            }
        }
        return false;
    }

    private void MoveToTarget(Transform target)
    {
        float distanceToPlayer = 1000;
        float distanceToTargetPoint = 1000;
        if (targetPlayer != null) 
        {
            distanceToPlayer = Vector3.Distance(targetPlayer.transform.position, agent.transform.position);
        }
        if (targetBase != null)
        {
            if (Vector3.Distance(targetPoint2.transform.position, agent.transform.position) > Vector3.Distance(targetPoint3.transform.position, agent.transform.position))
            {
                distanceToTargetPoint = Vector3.Distance(targetPoint3.transform.position, agent.transform.position);
            }
            else
            {
                distanceToTargetPoint = Vector3.Distance(targetPoint2.transform.position, agent.transform.position);
            }
        }
        if ((targetBase != null) && IsInView(targetBase))
        {
            RotateToTarget(targetBase);
        }
        else if ((targetPlayer != null) && (IsInView(targetPlayer) || (distanceToPlayer <= detectionDistance)))
        {
            RotateToTarget(targetPlayer);
            //agent.SetDestination(targetPlayer.position);
        }
        else if ((targetBase != null) && ((IsInView(targetPoint2) || IsInView(targetPoint3)) || (distanceToTargetPoint <= detectionDistance)))
        {
            if (distanceToTargetPoint == Vector3.Distance(targetPoint2.transform.position, agent.transform.position))
            {
                RotateToTarget(targetPoint2);
                agent.SetDestination(targetPoint2.position);
            }
            else
            {
                RotateToTarget(targetPoint3);
                agent.SetDestination(targetPoint3.position);
            }

        }
        else if (targetBase != null) agent.SetDestination(target.position);
    }
    
    private void RotateToTarget(Transform target)
    {
        agent.SetDestination(gameObject.transform.position);
        Vector3 lookVector = target.position - agentTransform.position;
        lookVector.y = 0;
        gameObject.GetComponent<TankMechnics>().Shot();
        if (lookVector == Vector3.zero)
            return;
        agentTransform.rotation = Quaternion.RotateTowards(
            agentTransform.rotation, 
            Quaternion.LookRotation(lookVector,Vector3.up), 
            rotationSpeed * Time.deltaTime
            );
    }

    private void DrawView()
    {
        Vector3 left = enemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Vector3 right = enemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 2f, 0)) * (enemyEye.forward * viewDistance);
        Debug.DrawLine(enemyEye.position, left);
        Debug.DrawLine(enemyEye.position, right);
    }

}
