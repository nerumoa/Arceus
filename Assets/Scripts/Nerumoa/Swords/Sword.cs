using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    float angle;

    GameObject player;
    DirectionToCursor dtc;

    private void Start()
    {
        player = transform.parent.gameObject;
        dtc = player.GetComponent<DirectionToCursor>();
    }

    private void Update()
    {
        angle = dtc.GetAngle;
        if (angle < 180f) {
            angle += 180f;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
    }
}
