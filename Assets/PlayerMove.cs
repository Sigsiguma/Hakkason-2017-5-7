using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour {
    //推したときの位置
    Vector3 startPos = Vector3.zero;
    //離したときの位置
    Vector3 endPos = Vector3.zero;

    //スピード
    Vector2 spd = Vector3.zero;
    //移動してるかどうか
    public static bool checkMove;
    
    

    Rigidbody2D rb;

    // Use this for initialization
    void Start() {
        checkMove = false;
        

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            //地面を越そうとしたら地面の上に移動させる
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
                //離したときのマウスの座標を記録
                endPos = Input.mousePosition;
                //もうおせないようにする
                checkMove = true;

                //速度の設定
                spd.x = (endPos.x - startPos.x) * -2.0f / 60.0f;
                spd.y = (endPos.y - startPos.y) * -2.0f / 60.0f;

                if(spd.x < spd.y)
                {
                    spd.y = spd.x * 0.75f;
                }
                

                //後ろに飛んで行きそうなら
                if (spd.x < 0)
                {
                    //もう一回飛ばそうとする
                    checkMove = false;
                }

            }

            if (ControllBer.b)
            {
                //速度の設定
                spd.x = 10.0f;
                spd.y = 10.0f;

                checkMove = true;
            }

        }
        else
        {
            spd.y -= rb.gravityScale;

            rb.velocity = spd;

            spd *= 0.98f;
        }
    }
}