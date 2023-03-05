using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rig;
    private Animator anim;

    [SerializeField] private int lvl;
    [SerializeField] private float hp;
    [SerializeField] private float atk;
    [SerializeField] private float def;
    [SerializeField] private float spd;
    [SerializeField] private string enemyName;
    

    public Rigidbody Rig
    {
        get { return rig; }
        set { rig = value; }
    }

    public Animator Anim
    {
        get { return anim; }
        set { anim = value; }
    }

    public int Lvl 
    {
        get { return lvl; }
        set { lvl = value; }
    }

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float Atk
    {
        get { return atk; }
        set { atk = value; }
    }

    public float Def
    {
        get { return def; }
        set { def = value; }
    }

    public float Spd
    {
        get { return spd; }
        set { spd = value; }
    }
    
    public string EnemyName
    {
        get { return enemyName; }
        set { enemyName = value; }
    }

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
}
