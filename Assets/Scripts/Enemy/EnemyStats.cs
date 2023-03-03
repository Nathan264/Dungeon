using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private int lvl;
    [SerializeField] private float hp;
    [SerializeField] private float atk;
    [SerializeField] private float def;
    [SerializeField] private float spd;
    [SerializeField] private string enemyName;
    

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
}
