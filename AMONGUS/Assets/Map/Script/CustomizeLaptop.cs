using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeLaptop : MonoBehaviour
{
    [SerializeField] private Sprite useButtonSprite;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        var inst = Instantiate(spriteRenderer.material);
        spriteRenderer.material = inst;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var chracter = col.GetComponent<ChracterMover>();
        if (chracter != null && chracter.hasAuthority)
        {
            spriteRenderer.material.SetFloat("_Highlighted", 1f);
            LobbyUIManager.Instance.SetUseButton(useButtonSprite, OnClickuse);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        var chracter = col.GetComponent<ChracterMover>();
        if (chracter != null && chracter.hasAuthority)
        {
            spriteRenderer.material.SetFloat("_Highlighted", 0f);
            LobbyUIManager.Instance.UnsetUseButton();

        }
    }
    public void OnClickuse()
    {
        LobbyUIManager.Instance.CustomizeUI.Open();
    }
}
