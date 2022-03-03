using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] GameObject effect = default;

    float angle;

    Animator anim;
    new AudioSource audio;
    GameObject player;
    PlayerController pc;
    DirectionToCursor dtc;
    Vector3 distance = new Vector3(0f, 1.5f, 0f);


    private void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        player = transform.parent.gameObject;
        pc = player.GetComponent<PlayerController>();
        dtc = player.GetComponent<DirectionToCursor>();
    }

    private void Update()
    {
        angle = dtc.GetAngle;

        if (pc.GetIsZkey) {
            VerticalAttack();
        }
    }


    private void VerticalAttack()
    {
        audio.time = 0.12f;
        audio.Play();
        anim.SetTrigger("Attack");
        Instantiate(effect,
                    player.transform.position + Quaternion.Euler(0f, 0f, angle) * distance,
                    Quaternion.Euler(0, 0, angle + 90f));
    }
}
