using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavedSpawn : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<EnemyController>().leavedSpawn();
        gameObject.SetActive(false);
    }
}
