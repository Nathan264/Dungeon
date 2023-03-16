using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/Enemy")]
public class EnemyObject : ScriptableObject
{
    public RuntimeAnimatorController anim;
    public AttackArea atkArea;

    public string enemyName;
    public float moveSpd;
    public float hp;
    public float atk;
    public float def;
    public float spd;
}
