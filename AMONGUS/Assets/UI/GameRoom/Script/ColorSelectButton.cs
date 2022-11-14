using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelectButton : MonoBehaviour
{
    [SerializeField] private GameObject x;
    public bool isInteractable = true;

    public void SetIntertactable(bool value)
    {
        this.isInteractable = value;
        x.SetActive(value);
    }

}
