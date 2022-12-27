using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RessourceUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text field;

    public void updateField(int currentValue, int maxValue)
    {
        field.text = string.Format("{1}/{2}",currentValue,maxValue);
    }
}
