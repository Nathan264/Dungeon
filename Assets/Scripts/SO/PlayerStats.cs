using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Object/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public int exp;
    public int expToNextLvl;
    public int lvl;
    public float hp;
    public float sp;
    public float atk;
    public float spd;
    public float def;
}
