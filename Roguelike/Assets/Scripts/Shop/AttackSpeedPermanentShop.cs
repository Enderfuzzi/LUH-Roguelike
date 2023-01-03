using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedPermanentShop : MonoBehaviour
{
    [SerializeField] private GameObject levelField;
    private CollectibleUIScript levelText;
    [SerializeField] private GameObject costField;
    private CollectibleUIScript costText;

    void Start()
    {
        levelText = levelField.GetComponent<CollectibleUIScript>();
        costText = costField.GetComponent<CollectibleUIScript>();
    }

    void FixedUpdate()
    {
        levelText.updateField(PermanentStats.getAttackSpeedBoostLevel());
        costText.updateField((PermanentStats.getAttackSpeedBoostLevel() + 1) * PermanentStats.attackSpeedCost);
    }
}
