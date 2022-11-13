using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingSprite : MonoBehaviour
{
    public enum EsortingType
    {
        Static,Update
    }

    [SerializeField] private EsortingType sortingType;

    private SpriteSorter sorter;

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        sorter = FindObjectOfType<SpriteSorter>();
        spriteRenderer = FindObjectOfType<SpriteRenderer>();
        spriteRenderer.sortingOrder = sorter.GetSortingOrder(gameObject);
        if (gameObject.name.Contains("box"))
        {
            Debug.Log($"{gameObject.name}'s order is {spriteRenderer.sortingOrder}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sortingType == EsortingType.Update)
        {
            spriteRenderer.sortingOrder = sorter.GetSortingOrder(gameObject);
        }
    }
}
