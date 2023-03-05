using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLvl : MonoBehaviour
{
    [SerializeField] private EnemyObject eObj;
    [SerializeField] private Enemy enemy;

    private int multiplier;


    private void OnEnable() 
    {
        SetEnemyInfo();
    }

    private void SetEnemyInfo()
    {
        enemy.EnemyName = eObj.enemyName;

        Setlvlnemy();
    }

    private void Setlvlnemy()
    {
        if (enemy.Lvl < 20)
        {
            multiplier = 10;
        }
        else if (enemy.Lvl >= 20 && enemy.Lvl <= 60)
        {
            multiplier = 5;
        }
        else if (enemy.Lvl > 60)
        {
            multiplier = 3;
        }

        for (int i = 0; i < enemy.Lvl; i++)
        {
            enemy.Hp = IncreaseStats(enemy.Hp);          
            enemy.Atk = IncreaseStats(enemy.Atk);         
            enemy.Def = IncreaseStats(enemy.Def);         
            enemy.Spd = IncreaseStats(enemy.Spd);         
        }
    }

    private float IncreaseStats(float stat)
    {
        float value = (stat * multiplier) / 100;
        stat += Mathf.CeilToInt(stat);

        return stat;
    }
}
