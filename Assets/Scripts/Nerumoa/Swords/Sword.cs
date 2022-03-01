using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] GameObject effect = default;

    float angle;

    GameObject player;
    DirectionToCursor dtc;
    Animator anim;
    Vector3 distance = new Vector3(0f, 1.5f, 0f);


    private void Start()
    {
        player = transform.parent.gameObject;
        dtc = player.GetComponent<DirectionToCursor>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        angle = dtc.GetAngle;

        if (Input.GetKeyDown(KeyCode.Z)) {
            anim.SetTrigger("Attack");
            Instantiate(effect,
                        player.transform.position + Quaternion.Euler(0f, 0f, angle) * distance,
                        Quaternion.Euler(0, 0, angle + 90f));
        }
    }


    public void VerticalAttack()
    {
        anim.SetTrigger("Attack");
    }
}
