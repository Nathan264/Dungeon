using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmg : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    [SerializeField] private float kbForce;
    [SerializeField] private int defMultiplier;

    public void TakeDamage(float atk, Vector3 playerPos)
    {
        if (atk < enemy.Def)
        {
            enemy.Hp -= 1;
        }       
        else
        {
            float def = (enemy.Def * defMultiplier) / 100;
            float dmg = atk - def;

            enemy.Hp -= atk;
        }
        
        if (enemy.Hp <= 0)
        {
            Die();
        }
        else
        {
            Vector3 kbDir = (transform.position - playerPos).normalized;
            Knockback(kbDir);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        enemy.Anim.SetTrigger("Hit");
        enemy.Anim.SetBool("Death", true);
    }

    private void Knockback(Vector3 kbDir)
    {
        enemy.Rig.AddForce(kbDir * kbForce, ForceMode.Impulse); 
        enemy.Anim.SetTrigger("Hit");

    }
}
