using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Vector3[] destPoints;
    private Vector3 actualDest;
    private Vector3 dir;
    private Vector3 playerPos;

    [SerializeField] private float rotateSpd;
    [SerializeField] private float playerDetectArea;
    [SerializeField] private int minDistance; 
    private int actualDestIndex;
    private bool playerDetected;
    private bool isMoving;

    private void OnEnable() 
    {
        actualDest = destPoints[0];    
        actualDestIndex = 0;
    }

    private void Update()
    {
        if (playerDetected)
        {
            FollowPlayer();
            LookForward(playerPos);
        }
        else
        {
            FreeMove();
            LookForward(actualDest);
        }

    }

    private void FixedUpdate()
    {
        Collider[] player = Physics.OverlapSphere(transform.position, playerDetectArea, playerLayer);

        if (player.Length > 0)
        {
            playerDetected = true;
            playerPos = player[0].transform.position;
        }
        else
        {
            playerDetected = false;
        }
        
    }

    private void FreeMove()
    {
        if (destPoints.Length > 0)
        {
            enemy.Anim.SetInteger("Run", 1);

            Move(actualDest);

            if (Vector3.Distance(transform.position, actualDest) < 3)
            {
                ChangeDestination();
            }

            if (!isMoving)
            {
                isMoving = true;
            }
        }
        else
        {
            enemy.Anim.SetInteger("Run", 0);
            
            if (isMoving)
            {
                enemy.Rig.velocity = Vector3.zero;
                isMoving = false;
            }
        }
    }

    private void LookForward(Vector3 target)
    {
        Quaternion lookDir = Quaternion.LookRotation(target - transform.position);
            
        lookDir.x = 0;
        lookDir.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, lookDir, enemy.MoveSpd * Time.deltaTime);
    }

    private void FollowPlayer()
    {
        if (Vector3.Distance(transform.position, playerPos) > minDistance)
        {
            Move(playerPos);
            enemy.Anim.SetInteger("Run", 1);

            if (!isMoving)
            {
                isMoving = true;
            }
        }
        else
        {
            enemy.Anim.SetInteger("Run", 0);
            
            if (isMoving)
            {
                enemy.Rig.velocity = Vector3.zero;
                isMoving = false;
            }
        }
    }   

    private void Move(Vector3 target)
    {
        Vector3 dir = (target - transform.position ).normalized;

        enemy.Rig.velocity = dir * enemy.MoveSpd;
    }

    private void ChangeDestination()
    {
        if ((actualDestIndex + 1) == destPoints.Length)
        {
            actualDest = destPoints[0];
            actualDestIndex = 0;
        }
        else
        {
            actualDestIndex++;
            actualDest = destPoints[actualDestIndex];
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, playerDetectArea);    
    }
}
