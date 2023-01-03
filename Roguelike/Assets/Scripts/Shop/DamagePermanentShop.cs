using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePermanentShop : MonoBehaviour
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
        levelText.updateField(PermanentStats.getDamageBoostLevel());
        costText.updateField((PermanentStats.getDamageBoostLevel() + 1) * PermanentStats.damageCost);
    }
}
