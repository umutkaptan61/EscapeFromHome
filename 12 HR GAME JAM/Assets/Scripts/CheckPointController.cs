using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {           
            Move._lastTransform = transform.position;
           // Debug.Log(Move._lastTransform);
        }
    }


}
