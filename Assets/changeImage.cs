using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeImage : MonoBehaviour {

    private SpriteRenderer renderer;

    [SerializeField]
    private Sprite img;

    bool colliderFlg;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // 当たった時の処理
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.isTrigger)
        {
            renderer.sprite = img;

            Collider2D coll = GetComponent<Collider2D>();

            coll.isTrigger = true;
        }


    }


}
