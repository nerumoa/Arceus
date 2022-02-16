using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    //タマを格納する変数をエディター上で編集できるようにする
    public GameObject bullet;


    // Update is called once per frame
    void Update()
    {
        //もし左クリックが押されたら
        if (Input.GetMouseButtonDown(0))
        {
            //弾をこのオブジェクトの位置に複製する。
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
