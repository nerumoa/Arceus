using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEnd : MonoBehaviour
{
    public void AnimationEnd()
    {
        Destroy(gameObject);
    }
}
