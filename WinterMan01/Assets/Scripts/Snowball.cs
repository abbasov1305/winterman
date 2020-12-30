using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float startScale = 0.1f;
    public float scaleSpeed = 0.01f;
    public float radius = 10f;
    public float minForce, maxForce;
    public GameObject snowballEffect;

    private float force;
    private TrailRenderer tr;
    private float rotationSpeed;
    private Rigidbody2D rb;
    private Transform target;

    void Start(){

        force = Random.Range(minForce, maxForce);

        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();

        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D col in cols){
            if(col.gameObject.CompareTag("Animal")){
                target = col.gameObject.transform;
                break;
            }
        }

        if(target == null){
            rb.velocity = -transform.position.normalized * force;
        }else{
            Vector2 dir = (Vector2)(target.position - transform.position).normalized;
            // rb.AddForce(dir * force);
            rb.velocity = dir * force;
        }

    }


    void LateUpdate(){

        rotationSpeed = rb.velocity.magnitude;
        if(rotationSpeed == 0f) return;

        startScale += scaleSpeed * rotationSpeed * Time.deltaTime;
        transform.localScale = new Vector3(startScale, startScale, 1);

        tr.startWidth = startScale * 0.6f;
    }

    public void RemoveSnowball(){

        GameObject effectGO = Instantiate(snowballEffect, transform.position, Quaternion.identity);
        Destroy(effectGO, 2f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Animal")){
            other.gameObject.GetComponent<Animal>().TakeDamage(1f);
        }else if(other.gameObject.CompareTag("Shop") || other.gameObject.CompareTag("Border")){
            RemoveSnowball();
        }

    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
