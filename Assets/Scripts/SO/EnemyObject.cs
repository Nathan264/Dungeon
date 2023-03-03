using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/Enemy")]
public class EnemyObject : ScriptableObject
{
    public string enemyName;
    public float hp;
    public float atk;
    public float def;
    public float spd;

    public RuntimeAnimatorController anim;
}
