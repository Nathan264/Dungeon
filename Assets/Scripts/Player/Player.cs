using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rig;

    public Animator Anim
    {
        get { return anim; }
        set { anim = value; }
    }
    public Rigidbody Rig
    {
        get { return rig; }
        set { rig = value; }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }
}
