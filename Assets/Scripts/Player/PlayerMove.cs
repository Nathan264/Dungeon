using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerAttack pAtk;
    private Vector2 input;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    private bool running;
    

    private void Update()
    {
        if (pAtk.IsAttacking)
        {
            player.Rig.velocity = Vector3.zero;
            return;
        }

        input = PlayerControls.Instance.Controls["Move"].ReadValue<Vector2>();

        if (PlayerControls.Instance.Controls["Run"].IsPressed())
        {
            running = true;
        }
        else
        {
            running = false;
        }

        Move();
    }

    private void Move()
    {
        if (input == Vector2.zero)
        {
            player.Anim.SetInteger("Move", 0);
            player.Rig.velocity = Vector3.zero;
        }
        else 
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
        }

        player.Rig.velocity = new Vector3(input.x, 0f, input.y) * moveSpeed * runSpeed;
    }

    

}
