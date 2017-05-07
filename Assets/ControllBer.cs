using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllBer : MonoBehaviour {
    public static float cnt;
    public static float stopCnt;

    float value;
    public static bool b;

    Slider _slider;
	// Use this for initialization
	void Start () {
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
        b = false;
        cnt = 0;
        stopCnt = Random.Range(5, 10) * 60;
    }
	
	// Update is called once per frame
	void Update () {
        value = cnt / stopCnt;
        _slider.value = value;

        if(cnt == stopCnt)
        {
            b = true;
        }
        if(cnt == 0)
        {
            _slider.value = _slider.minValue;
        }

        cnt++;
	}
}
