using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SkillObject", menuName = "Scriptable Object/Skills")]
public class SkillObject : ScriptableObject
{
    public string skillName;
    public string skillType;
    public string description;
    public string target;
    public string targetStat;
    public int effectPercentage;
    public int duration;
}
