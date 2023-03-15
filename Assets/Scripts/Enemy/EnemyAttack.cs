using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Vector3 atkArea;
    [SerializeField] private Vector3 atkAreaOffset;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float playerDetectArea;
    [SerializeField] private float atkInterval;
    private bool canAtk = true;

    private void FixedUpdate()
    {
        if (canAtk)
        {
            DetectPlayer();
        }
    }

    private void DetectPlayer()
    {
        Collider[] player = Physics.OverlapSphere(transform.position, playerDetectArea, playerLayer);

        if (player.Length > 0)
        {
            StartCoroutine(AtkInterval());
            Attack();
            enemy.Anim.SetTrigger("Attack");
        }
    }

    private void Attack()
    {
        Collider[] player = Physics.OverlapBox(transform.position - atkAreaOffset, atkArea, Quaternion.identity, playerLayer);


        if (player.Length > 0)
        {
            PlayerDef pDef = player[0].GetComponent<PlayerDef>();

            if (pDef.IsParrying)
            {
                pDef.DefKnockback(enemy.Rig);
            }
            else 
            {
                PlayerDmg pDmg = player[0].GetComponent<PlayerDmg>();

                pDmg.TakeDamage(enemy.Atk, pDef.IsBlocking, transform.position);
            }
        }
    }

    private IEnumerator AtkInterval()
    {
        canAtk = false;
        
        yield return new WaitForSeconds(atkInterval);

        canAtk = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - atkAreaOffset, atkArea);
    }
}
