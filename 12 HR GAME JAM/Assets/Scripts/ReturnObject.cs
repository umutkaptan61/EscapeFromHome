using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnObject : MonoBehaviour
{

    [SerializeField] private Vector3 angle;

    
    void Update()
    {
        transform.Rotate(angle, Space.World);
    }
}
