using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deur : MonoBehaviour
{
    private Collider2D doorCollider;
    private SpriteRenderer doorSprite;
    public float alpha = 0.2f;
    public float green = 1f;
    public float red = 0.4f;

    private void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorSprite = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        //zet collision uit, veranderd sprite color en alpha
        doorCollider.enabled = false;
        Color spriteColor = doorSprite.color;
        spriteColor.a = alpha;
        spriteColor.r = red;
        spriteColor.g = green;
        doorSprite.color = spriteColor;
    }

    public void Close()
    {
        //zet collision aan, veranderd sprite color en alpha
        doorCollider.enabled = true;
        Color spriteColor = doorSprite.color;
        spriteColor.a = 1f;
        spriteColor.r = 1f;
        spriteColor.g = 0;
        doorSprite.color = spriteColor;
    }
}
