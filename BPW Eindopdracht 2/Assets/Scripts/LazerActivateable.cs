using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LazerActivateable : MonoBehaviour
{
    public UnityEvent Activate;
    public UnityEvent Deactivate;
    SpriteRenderer spriteRenderer;
    float lastLazered;

    void Start(){
        Activate.AddListener(Active);
        Deactivate.AddListener(Deactive);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update(){
        Debug.Log(lastLazered + "lazered");
        if(lastLazered <= 0){
            StartCoroutine(ActivatorOff());
        }
        else{
            lastLazered -= .9f;
        }
    }

    public void Lazered(){
        Activate?.Invoke();
        lastLazered++;
    }

    IEnumerator ActivatorOff(){
        yield return new WaitForSeconds(1);
        Deactivate?.Invoke();
    }

    void Active(){
        spriteRenderer.color = Color.red;
    }

    void Deactive(){
        spriteRenderer.color = Color.gray;
    }
}
