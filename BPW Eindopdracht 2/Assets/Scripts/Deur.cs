using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deur : MonoBehaviour
{

    public void Open(){
        gameObject.SetActive(false);
    }

    public void Close(){
        gameObject.SetActive(true);
    }
}
