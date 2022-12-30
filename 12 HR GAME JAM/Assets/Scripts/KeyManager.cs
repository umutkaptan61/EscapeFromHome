using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public float keyNumber = 0f;
    [SerializeField] public Text keyNumberText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Key")
        {
            {
                Destroy(other.gameObject);
                keyNumber++;
                keyNumberText.text = keyNumber.ToString();
            }
        }
    }

}
