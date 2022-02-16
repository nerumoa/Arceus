using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mouse;
    private Vector3 target;
   

    // Update is called once per frame
    void Update()
    {
        //マウスの位置とレティクルの位置を同期させる
        mouse = Input.mousePosition;
        target = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, 10));
        this.transform.position = target;

        
    }
}
