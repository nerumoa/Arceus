using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCursor : MonoBehaviour
{
    [SerializeField] GameObject cursor = default;

    GameObject player;
    float angle;

    private Vector3 distance = new Vector3(0f, 1.25f, 0f);

    private void Start()
    {
        player = transform.parent.gameObject;
    }

    private void Update()
    {
        angle = GetAngle(player.transform.position, cursor.transform.position);
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
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

        if (degree < 180f) {
            degree += 180f;
        }


        Debug.Log(degree);

        return degree;
    }
}
