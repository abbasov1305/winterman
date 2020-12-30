using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public float respawnTime = 2f;
    public float giftMoney = 400f;

    private ParticleSystem giftEffect;
    private SpriteRenderer sr;
    private BoxCollider2D col;

    void Start(){
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        giftEffect = gameObject.GetComponentInChildren<ParticleSystem>();
    }
   void OnCollisionEnter2D(Collision2D other){
       if(other.gameObject.CompareTag("Player")){
           StartCoroutine(Respawn());
       }
   }

   IEnumerator Respawn(){

        giftEffect.Play();
        sr.enabled = false;
        col.enabled = false;
        GameManager.instance.money += giftMoney;
        yield return new WaitForSeconds(respawnTime);
        giftEffect.Play();
        sr.enabled = true;
        col.enabled = true;

   }
}
