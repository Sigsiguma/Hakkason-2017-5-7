using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private int[] m_map;

    private const int m_minLength = 50;
    private const int m_maxLength = 100;

    [SerializeField]
    GameObject m_bill;

    [SerializeField]
    GameObject m_house;

    [SerializeField]
    GameObject m_tower;

    [SerializeField]
    GameObject m_school;

    [SerializeField]
    GameObject m_backGround;

    [SerializeField]
    GameObject m_floor;

    private Vector3 m_move = new Vector3(-7,-2,0);


    private int GetMapLength()
    {
        return m_map.Length;
    }

    private int GetRandomIdx()
    {
        if(Random.Range(0.0f, 1.0f) < 0.4)
        {
            return 0;
        }

        float rand = Random.Range(0.0f, 1.0f);

        if (rand < 0.1)
        {
            return 3;
        }

        else if (rand < 0.4)
        {
            return 2;
        }

        else
        {
            return 1;
        }
    }

    private void SetMapLength()
    {
        int length = Random.Range(m_minLength, m_maxLength);
        m_map = new int[length];
    }

    private void SetMap()
    {
        SetMapLength();

        int preIdx = 0;

        for (int i = 0; i < m_map.Length; i++)
        {
            int idx = GetRandomIdx();

            if (preIdx != 0 && idx == preIdx)
            {
                if(Random.Range(0f,1.0f) < 0.5f)
                {
                    idx = GetRandomIdx();
                }
            }

            m_map[i] = idx;
            preIdx = idx;

            if (idx != 0)
            {
                i += Random.Range(idx + 1, 4 + idx);
            }
        }
    }

    private void GenerateMap()
    {
        SetMap();

        {
            GameObject backGround = Instantiate(m_backGround) as GameObject;
            Vector3 scale = backGround.transform.localScale;
            scale.x *= 1000;
            scale.y *= 10;
            backGround.transform.localScale = scale;

            Vector3 pos = backGround.transform.position;
            backGround.transform.position = pos;
        }

        {
            GameObject floor = Instantiate(m_floor) as GameObject;
            Vector3 scale = floor.transform.localScale;
            scale.x *= 500;
            scale.y *= 1.5f;
            floor.transform.localScale = scale;

            Vector3 pos = floor.transform.position;

            pos.y += m_move.y*2 - 2.26f; 

            floor.transform.position = pos;
        }

        Vector3 move = m_move;
        move.x -= m_map.Length;
        m_move = move;

        {
            Vector3 pos = transform.position + new Vector3(-10, 0, 0) + m_move;
            Instantiate(m_school, pos, Quaternion.identity);
        }

        

        for (int i = 0; i < m_map.Length; i++)
        {
            if (m_map[i] == 1)
            {
                Vector3 pos = transform.position + new Vector3(i, 0, 0) + m_move;
                Instantiate(m_bill, pos, Quaternion.identity);
            }

            else if (m_map[i] == 2)
            {
                Vector3 pos = transform.position + new Vector3(i, -0.02f, 0) + m_move;
                Instantiate(m_house, pos, Quaternion.identity);
            }

            else if (m_map[i] == 3)
            {
                Vector3 pos = transform.position + new Vector3(i, 2.25f, 0) + m_move;
                Instantiate(m_tower, pos, Quaternion.identity);
            }
        }
    }

    void Start()
    {
        GenerateMap();
	}
	
	void Update()
    {

	}
}
