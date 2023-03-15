using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDef : MonoBehaviour
{   
    [SerializeField] private Player player;

    [SerializeField] private float kbForce;
    [SerializeField] private float parryTime;
    private bool canParry = true;
    private bool parrying = false;
    private bool blocking = false;

    public bool IsParrying
    {
        get { return parrying; }
    }

    public bool IsBlocking
    {
        get { return blocking; }
    }

    private void Update()
    {
        if (Controls.Instance.Crtls["Block"].IsPressed())
        {
            if (canParry)
            {
                Parry();
            }
            Blocking(true);
        }   

        if (Controls.Instance.Crtls["Block"].WasReleasedThisFrame())
        {
            canParry = true;
            Blocking(false);
        }
    }

    private void Blocking(bool blockState)
    {
        blocking = blockState;
        player.Anim.SetBool("Blocking", blockState);
    }

    private void Parry()
    {
        canParry = false;
        StartCoroutine(ParryTimer());
    }

    public void DefKnockback(Rigidbody enemyRig)
    {
        enemyRig.AddForce(player.Rig.velocity * kbForce, ForceMode.Impulse); 
    }

    private IEnumerator ParryTimer()
    {
        parrying = true;
        yield return new WaitForSeconds(parryTime);
        parrying = false;
    }
}
