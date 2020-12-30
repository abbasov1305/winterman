using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    public float respawnTime = 2f;

    private ParticleSystem snowmanEffect;
    private SpriteRenderer sr;
    private CircleCollider2D col;

    void Start(){
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
        snowmanEffect = gameObject.GetComponentInChildren<ParticleSystem>();
    }
   void OnCollisionEnter2D(Collision2D other){
       if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Snowball") || other.gameObject.CompareTag("Bullet") ){
           StartCoroutine(Respawn());
       }
   }

   IEnumerator Respawn(){

       snowmanEffect.Play();
       sr.enabled = false;
       col.enabled = false;
       yield return new WaitForSeconds(respawnTime);
       snowmanEffect.Play();
       sr.enabled = true;
       col.enabled = true;

   }
}
