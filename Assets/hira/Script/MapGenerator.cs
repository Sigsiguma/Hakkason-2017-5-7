﻿using System.Collections;
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
    private Vector3 m_move;


    private int GetMapLength()
    {
        return m_map.Length;
    }

    private int GetRandomIdx()
    {
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
                Vector3 pos = transform.position + new Vector3(i, 0, 0) + m_move;
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
