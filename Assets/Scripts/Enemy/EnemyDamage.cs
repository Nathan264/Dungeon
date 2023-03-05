using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    [SerializeField] private int defMultiplier;

    public void TakeDamage(float atk)
    {
        float def;
        float dmg;


        def = (enemy.Def * defMultiplier) / 100;
        dmg = atk - def;

        if (dmg < 0)
        {
            dmg = 0;
        }

        enemy.Hp -= atk;

        if (enemy.Hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
