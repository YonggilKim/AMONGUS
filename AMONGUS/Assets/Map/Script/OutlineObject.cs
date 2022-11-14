using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color OutlineColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var inst = Instantiate(spriteRenderer.material);
        spriteRenderer.material = inst;
        spriteRenderer.material.SetColor("_OutlineColor",OutlineColor);
    }

    private void OnTriggerEnter(Collider collision)
    {
        var chracter = collision.GetComponent<ChracterMover>();
        if (chracter != null && chracter.hasAuthority)
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var chracter = collision.GetComponent<ChracterMover>();
        if (chracter != null && chracter.hasAuthority)
        {
            spriteRenderer.enabled = false;
        }    
    }
}
