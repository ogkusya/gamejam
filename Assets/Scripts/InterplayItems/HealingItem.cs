using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : InterplayItems
{
    [SerializeField] private int amountHpRestore;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeHeal(amountHpRestore);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
