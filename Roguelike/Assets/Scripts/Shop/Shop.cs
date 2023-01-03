using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{



    [SerializeField] public GameObject playerObject;
    private Player playerReference;
    
    // Start is called before the first frame update
    void Start()
    {
        playerReference = playerObject.GetComponent<Player>();
    }


    public void freeDamageUpgrade()
    {
        playerReference.changeDamage(2);
        ShopManager.unpause();
    }

    public void freeHealthUpgrade()
    {
        playerReference.changeMaximalLife(10);
        ShopManager.unpause();
    }

    public void freeMovementUpgrade()
    {
        playerReference.changeMovementSpeed(0.5f);
        ShopManager.unpause();
    }

    public void freeResistanceUpgrade()
    {
        playerReference.changeDamageResistance(2);
        ShopManager.unpause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
