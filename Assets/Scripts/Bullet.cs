using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //移動スピード
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //現在の位置を、現在の位置＋移動距離＊フレーム時間に上書きする
        transform.position = transform.position + new Vector3(speed, speed, 0) * Time.deltaTime;
    }
}
