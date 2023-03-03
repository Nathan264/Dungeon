using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLvl : MonoBehaviour
{
    [SerializeField] private EnemyObject eObj;
    [SerializeField] private EnemyStats eStats;

    private int multiplier;


    private void OnEnable() 
    {
        SetEnemyInfo();
    }

    private void SetEnemyInfo()
    {
        eStats.EnemyName = eObj.enemyName;

        SetlvlStats();
    }

    private void SetlvlStats()
    {
        if (eStats.Lvl < 20)
        {
            multiplier = 10;
        }
        else if (eStats.Lvl >= 20 && eStats.Lvl <= 60)
        {
            multiplier = 5;
        }
        else if (eStats.Lvl > 60)
        {
            multiplier = 3;
        }

        for (int i = 0; i < eStats.Lvl; i++)
        {
            eStats.Hp = IncreaseStats(eStats.Hp);          
            eStats.Atk = IncreaseStats(eStats.Atk);         
            eStats.Def = IncreaseStats(eStats.Def);         
            eStats.Spd = IncreaseStats(eStats.Spd);         
        }
    }

    private float IncreaseStats(float stat)
    {
        float value = (stat * multiplier) / 100;
        stat += Mathf.CeilToInt(stat);

        return stat;
    }
}
