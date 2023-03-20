using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deur : MonoBehaviour
{
    [SerializeField]
    private float MaxY;
    [SerializeField]
    private float MinY;

    public void Open(){
        StartCoroutine(OpenCloseRoutine(true));
    }

    public void Close(){
        StartCoroutine(OpenCloseRoutine(false));
    }

    IEnumerator OpenCloseRoutine(bool open){
        if(open){
            while(MinY <= transform.localPosition.y){
            yield return new WaitForSeconds(.1f);
            transform.localPosition -= Vector3.down;
            }
        }
        else{
            while(MaxY >= transform.localPosition.y){
            yield return new WaitForSeconds(.1f);
            transform.localPosition -= Vector3.up;
            }
        }
    }
}
