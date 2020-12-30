using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void Start(){
        Destroy(gameObject, 2f);
    }
    void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.CompareTag("Snowball")){
            other.gameObject.GetComponent<Snowball>().RemoveSnowball();
        }
        
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){

        gameObject.SetActive(false);
        
    }
}
