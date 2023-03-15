using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatsGrowCurv
{
    public float min;
    public float max;
}

public class PlayerLvl : MonoBehaviour
{
    [SerializeField] private PlayerStats pStats;
    
    [SerializeField] private float growFactor;
    [SerializeField] private StatsGrowCurv statsGrowCurvHp;
    [SerializeField] private StatsGrowCurv statsGrowCurvSp;
    [SerializeField] private StatsGrowCurv statsGrowCurvSpd;
    [SerializeField] private StatsGrowCurv statsGrowCurvAtk;
    [SerializeField] private StatsGrowCurv statsGrowCurvDef;

    // private void Start() 
    // {
    //     for (int i = 0; i < 100; i++)
    //     {
    //         LvlUp();
    //     }
    // }

    public void GainExp(int gainedExp)
    {
        int oldExp = pStats.exp;
        int newExp = pStats.exp += gainedExp;

        if (newExp == pStats.expToNextLvl) 
        {
            pStats.exp = 0;    
            LvlUp();
        }
        else if (newExp > pStats.expToNextLvl)
        {
            pStats.exp = newExp - oldExp;
            LvlUp();
        }

    }

    private void LvlUp()
    {
        StatusCalc(ref pStats.hp, Random.Range(statsGrowCurvHp.min, statsGrowCurvHp.max));        
        StatusCalc(ref pStats.sp, Random.Range(statsGrowCurvSp.min, statsGrowCurvSp.max));  
        StatusCalc(ref pStats.atk, Random.Range(statsGrowCurvAtk.min, statsGrowCurvAtk.max));        
        StatusCalc(ref pStats.spd, Random.Range(statsGrowCurvSpd.min, statsGrowCurvSpd.max));        
        StatusCalc(ref pStats.def, Random.Range(statsGrowCurvDef.min, statsGrowCurvDef.max));        
        
        pStats.lvl++;
        pStats.expToNextLvl += (pStats.expToNextLvl * 30) / 100;
    }

    private void StatusCalc(ref float statusRef, float growCurv)
    {
        float value = growFactor * Mathf.Pow(pStats.lvl, growCurv);
        statusRef += Mathf.CeilToInt(value);
    }
}
