using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float xRate;
    bool isSpace;
    bool beingSpace;
    bool isZkey;


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

    public bool GetIsZkey
    {
        get { return isZkey; }
    }

    // Update is called once per frame
    void Update()
    {
        xRate       = Input.GetAxisRaw("Horizontal");
        isSpace     = Input.GetKeyDown("space");
        beingSpace  = Input.GetKey("space");
        isZkey      = Input.GetKeyDown(KeyCode.Z);
    }
}
