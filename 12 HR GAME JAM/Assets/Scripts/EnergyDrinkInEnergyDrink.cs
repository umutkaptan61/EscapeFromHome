using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkInEnergyDrink : MonoBehaviour
{
    public static Vector3 _lastEnergyDrinkTransform;
    private EnergyDrink energyDrink;  


    private void Start()
    {
        energyDrink = FindObjectOfType<EnergyDrink>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && energyDrink.energyDrinkNumber == 0)
        {
            _lastEnergyDrinkTransform = transform.position;                
        }      
    }
}
