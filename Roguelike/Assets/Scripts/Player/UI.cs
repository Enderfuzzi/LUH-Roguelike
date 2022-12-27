using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject bronzeField;
    private CollectibleUIScript bronzeTextField;
    [SerializeField] private GameObject silverField;
    private CollectibleUIScript silverTextField;
    [SerializeField] private GameObject goldField;
    private CollectibleUIScript goldTextField;
    [SerializeField] private GameObject crystalField;
    private CollectibleUIScript crystalTextField;

    [SerializeField] private GameObject healthField;
    private RessourceUIScript healthTextField;
    [SerializeField] private GameObject experienceField;
    private RessourceUIScript experienceTextField;

    // Start is called before the first frame update
    void Start()
    {
        bronzeTextField = bronzeField.GetComponent<CollectibleUIScript>();
        silverTextField = silverField.GetComponent<CollectibleUIScript>();
        goldTextField = goldField.GetComponent<CollectibleUIScript>();
        crystalTextField = crystalField.GetComponent<CollectibleUIScript>();

        healthTextField = healthField.GetComponent<RessourceUIScript>();
        experienceTextField = experienceField.GetComponent<RessourceUIScript>();
       
       }

   

    public void updateBronze(int value)
    {
        bronzeTextField.updateField(value);
    }

    public void updateSilver(int value)
    {
       silverTextField.updateField(value);
    }

    public void updateGold(int value)
    {
        goldTextField.updateField(value);
    }

    public void updateCrystal(int value)
    {
        crystalTextField.updateField(value);
    }

    public void updateLife(int currentValue, int maxValue)
    {
        healthTextField.updateField(currentValue, maxValue);
    }

    public void updateExperience(int currentValue, int maxValue)
    {
        experienceTextField.updateField(currentValue, maxValue);
    }
}
