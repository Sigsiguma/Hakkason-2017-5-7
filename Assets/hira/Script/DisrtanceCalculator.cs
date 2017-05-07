using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisrtanceCalculator : MonoBehaviour
{
    Vector3 m_schoolPos;

    void Start()
    {
        m_schoolPos = GameObject.Find("MapGenerator").GetComponent<MapGenerator>().GetSchoolPos();      
	}
	
    public int GetDistance()
    {
        return (int)(transform.position.x - m_schoolPos.x)*10;
    }

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(GetDistance() + "m");
        }
	}
}
