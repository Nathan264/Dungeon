using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statusbar : MonoBehaviour
{
    [SerializeField] private Image barImg;

    
    public void UpdateBar(float newValue, float fullValue)
    {
        float percentagevalue = ((newValue * 100) / fullValue) / 100;

        barImg.fillAmount = percentagevalue;
    }
}
