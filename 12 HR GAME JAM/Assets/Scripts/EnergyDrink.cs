using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDrink : MonoBehaviour
{
    public float energyDrinkNumber = 0f;
    public GameObject Description;
    public GameObject energyDrinkPrefab;
    Move move;

    [SerializeField] public Text energyDrinkNumberText;    
    [SerializeField] public Slider energyDrinkFullness;

    public float energyDrinkTime = 0f;
    public bool hasIEnergy;
    public bool energyDrinkDescription;
    public bool hasComeBackEnergy;   //Enerji geri getirmek için

    void Start()
    {
        hasIEnergy = false;
        move = FindObjectOfType<Move>();
        energyDrinkFullness.value = float.MinValue;
        Description.SetActive(false);
        energyDrinkDescription = false;
        hasComeBackEnergy = false;
    }


    void Update()
    {
        
        energyDrinkNumberText.text = energyDrinkNumber.ToString();        

        if (energyDrinkNumber == 1)
        {         
            energyDrinkFullness.value = float.MaxValue;

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {             
                hasIEnergy = true;          
                move.jumpHeight = move.jumpHeightWithEnergy;              
                StartCoroutine(ReduceTheEnergyDrinkNumber());
                if (hasComeBackEnergy == false)
                {
                    StartCoroutine(ComeBackEnergyDrink());
                }            
            }

            else if (hasIEnergy == true)
            {              
                energyDrinkTime += Time.deltaTime;
                energyDrinkFullness.value -= energyDrinkTime;              
            }
        }

        else
        {
            energyDrinkNumber = 0;
            move.jumpHeight = move.jumpHeightNoEnergy;
        }



        if (energyDrinkNumber == 1 && energyDrinkDescription == false)
        {
            Time.timeScale = 0f;
            Description.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1f;
                energyDrinkDescription = true;
                Destroy(Description);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (energyDrinkNumber == 0)
        {
            if (other.gameObject.tag == "EnergyDrink")
            {
                energyDrinkNumber = 1;
                Destroy(other.gameObject);
            }
        }
       
    }


    IEnumerator ReduceTheEnergyDrinkNumber()
    {       
         yield return new WaitForSeconds(5f);
         energyDrinkNumber = 0;
         hasIEnergy = false;
         energyDrinkTime = 0f;                
    }


    IEnumerator ComeBackEnergyDrink()   //En son aldýðýn enerji içececeðini kullanýnca tekrardan yerinde yenisi oluþacak.
    {
        hasComeBackEnergy = true;
        yield return new WaitForSeconds(10f);
        Instantiate(energyDrinkPrefab, EnergyDrinkInEnergyDrink._lastEnergyDrinkTransform, Quaternion.identity);
        hasComeBackEnergy = false;
    }       
}
