using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCursor : MonoBehaviour
{
    [SerializeField] GameObject cursor = default;

    GameObject player;
    Vector3 distance = new Vector3(0f, 1.25f, 0f);

    float angle;
    int dir;

    private void Start()
    {
        player = transform.parent.gameObject;
    }

    private void Update()
    {
        angle = GetAngle(player.transform.position, cursor.transform.position); ;

        //　RCの位置 = playerの位置 ＋ RCの角度 ×　playerからの距離
        transform.position = player.transform.position + Quaternion.Euler(0f, 0f, angle) * distance;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        dir = angle < 180f 
            ? -1
            : 1;
        player.transform.localScale = new Vector2(2f * dir, 2f);

    }

    private float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        degree -= 90f;
        if (degree < 0f) {
            degree += 360f;
        }

        return degree;
    }
}
