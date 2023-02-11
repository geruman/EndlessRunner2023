using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MystController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        _spriteRenderer.sortingOrder = -1;
    }

}
