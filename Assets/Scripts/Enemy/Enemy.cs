using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyObject enemyObj;
    [SerializeField] private AttackArea atkArea;
    private Rigidbody rig;
    private Animator anim;

    [SerializeField] private float moveSpd;
    private int lvl;
    private float hp;
    private float atk;
    private float def;
    private float spd;
    private string enemyName;
    

    public AttackArea AtkArea
    {
        get { return atkArea; } 
        set { atkArea = value; }
    }

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

    public float MoveSpd
    {
        get { return moveSpd; }
        set { moveSpd = value; }
    }
    
    public string EnemyName
    {
        get { return enemyName; }
        set { enemyName = value; }
    }

    private void OnEnable()
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        atkArea = enemyObj.atkArea;
        moveSpd = enemyObj.moveSpd;
        hp = enemyObj.hp;
        atk = enemyObj.atk;
        def = enemyObj.def;
        spd = enemyObj.spd;
        enemyName = enemyObj.enemyName;
    }
}
