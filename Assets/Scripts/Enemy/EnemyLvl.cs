using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLvl : MonoBehaviour
{
    [SerializeField] private EnemyObject eObj;
    [SerializeField] private Enemy enemy;
    [SerializeField] private StatsGrowCurv statsGrowCurvHp;
    [SerializeField] private StatsGrowCurv statsGrowCurvSp;
    [SerializeField] private StatsGrowCurv statsGrowCurvSpd;
    [SerializeField] private StatsGrowCurv statsGrowCurvAtk;
    [SerializeField] private StatsGrowCurv statsGrowCurvDef;

    [SerializeField] private float growFactor;

    private void OnEnable() 
    {
        SetEnemyLvl();
    }

    private void SetEnemyLvl()
    {
        for (int i = 0; i < enemy.Lvl; i++)
        {
            enemy.Hp = StatusCalc(enemy.Hp, Random.Range(statsGrowCurvHp.min, statsGrowCurvHp.max));        
            enemy.Atk = StatusCalc(enemy.Atk, Random.Range(statsGrowCurvAtk.min, statsGrowCurvAtk.max));        
            enemy.Def = StatusCalc(enemy.Spd, Random.Range(statsGrowCurvSpd.min, statsGrowCurvSpd.max));        
            enemy.Spd = StatusCalc(enemy.Def, Random.Range(statsGrowCurvDef.min, statsGrowCurvDef.max));              
        }
    }

    private float StatusCalc(float stat, float growCurv)
    {
        float value = growFactor * Mathf.Pow(enemy.Lvl, growCurv);
        stat += Mathf.CeilToInt(value);

        return stat;
    }
}
