using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDef : MonoBehaviour
{   
    [SerializeField] private Player player;

    private float parryTime;
    private bool canParry;
    private bool parrying = false;
    private bool blocking = false;

    public bool Parrying
    {
        get { return parrying; }
    }

    public bool Blocking
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
            Block();
        }   

        if (Controls.Instance.Crtls["Block"].WasReleasedThisFrame())
        {
            canParry = true;
            blocking = false;
        }
    }

    private void Block()
    {
        blocking = true;
        player.Anim.SetTrigger("Defend");
    }

    private void Parry()
    {
        canParry = false;
        StartCoroutine(ParryTimer());
    }

    public void DefKnockback()
    {
        
    }

    private IEnumerator ParryTimer()
    {
        parrying = true;
        yield return new WaitForSeconds(parryTime);
        parrying = false;
    }

}
