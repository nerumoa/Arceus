using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ContactFilter2D ground = default;
    [SerializeField] private ContactFilter2D ceiling = default;
    bool isGround;
    bool isCeiling;

    float xRate;
    [SerializeField] float speed = 8f;
    bool isMove = false;

    float jumpTimer = 0f;
    const float jumpPower = 18f;
    const float gravity = 120f;
    bool jumpKey = false;
    bool jumpKeyLock = false;


    Rigidbody2D rb;
    Vector2 vect;
    Situation situation = Situation.GROUND;

    enum Situation
    {
        GROUND,
        RISE,
        FALL
    }

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0.1f;
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

        // Jump二度押しを出来ないようにする
        // 二段ジャンプを参考にすれば良い？

        isGround = rb.IsTouching(ground);
        isCeiling = rb.IsTouching(ceiling);

        // 地面と接触した場合
        if (situation == Situation.FALL && isGround) {
            situation = Situation.GROUND;
            jumpTimer = 0f;
            jumpKeyLock = true;
        }
    }

    private void FixedUpdate()
    {
        //vect = Vector2.zero;

        if (isMove) {
            vect.x = xRate * speed;
            transform.localScale = new Vector2(xRate * 2f, 2f);
        } else {
            vect.x = 0f;
        }

        // 床から落ちた場合 / 天井に当たった場合
        if (situation == Situation.GROUND && rb.velocity.y < -0.01f) {
            situation = Situation.FALL;
            jumpTimer = 0.1f;   
        } else if (situation == Situation.RISE && isCeiling) {
            situation = Situation.FALL;
            jumpTimer = 0.1f;
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
                Debug.Log("default");
                break;
        }

        //Debug.Log(jumpKey);
        //Debug.Log(situation);

        rb.velocity = vect;
    }
}
