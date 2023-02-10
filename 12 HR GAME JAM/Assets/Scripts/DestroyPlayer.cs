using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{
    public float characterHealth = 10f;
    public float currentHealth;
    public Slider characterHealthSlider;
    public Gradient gradient;
    public Image fill;

    public GameObject Player;
    private EnergyDrink energyDrink;
    public AudioSource getDamageSounds;
  

    private void Start()
    {
        energyDrink = FindObjectOfType<EnergyDrink>();
        currentHealth = characterHealth;
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        characterHealthSlider.value = currentHealth;
        fill.color = gradient.Evaluate(characterHealthSlider.normalizedValue);
        FinishGame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            currentHealth--;
            getDamageSounds.Play();
            Player.GetComponent<CharacterController>().enabled = false;
            Player.transform.position = Move._lastTransform;           
            Player.GetComponent<CharacterController>().enabled = true;        
        }
    }


    private void FinishGame()
    {
        if (currentHealth == 0)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    


    
	

	
}
