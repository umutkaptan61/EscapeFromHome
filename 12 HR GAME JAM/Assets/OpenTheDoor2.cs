using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoor2 : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject thisTrigger;
    //public AudioSource doorOpenSound;
    public bool action = false;
    KeyManager keyManager;

    void Start()
    {
        keyManager = FindObjectOfType<KeyManager>();
        Instruction.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            action = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        action = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (action == true && keyManager.keyNumber >= 1)
            {
                keyManager.keyNumber--;
                keyManager.keyNumberText.text = keyManager.keyNumber.ToString();
                Instruction.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("OpenTheDoor");
                thisTrigger.SetActive(false);
                //doorOpenSound.Play();
                action = false;
            }
        }
    }
}
