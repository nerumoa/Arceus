using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum Situation
    {
        GROUND,
        RISE,
        FALL
    }

    float xRate;
    [SerializeField] float speed = 50f;
    bool isMove = false;
    bool isStart = false;

    float jumpTimer = 0f;
    const float jumpPower = 17f;
    const float gravity = 90f;
    bool jumpKey = false;
    bool jumpKeyLock = false;

    Rigidbody2D rb;
    Vector2 vect;
    Situation situation = Situation.GROUND;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xRate = Input.GetAxisRaw("Horizontal");
        if (xRate != 0) {
            isMove = true;
        } else {
            isMove = false;
        }

        if (Input.GetKey("space")) {
            if (!jumpKeyLock) {
                jumpKey = true;
            } else {
                jumpKey = false;
            }
        } else {
            jumpKey = false;
            jumpKeyLock = false;
        }

        if (situation == Situation.FALL && HitGround()) {
            situation = Situation.GROUND;
            jumpTimer = 0f;
            jumpKeyLock = true;
        }
    }

    private void FixedUpdate()
    {
        vect = Vector2.zero;

        if (isMove) {
            vect.x = xRate * speed;
            transform.localScale = new Vector2(xRate, 1f);
        } else {
            vect.x = 0f;
        }

        if (situation == Situation.GROUND && rb.velocity.y < 0f) {
            situation = Situation.FALL;
            jumpTimer = 0.1f;
        } else if (situation == Situation.RISE && rb.velocity.y == 0f && jumpTimer > 0.03f) {
            situation = Situation.FALL;
            jumpTimer = 0f;
        }

        switch (situation) {
            case Situation.GROUND:
                if (jumpKey) {
                    situation = Situation.RISE;
                }
                break;

            case Situation.RISE:
                jumpTimer += Time.deltaTime;
                if (jumpKey || jumpTimer < 0.03f) {
                    vect.y = jumpPower;
                    vect.y -= gravity * Mathf.Pow(jumpTimer, 2f);
                } else {
                    jumpTimer += Time.deltaTime;
                    vect.y = jumpPower;
                    vect.y -= gravity * Mathf.Pow(jumpTimer, 1.4f);
                }

                if (vect.y < 0f) {
                    situation = Situation.FALL;
                    vect.y = 0f;
                    jumpTimer = 0.1f;
                }
                break;

            case Situation.FALL:
                jumpTimer += Time.deltaTime;
                vect.y = 0f;
                vect.y = -(gravity * Mathf.Pow(jumpTimer, 2f));
                if (vect.y < -15f) {
                    vect.y = -15f;
                }
                break;

            default:
                break;
        }

        rb.velocity = vect;
    }
}
