using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    //タマを格納する変数をエディター上で編集できるようにする
    public GameObject bullet;
    float speed = 10;
   


    // Update is called once per frame
    void Update()
    {
        //もし左クリックが押されたら
        //球を打つ
        if (Input.GetMouseButtonDown(0))
        {
            //弾の作成
            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
            // クリックした座標の取得（スクリーン座標からワールド座標に変換）
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 向きの生成（Z成分の除去と正規化）
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

            // 弾に速度を与える
            clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
        }
    }
}
