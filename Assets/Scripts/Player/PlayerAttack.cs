using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerStats pStats;
    [SerializeField] private Player player;
    [SerializeField] private List<AnimationClip> atkAnims;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private Vector3 atkArea;
    [SerializeField] private Vector3 atkAreaOffset;

    [SerializeField] private bool isAttacking = false;

    public bool IsAttacking
    {
        get { return isAttacking; }
    }


    private void Update()
    {
        if (isAttacking)
        {
            return;
        }

        if (Controls.Instance.Crtls["LightAtk"].WasPressedThisFrame())
        {
            LightAttack();
        }
        else if (Controls.Instance.Crtls["StrongAtk"].WasPressedThisFrame())
        {
            StrongAttack();
        }
    }

    private void LightAttack()
    {
        float animDuration = atkAnims[0].length / 1.5f;

        AnimateAtk(1, animDuration);
        StartCoroutine(AttackDelay(animDuration / 2, 1f));
    }

    private void StrongAttack()
    {
        float animDuration = atkAnims[0].length;

        AnimateAtk(2, animDuration);
        StartCoroutine(AttackDelay(animDuration / 2, 1.5f));
    }

    private void PerformAtk(float dmgMultiplier)
    {
        Collider[] enemies = Physics.OverlapBox(transform.position - atkAreaOffset, atkArea, Quaternion.identity, enemyMask);

        float dmg = pStats.atk * dmgMultiplier;

        if (enemies.Length > 0)
        {
            foreach (Collider enemy in enemies)
            {
                enemy.GetComponent<EnemyDmg>().TakeDamage(dmg, transform.position);
            }
        }
    }

    private void AnimateAtk(int animCode, float animTime)
    {
        isAttacking = true;
        player.Anim.SetInteger("Attack", animCode);  

        StartCoroutine(WaitAnimataionEnds(animTime));
    }

    private IEnumerator AttackDelay(float delayTime, float dmgMultiplier)
    {
        yield return new WaitForSeconds(delayTime);

        PerformAtk(dmgMultiplier);
    }

    private IEnumerator WaitAnimataionEnds(float animTime)
    {
        yield return new WaitForSeconds(animTime);

        isAttacking = false;
        player.Anim.SetInteger("Attack", 0); 
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireCube(transform.position - atkAreaOffset, atkArea);    
    }
}
