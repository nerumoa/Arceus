using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private ContactFilter2D ground = default;
    [SerializeField] private ContactFilter2D ceiling = default;
    bool isGround;
    bool isCeiling;

    [SerializeField] float speed = 8f;
    float xRate;

    int jumpCount = 0;
    float jumpTimer = 0f;
    const float jumpPower = 18f;
    const float gravity = 120f;
    bool isJumpKey = false;
    bool lockJumpKey = false;
    bool canDoubleJump = true;

    bool isRMouse;

    Rigidbody2D rb;
    Vector2 vect;
    PlayerController pc;
    Situation sitn = Situation.GROUND;

    enum Situation
    {
        GROUND,
        RISE,
        RISE_TWO,
        FALL,
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        xRate = pc.GetXRate();

        if (pc.GetIsRMouse()) {
            isRMouse = true;
        }

        // 地面と接触した場合
        if (sitn == Situation.FALL && isGround) {
            sitn = Situation.GROUND;
            jumpCount = 0;
            jumpTimer = 0f;
            lockJumpKey = true;
            canDoubleJump = true;
        }

        // ジャンプしようとした回数
        if (pc.GetIsSpace()) {
            jumpCount++;
        }

        // ジャンプの長さ
        if (pc.GetBeingSpace()) {
            // ロックが掛かっているならばJump判定を消す
            isJumpKey = !lockJumpKey;
        } else {
            isJumpKey = false;
            lockJumpKey = false;
        }

        isGround = rb.IsTouching(ground);
        isCeiling = rb.IsTouching(ceiling);
    }

    private void FixedUpdate()
    {
        // 横移動
        if (xRate != 0) {
            vect.x = xRate * speed;
        } else {
            vect.x = 0f;
        }

        if (isRMouse) {
            vect.x = xRate * speed * 10f;
            isRMouse = false;
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
                if (isJumpKey) {
                    sitn = Situation.RISE;
                }
                break;

            case Situation.RISE:
                jumpTimer += Time.deltaTime;
                if ((isJumpKey || jumpTimer < 0.03f) && jumpCount < 2) {
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
                if ((isJumpKey || jumpTimer < 0.03f) && jumpCount < 3) {
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
                vect.y = -(gravity * Mathf.Pow(jumpTimer, 2f));
                if (vect.y < -15f) {
                    vect.y = -15f;
                }
                break;

            default:
                Debug.Log("default");
                break;
        }

        rb.velocity = vect;
    }
}
