using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Vector3 atkArea;
    [SerializeField] private LayerMask playerLayer;

    private float playerDetectArea;
    private float atkInterval;

    private void FixedUpdate()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        Collider[] player = Physics.OverlapSphere(transform.position, playerDetectArea, playerLayer);

        if (player != null)
        {
            StartCoroutine("AtkInterval");
        }
        else 
        {
            StopCoroutine("AtkInterval");
        }
    }

    private void Attack()
    {
        Collider[] player = Physics.OverlapBox(transform.position, atkArea, Quaternion.identity, playerLayer);

        if (player != null)
        {
            PlayerDef pDef = player[0].GetComponent<PlayerDef>();
            
            if (pDef.Parrying)
            {
                pDef.DefKnockback();
            }
            else 
            {
                PlayerDmg pDmg = GetComponent<PlayerDmg>();

                pDmg.TakeDamage(enemy.Atk, pDef.Blocking);
            }
        }
    }

    private IEnumerator AtkInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(atkInterval);

            Attack();
        }
    }
}
