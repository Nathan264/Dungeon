using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject targetMark; 
    private Collider[] enemies;
    private Vector2 moveInput;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float enemyDetectArea;
    private float targetInput;
    private int actualTarget = 0;
    private bool enemyDetected = false;
    
    private void Update()
    {
        moveInput = Controls.Instance.Crtls["Move"].ReadValue<Vector2>();

        if (Controls.Instance.Crtls["ChangeTarget"].WasPressedThisFrame() && enemies.Length > 1)
        {
            ChangeTarget();
        }

        if (enemyDetected)
        {
            AimAtEnemy();
        }
        else
        {
            Look();  
        }
    }

    private void FixedUpdate()
    {
        enemies = Physics.OverlapSphere(transform.position, enemyDetectArea, enemyLayer);

        if (enemies.Length > 0)
        {
            enemyDetected = true;
            targetMark.SetActive(true);
        }
        else
        {
            enemyDetected = false;
            targetMark.SetActive(false);
        }
    }

    private void ChangeTarget()
    {
        targetInput = Controls.Instance.Crtls["ChangeTarget"].ReadValue<float>();

        int temp = actualTarget + (int)targetInput;

        if (temp < 0)
        {
            actualTarget = enemies.Length - 1;
        }
        else if (temp == enemies.Length)
        {
            actualTarget = 0;
        }
        else 
        {
            actualTarget = temp;
        }
    }

    private void AimAtEnemy()
    {
        Quaternion lookDir = Quaternion.LookRotation(enemies[actualTarget].transform.position - transform.position);
        lookDir.z = 0;
        lookDir.x = 0;
        transform.rotation = lookDir;

        targetMark.transform.SetParent(enemies[actualTarget].transform);
        targetMark.transform.localPosition = new Vector3(0f, 1.5f, 0f);
    }

    private void Look()
    {
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), rotateSpeed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, enemyDetectArea);
    }
}
