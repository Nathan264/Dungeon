using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLvl : MonoBehaviour
{
    [SerializeField] private PlayerStats pStats;
    
    [SerializeField] private float growFactor;
    [SerializeField] private float hpGrowCurv;
    [SerializeField] private float spGrowCurv;
    [SerializeField] private float[] statsGrowCurvInterval;

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
        StatusCalc(ref pStats.hp, hpGrowCurv);        
        StatusCalc(ref pStats.sp, spGrowCurv);  
        StatusCalc(ref pStats.atk, Random.Range(statsGrowCurvInterval[0], statsGrowCurvInterval[1]));        
        StatusCalc(ref pStats.spd, Random.Range(statsGrowCurvInterval[0], statsGrowCurvInterval[1]));        
        StatusCalc(ref pStats.def, Random.Range(statsGrowCurvInterval[0], statsGrowCurvInterval[1]));        
        
        pStats.lvl++;
        pStats.expToNextLvl += (pStats.expToNextLvl * 30) / 100;
    }

    private void StatusCalc(ref float statusRef, float growCurv)
    {
        float value = growFactor * Mathf.Pow(pStats.lvl, growCurv);
        statusRef += Mathf.CeilToInt(value);
    }
}
