using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollider : MonoBehaviour
{
   private Animator anim;

   void Start(){
       anim = GetComponent<Animator>();
   }

//    void OnCollisionEnter2D(Collision2D other){
//        if(other.gameObject.CompareTag("Player")){
//            anim.SetTrigger("Shake");
//        }
//    }

   void OnTriggerEnter2D(Collider2D other){

       if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Snowball")
        || other.gameObject.CompareTag("Bullet")  || other.gameObject.CompareTag("Animal")){
           anim.SetTrigger("Shake");
       }
   }
}
