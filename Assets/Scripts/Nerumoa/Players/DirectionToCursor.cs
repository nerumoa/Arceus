using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionToCursor : MonoBehaviour
{
    [SerializeField] GameObject cursor = default;

    float angle;
    int dir;

    public float GetAngle
    {
        get { return angle; }
    }

    // Update is called once per frame
    private void Update()
    {
        angle = CalculateAngle(transform.position, cursor.transform.position);
        dir = angle < 180f
            ? -1
            : 1;
        transform.localScale = new Vector2(2f * dir, 2f);
    }

    private float CalculateAngle(Vector2 start, Vector2 target)
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
