using UnityEngine;
using System.Collections;
using System;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    // ゲームオーバテキスト
    private GameObject blockAudio;

    // Use this for initialization
    void Start()
    {
        this.blockAudio = GameObject.Find("BlockAudio");
        Console.WriteLine("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionr)
    {
        //障害物に衝突した場合（追加）
        if (collisionr.gameObject.tag == "ground" || collisionr.gameObject.tag == "CubePrefab")
        {
            this.blockAudio.GetComponent<AudioSource>().Play();
        }
    }
}