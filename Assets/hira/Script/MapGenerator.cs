using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private int[] m_map = { 0, 0, 1, 0, 2, 0, 1, 0, 0, 2, 0, 2, 0, 1, 0, 1, 0, 1, 0, 2, 0, 0, 1 };

    private const int m_minLength = 50;
    private const int m_maxLength = 100;

    private const int m_maxBillNum = 2;

    [SerializeField]
    GameObject m_bill1;

    [SerializeField]
    GameObject m_bill2;

    [SerializeField]
    private Vector3 m_move;

    private void SetMapLength()
    {
        int length = Random.Range(m_minLength, m_maxLength);
        m_map = new int[length];
    }

    private int GetRandomMapIdx()
    {
        return Random.Range(1, m_maxBillNum);
    }

    private void SetMap()
    {
        SetMapLength();

        int preIdx = 0;

        for (int i = 0; i < m_map.Length; i++)
        {
            int idx = Random.Range(0, m_maxBillNum + 1);

            if (preIdx != 0 && idx == preIdx)
            {
                if(Random.Range(0f,1.0f) < 0.5f)
                {
                    idx = Random.Range(1, m_maxBillNum + 1);
                }
            }

            m_map[i] = idx;
            preIdx = idx;

            if (idx != 0)
            {
                i += Random.Range(1, 3);
            }
        }
    }

    private string GetMapIdxs()
    {
        string s = "{";

        for(int i = 0;i < m_map.Length;i++)
        {
            s += m_map[i];

            if(i < m_map.Length - 1)
            {
                s += ",";
            }
        }

        s += "}";

        return s;
    }

    private void GenerateMap()
    {
        SetMap();

        Debug.Log(GetMapIdxs());

        for (int i = 0; i < m_map.Length; i++)
        {
            if (m_map[i] == 1)
            {
                Vector3 pos = transform.position + new Vector3(i, 0, 0) + m_move;

                Instantiate(m_bill1, pos, Quaternion.identity);
            }

            else if (m_map[i] == 2)
            {
                Vector3 pos = transform.position + new Vector3(i, 0.5f, 0) + m_move;

                Instantiate(m_bill2, pos, Quaternion.identity);
            }
        }
    }

    private void ReGenerateMap()
    {



        GenerateMap();
    }


    void Start ()
    {
        GenerateMap();
	}
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.R))
        {
            ReGenerateMap();
        }
	}
}
