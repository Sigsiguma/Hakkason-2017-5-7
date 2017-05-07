using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    //推したときの位置
    public Vector3 startPos = Vector3.zero;
    //離したときの位置
    Vector3 endPos = Vector3.zero;
    // 押したときのプレイヤーの位置
    Vector3 startPlayerPos;

    // 引っ張り角度
    public float rot;
    public float dis;

    //スピード
    Vector2 spd = Vector3.zero;
    //移動してるかどうか
    bool checkMove;
    bool isTouch;

    Rigidbody2D rb;

    // 

    // Use this for initialization
	void Start () {
        checkMove = false;
        isTouch = false;

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if(transform.position.y < 0)
        //{
        //    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //}

        if (checkMove == false)
        {
            //ボタンが押されたとき
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                startPlayerPos = transform.position;
                checkMove = false;
                isTouch = true;
            }
            //ボタンを離したとき
            if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;
                checkMove = true;

                spd = (endPos - startPos) * -2;

                spd /= 30;

                if(spd.x > -4.0f)
                {
                    checkMove = false;
                }

                isTouch = false;
            }
        }
        if (checkMove == true)
        {
            rb.velocity = spd;

            // transform.Translate(spd);
            //transform.Translate(0, (-9.8f / 60.0f / 10.0f), 0);

            //rb.AddForce(spd, ForceMode2D.Impulse);

            spd *= 0.98f;

            Collider2D colider = GetComponent<Collider2D>();

            colider.isTrigger = true;

            checkMove = false;
        }

        if (isTouch)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.ScreenToWorldPoint(startPos);

            Vector3 pos2 = (pos / 2.0f) + startPlayerPos;

            if (pos2.y <= -5.0f)
            {
                pos2.y = -5.0f;
            }

            rot = Mathf.Atan2(pos2.y, pos2.x) * 180 / Mathf.PI;

            transform.position = pos2;
        }
    }

}
