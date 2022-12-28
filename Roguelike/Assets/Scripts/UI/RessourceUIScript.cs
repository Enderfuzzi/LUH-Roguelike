using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RessourceUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text field;
    [SerializeField] private Slider bar;

    public void updateField(int currentValue, int maxValue)
    {
        field.text = string.Format("{0}/{1}",currentValue.ToString(),maxValue.ToString());
        bar.maxValue = maxValue;
        bar.value = currentValue;
    }
}
