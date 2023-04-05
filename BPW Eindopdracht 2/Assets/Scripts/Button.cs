using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Button : MonoBehaviour
{
    public UnityEvent Activate;
    public UnityEvent Deactivate;
    public Sprite activeSprite;
    public Sprite inactiveSprite;
    SpriteRenderer spriteRenderer;
    float lastLazered;

    void Start(){
        Activate.AddListener(Active);
        Deactivate.AddListener(Deactive);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Deactivate?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("collided with " + other.name);
        Activate?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("stopped colliding with " + other.name);
        Deactivate?.Invoke();

    }

    private void OnTriggerStay2D(Collider2D other) {
        Activate?.Invoke();
    }

    void Active(){
        spriteRenderer.sprite = activeSprite;
    }

    void Deactive(){
        spriteRenderer.sprite = inactiveSprite;
    }
}
