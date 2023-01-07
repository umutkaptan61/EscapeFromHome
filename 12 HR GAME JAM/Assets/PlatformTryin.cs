using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTryin : MonoBehaviour
{
    [SerializeField] public Transform player;
    //CharacterController cc;

    void Start()
    {
        //cc = player.GetComponent<CharacterController>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            player.transform.parent.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
