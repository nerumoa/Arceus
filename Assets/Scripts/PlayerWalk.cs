using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    //移動スピード
    float speed = 5;

    // 最初に一回だけ実行するやつ
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
    //何回もフレーム毎に呼び出される
    void Update()
    {
        //もしDキーが押されているなら
        if (Input.GetKey(KeyCode.D))
        {
            //現在の位置を、現在の位置＋移動距離＊フレーム時間に上書きする
            transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        //もしAキーが押されているなら
        if (Input.GetKey(KeyCode.A))
        {
            //現在の位置を、現在の位置＋移動距離＊フレーム時間に上書きする
            transform.position = transform.position - new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }
}
