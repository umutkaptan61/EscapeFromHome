using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject movingPlatform;

    public bool bittiMi;

    void Start()
    {
        bittiMi = false;
    }

    
    void FixedUpdate()
    {
        if (bittiMi == false)
        {
            movingPlatform.transform.position += new Vector3(0f, 1f, 0f) * Time.deltaTime;
            StartCoroutine(TurnBack());
        }

        
        
        if (bittiMi == true)
        {
            movingPlatform.transform.position += new Vector3(0f, -1f, 0f) * Time.deltaTime;
            StartCoroutine(TurnBack2());
        }
         
    }

    IEnumerator TurnBack()
    {
        yield return new WaitForSeconds(5f);
        if (bittiMi == false)
        {
            bittiMi = true;
        }       
    }

    IEnumerator TurnBack2()
    {
        yield return new WaitForSeconds(5f);
        if (bittiMi == true)
        {
            bittiMi = false;
        }
    }
}
