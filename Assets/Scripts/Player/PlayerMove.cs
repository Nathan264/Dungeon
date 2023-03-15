using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerAttack pAtk;
    [SerializeField] private PlayerDef pDef;
    private Vector2 input;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    private bool running;
    

    private void Update()
    {
        input = Controls.Instance.Crtls["Move"].ReadValue<Vector2>();

        if (Controls.Instance.Crtls["Move"].WasReleasedThisFrame())
        {
            player.Rig.velocity = Vector3.zero;     
        }

        if (Controls.Instance.Crtls["Run"].IsPressed())
        {
            running = true;
        }
        else
        {
            running = false;
        }
    }

    private void FixedUpdate()
    {
        if (pAtk.IsAttacking || pDef.IsBlocking)
        {
            player.Rig.velocity = Vector3.zero;     
            return;
        }

        Move();
    }

    private void Move()
    {
        if (Controls.Instance.Crtls["Move"].IsPressed())
        {
            if (!running)
            {
                player.Anim.SetInteger("Move", 1);
                runSpeed = 1f;
            }
            else
            {
                player.Anim.SetInteger("Move", 2);
                runSpeed = 1.5f;
            }

            input *= moveSpeed * runSpeed; 
            player.Rig.velocity = new Vector3(input.x, player.Rig.velocity.y, input.y);
        }
        else
        {
            player.Anim.SetInteger("Move", 0);
        }
    }
    
}
