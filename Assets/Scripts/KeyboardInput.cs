using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public bool iskeyboardPressed;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            iskeyboardPressed = true;
            print("space key was pressed");
        }
    }
}
