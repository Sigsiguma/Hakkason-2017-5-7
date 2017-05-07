using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour {
    //推したときの位置
    Vector3 startPos = Vector3.zero;
    //離したときの位置
    Vector3 endPos = Vector3.zero;

    //スピード
    Vector2 spd = Vector3.zero;
    //移動してるかどうか
    bool checkMove;

    Rigidbody2D rb;

    // Use this for initialization
	void Start () {
        checkMove = false;

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        if (checkMove == false)
        {
            //ボタンが押されたとき
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                checkMove = false;
            }
            //ボタンを離したとき
            if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;
                checkMove = true;

                spd = (endPos - startPos) * -2;

                spd /= 30;

                if(spd.x < 0)
                {
                    checkMove = false;
                }
            }
        }
        if (checkMove == true)
        {
            rb.velocity = spd;

            // transform.Translate(spd);
            //transform.Translate(0, (-9.8f / 60.0f / 10.0f), 0);


            spd *= 0.98f;
        }
    }
}
