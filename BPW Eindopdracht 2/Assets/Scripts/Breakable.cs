using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    private int health = 1000;

    public void Damage(){
        health--;
        if(health <= 0){
            Destroy(gameObject);
        }
    } 
}
