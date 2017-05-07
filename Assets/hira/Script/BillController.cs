using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillController : MonoBehaviour
{
	void Start ()
    {
	    if(Random.Range(0f,1.0f) < 0.2)
        {
            Vector3 scale = transform.localScale;
            scale.y *= 2;
            transform.localScale = scale;

            Vector3 pos = transform.position;
            pos.y += 1.5f;
            transform.position = pos;
        }	
	}

    void Update ()
    {
   
    }
}
