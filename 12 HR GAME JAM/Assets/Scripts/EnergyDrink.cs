using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDrink : MonoBehaviour
{
    public float energyDrinkNumber = 0f;
    Move move;

    [SerializeField] public Text energyDrinkNumberText;
    [SerializeField] public Slider energyDrinkFullness;

    public float energyDrinkTime = 0f;
    public bool hasIEnergy;

    void Start()
    {
        hasIEnergy = false;
        move = FindObjectOfType<Move>();
        energyDrinkFullness.value = float.MinValue;
    }


    void Update()
    {
        energyDrinkNumberText.text = energyDrinkNumber.ToString();
        //float time = energyDrinkTime - Time.time;

        if (energyDrinkNumber >= 1)
        {
            //hasIEnergy = true;
            energyDrinkFullness.value = float.MaxValue;

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                hasIEnergy = true;
                //energyDrinkTime -= Time.deltaTime;
                //energyDrinkFullness.value += energyDrinkTime;
                //energyDrinkFullness.value = float.MinValue - (float)Time.time;
                move.jumpHeight = move.jumpHeightWithEnergy;
                StartCoroutine(ReduceTheEnergyDrinkNumber());               
            }

            else if (hasIEnergy == true)
            {              
                energyDrinkTime += Time.deltaTime;
                energyDrinkFullness.value -= energyDrinkTime;
                //energyDrinkTime = 0f;
            }
        }

        /*else if (hasIEnergy == true)
        {
            energyDrinkTime -= Time.deltaTime;
        }*/

        else
        {
            energyDrinkNumber = 0;
            move.jumpHeight = move.jumpHeightNoEnergy;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnergyDrink")
        {
            energyDrinkNumber++;          
            Destroy(other.gameObject);                                   
        }
    }


    IEnumerator ReduceTheEnergyDrinkNumber()
    {
         //energyDrinkFullness.value = 
         yield return new WaitForSeconds(10f);
         energyDrinkNumber--;
         hasIEnergy = false;
         energyDrinkTime = 0f;
    }
       
}
