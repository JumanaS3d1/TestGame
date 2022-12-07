using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
   
    public bool IsKeyboardPressed() {
        print("fdgdfgdf");
        return Input.GetKeyDown(KeyCode.Space); 
    }
}
