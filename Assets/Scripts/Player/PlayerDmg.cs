using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{
    [SerializeField] private PlayerStats pStats;
    [SerializeField] private Player player;
    [SerializeField] private Statusbar hpBar;

    [SerializeField] private float kbForce;
    [SerializeField] private float defMultiplier;

    private void OnEnable()
    {
        hpBar.UpdateBar(pStats.sp, pStats.maxSp);
    }

    public void TakeDamage(float atk, bool blocked, Vector3 enemyPos)
    {
        if (atk < pStats.def)
        {
            pStats.hp -= 1;
        }       
        else
        {
            float def = (pStats.def * defMultiplier) / 100;
            float dmg = atk - def;

            pStats.hp -= (dmg - pStats.def);
        }
        
        if (pStats.hp <= 0)
        {
            Die();
        }
        else
        {
            Vector3 kbDir = (transform.position - enemyPos).normalized;
            Knockback(kbDir);
        }
    }

    private void Die()
    {
        player.Anim.SetTrigger("Hit");
        player.Anim.SetBool("Death", true);
    }

    private void Knockback(Vector3 kbDir)
    {
        player.Anim.SetTrigger("Hit");
        player.Rig.AddForce(kbDir * kbForce, ForceMode.Impulse); 
    }
}
