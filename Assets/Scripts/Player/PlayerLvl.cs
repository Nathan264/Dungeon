using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLvl : MonoBehaviour
{
    [SerializeField] private PlayerStats pStats;
    
    private int multiplier = 10;

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
        StatusCalc(ref pStats.hp);        
        StatusCalc(ref pStats.atk);        
        StatusCalc(ref pStats.spd);        
        StatusCalc(ref pStats.def);        
        StatusCalcSp();  


        if (pStats.lvl < 20)
        {
            multiplier = 10;
        }
        else if (pStats.lvl >= 20 && pStats.lvl <= 60)
        {
            multiplier = 5;
        }
        else if (pStats.lvl > 60)
        {
            multiplier = 3;
        } 
        
        pStats.lvl++;
        pStats.expToNextLvl += (pStats.expToNextLvl * 30) / 100;
    }
    
    private void StatusCalcSp()
    {
        pStats.sp += Random.Range(2, 5);
    }

    private void StatusCalc(ref float statusRef)
    {
        float value = (statusRef * multiplier) / 100;
        statusRef += Mathf.CeilToInt(value);
    }
}
