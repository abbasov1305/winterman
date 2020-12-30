using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Animal : MonoBehaviour
{
   public float speed = 2f;
   public float stoppingDistance = 0.5f;

   public float radius = 4f;
   public float health = 1f;
   public GameObject dieEffect;


   private Seeker skr;
   private Path path;
   private Rigidbody2D rb;
   private Vector2 target;
   private int pathIndex = 0;

   void Start(){
        skr = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("StartPath", 0f, 1f);

        GameManager.instance.animalCount++;
       
   }

    void StartPath(){
        if(!skr.IsDone()) return;

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D col in cols){
            if(col.gameObject.CompareTag("Player")){
                target = col.gameObject.transform.position;
                break;
            }else{
                target = new Vector2(Random.Range(-radius, radius), Random.Range(-radius, radius));
            }
        }

        pathIndex = 0;
        skr.StartPath(transform.position, target, OnPathCompleted);
        // AstarPath.active.Scan();
    }


   void OnPathCompleted(Path p){
        if(p == null) return;
        
        path = p;
   }

   void FixedUpdate(){

       if(path == null) return;
       
       if(pathIndex > path.vectorPath.Count - 1) return;

       Vector2 distance = path.vectorPath[pathIndex] - transform.position;
       if(distance.magnitude < stoppingDistance){
           pathIndex ++;
       }

       rb.AddForce(distance.normalized * speed * Time.fixedDeltaTime * 100f);

       if(rb.velocity.x > 0f){
           transform.localScale = new Vector3(1f, 1f, 1f);
       }else if(rb.velocity.y < 0f){
           transform.localScale = new Vector3(-1f, 1f, 1f);
       }
   }

   public void TakeDamage(float dmg){

       health -= dmg;
       if(health <= 0f){
           Die();
       }
   }

   void Die(){

       GameManager.instance.animalCount--;
    //    Debug.Log("Die");
       GameObject effectGO = Instantiate(dieEffect, transform.position, Quaternion.identity);
       Destroy(effectGO, 2f);
       Destroy(gameObject);
   }

   void OnDrawGizmosSelected(){
       Gizmos.color = Color.blue;
       Gizmos.DrawWireSphere(transform.position, radius);
   }

}
