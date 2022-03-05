using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float GetXRate()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public bool GetIsSpace()
    {
        return Input.GetKeyDown("space");
    }

    public bool GetBeingSpace()
    {
        return Input.GetKey("space");
    }

    public bool GetIsLMouse()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool GetIsRMouse()
    {
        return Input.GetMouseButtonDown(1);
    }
}
