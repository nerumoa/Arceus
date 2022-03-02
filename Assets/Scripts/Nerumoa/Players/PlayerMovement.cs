using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ContactFilter2D ground = default;
    [SerializeField] private ContactFilter2D ceiling = default;
    bool isGround;
    bool isCeiling;

    [SerializeField] float speed = 8f;
    float xRate;
    bool isMove = false;

    int jumpCount = 0;
    float jumpTimer = 0f;
    const float jumpPower = 18f;
    const float gravity = 120f;
    bool jumpKey = false;
    bool jumpKeyLock = false;
    bool canDoubleJump = true;


    Rigidbody2D rb;
    Vector2 vect;
    Situation sitn = Situation.GROUND;

    enum Situation
    {
        GROUND,
        RISE,
        RISE_TWO,
        FALL,
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xRate = Input.GetAxisRaw("Horizontal");
        if (xRate != 0) {
            isMove = true;
        } else {
            isMove = false;
        }

        // 地面と接触した場合
        if (sitn == Situation.FALL && isGround) {
            sitn = Situation.GROUND;
            jumpCount = 0;
            jumpTimer = 0f;
            jumpKeyLock = true;
            canDoubleJump = true;
        }

        // ジャンプしようとした回数
        if (Input.GetKeyDown("space")) {
            jumpCount++;
        }

        // ジャンプの長さ
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

        isGround = rb.IsTouching(ground);
        isCeiling = rb.IsTouching(ceiling);
    }

    private void FixedUpdate()
    {
        //vect = Vector2.zero;

        if (isMove) {
            vect.x = xRate * speed;
        } else {
            vect.x = 0f;
        }

        // 床から落ちた場合 / 天井に当たった場合
        if (sitn == Situation.GROUND && rb.velocity.y < -0.01f) {
            sitn = Situation.FALL;
            jumpCount++;
            jumpTimer = 0.1f;   
        } else if ((sitn == Situation.RISE || sitn == Situation.RISE_TWO) && isCeiling) {
            sitn = Situation.FALL;
            jumpTimer = 0.1f;
        }

        if (jumpCount == 2 && canDoubleJump) {
            sitn = Situation.RISE_TWO;
            jumpTimer = 0.05f;
            canDoubleJump = false;
        }

        switch (sitn) {
            case Situation.GROUND:
                if (jumpKey) {
                    sitn = Situation.RISE;
                }
                break;

            case Situation.RISE:
                jumpTimer += Time.deltaTime;
                if ((jumpKey || jumpTimer < 0.03f) && jumpCount < 2) {
                    vect.y = jumpPower;
                    vect.y -= gravity * Mathf.Pow(jumpTimer, 2f);
                } else {
                    jumpTimer += Time.deltaTime;
                    vect.y = jumpPower;
                    vect.y -= gravity * Mathf.Pow(jumpTimer, 1.4f);
                }

                if (vect.y < 0f) {
                    sitn = Situation.FALL;
                    vect.y = 0f;
                    jumpTimer = 0.1f;
                }
                break;

            case Situation.RISE_TWO:
                jumpTimer += Time.deltaTime;
                if ((jumpKey || jumpTimer < 0.03f) && jumpCount < 3) {
                    vect.y = jumpPower / 1.2f;
                    vect.y -= gravity * Mathf.Pow(jumpTimer, 2.1f);
                } else {
                    jumpTimer += Time.deltaTime;
                    vect.y = jumpPower / 1.2f;
                    vect.y -= gravity * Mathf.Pow(jumpTimer, 1.4f);
                }

                if (vect.y < 0f) {
                    sitn = Situation.FALL;
                    vect.y = 0f;
                    jumpTimer = 0.1f;
                }
                break;

            case Situation.FALL:
                jumpTimer += Time.deltaTime;
                if (rb.velocity.y >= -15f) {
                    vect.y = -(gravity * Mathf.Pow(jumpTimer, 2f));
                } else {
                    vect.y = -15f;
                }
                break;

            default:
                Debug.Log("default");
                break;
        }

        //Debug.Log(jumpKey);
        //Debug.Log(sitn);

        rb.velocity = vect;
    }
}
