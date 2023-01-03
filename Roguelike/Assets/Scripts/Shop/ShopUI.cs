using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject bronze;
    private CollectibleUIScript bronzeText;
    [SerializeField] private GameObject silver;
    private CollectibleUIScript silverText;
    [SerializeField] private GameObject gold;
    private CollectibleUIScript goldText;
    [SerializeField] private GameObject crystal;
    private CollectibleUIScript crystalText;


    // Start is called before the first frame update
    void Start()
    {
        bronzeText = bronze.GetComponent<CollectibleUIScript>();
        silverText = silver.GetComponent<CollectibleUIScript>();
        goldText = gold.GetComponent<CollectibleUIScript>();
        crystalText = crystal.GetComponent<CollectibleUIScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bronzeText.updateField(PermanentStats.getBronze());
        silverText.updateField(PermanentStats.getSilver());
        goldText.updateField(PermanentStats.getGold());
        crystalText.updateField(PermanentStats.getCrystal());
    }
}
