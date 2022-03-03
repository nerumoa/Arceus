using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xRate;
    bool isSpace;
    bool beingSpace;
    bool isLMouse;
    bool isRMouse;


    public float GetXRate
    {
        get { return xRate; }
    }

    public bool GetIsSpace
    {
        get { return isSpace; }
    }

    public bool GetBeingSpace
    {
        get { return beingSpace; }
    }

    public bool GetIsLMouse
    {
        get { return isLMouse; }
    }

    public bool GetIsRMouse
    {
        get { return isRMouse; }
    }

    // Update is called once per frame
    void Update()
    {
        xRate       = Input.GetAxisRaw("Horizontal");
        isSpace     = Input.GetKeyDown("space");
        beingSpace  = Input.GetKey("space");
        isLMouse    = Input.GetMouseButtonDown(0);
        isRMouse    = Input.GetMouseButtonDown(1);
    }
}
