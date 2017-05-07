using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitoMove : MonoBehaviour {

    Vector2 m_power;
    float m_acceleration;

    private Rigidbody2D rigit;

    // Use this for initialization
    void Start () {
        m_power = new Vector2(0.0f,10.0f);

        rigit = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        //transform.Translate(-m_spead, 0, 0, 0);

        Collider2D colider = GetComponent<Collider2D>();

        // 力が弱まったら、あたりの仕方を変える
        if (rigit.velocity.x > -9.0f || transform.position.y < -6.0f)
        {
            colider.isTrigger = false;
        }
    }

    // 当たった時の処理(早い時)
    private void OnTriggerEnter2D(Collider2D other)
    {
        rigit.velocity *= 0.7f;
    }
}
