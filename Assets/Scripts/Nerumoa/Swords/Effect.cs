using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    float deathTime = 0.25f;
    float countTime = 0f;

    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime >= deathTime) {
            Destroy(gameObject);
        }
    }
}
