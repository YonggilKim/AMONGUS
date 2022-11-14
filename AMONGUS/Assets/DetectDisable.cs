using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDisable : MonoBehaviour
{
    private void OnDisable()
    {
        Debug.Log($"{gameObject.name}is disable" );
    }
}
