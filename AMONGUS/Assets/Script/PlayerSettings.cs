using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECtrlType { 
    Mouse,
    keyboardMouse
}
public class PlayerSettings : MonoBehaviour
{
    public static ECtrlType controlType;
    public static string nickname;

}
