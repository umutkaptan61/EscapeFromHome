using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject Player;
    public EnergyDrink energyDrink;

    private void Start()
    {
        energyDrink = FindObjectOfType<EnergyDrink>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {         
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = Move._lastTransform;           
            Player.GetComponent<CharacterController>().enabled = true;        
        }
    }


    
	

	
}
