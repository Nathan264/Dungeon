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

        if (PlayerControls.Instance.Controls["LightAtk"].WasPressedThisFrame())
        {
            LightAttack();
        }
        else if (PlayerControls.Instance.Controls["StrongAtk"].WasPressedThisFrame())
        {
            StrongAttack();
        }
    }

    private void LightAttack()
    {
        AnimateAtk(1, atkAnims[0].length / 1.5f);
        PerformAtk(1);
    }

    private void StrongAttack()
    {
        AnimateAtk(2, atkAnims[1].length);
        PerformAtk(1.5f);

    }

    private void PerformAtk(float dmgMultiplier)
    {
        Collider[] enemies = Physics.OverlapBox(transform.position - atkAreaOffset, atkArea, Quaternion.identity, enemyMask);

        float dmg = pStats.atk * dmgMultiplier;

        if (enemies != null)
        {
            foreach (Collider enemy in enemies)
            {
                Debug.Log("ok");
                enemy.GetComponent<EnemyDamage>().TakeDamage(dmg);
            }
        }
    }

    private void AnimateAtk(int animCode, float animTime)
    {
        isAttacking = true;
        player.Anim.SetInteger("Attack", animCode);  

        StartCoroutine(WaitAnimataionEnds(animTime));
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
