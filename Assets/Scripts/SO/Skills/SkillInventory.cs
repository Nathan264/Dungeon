using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SkillInventory", menuName = "Scriptable Object/SkillInventory")]
public class SkillInventory : ScriptableObject
{
    public List<SkillObject> skilList;
}
