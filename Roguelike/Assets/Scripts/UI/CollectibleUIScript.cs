using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleUIScript : MonoBehaviour
{
    [SerializeField] private TMP_Text field;

    public void updateField(int value)
    {
        field.text = value.ToString();
    }
}
