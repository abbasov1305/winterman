using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2f;
    public Transform shootPoint;
    public GameObject[] bulletPrefabs;
    public float bulletSpeed = 10f;


    private Rigidbody2D rb;
    private Camera cam;
    private Animator anim;
    private Vector2 mousePos;
    private Vector2 dir;
    private GameObject bulletPrefab;

    void Start(){
        
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        anim = GetComponent<Animator>();

        bulletPrefab = bulletPrefabs[Random.Range(0, bulletPrefabs.Length)];

        // Cursor.visible = false;

    }

    void Update(){

        if(GameManager.instance.isGameOver) return;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        dir = mousePos - rb.position;
        // transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);

        if(Input.GetMouseButton(0)){
            rb.AddForce(dir.normalized * movementSpeed * Time.deltaTime * 100f);
        }

        if(Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }

        anim.SetFloat("ValueX", dir.normalized.x);
        anim.SetFloat("ValueY", dir.normalized.y);
    }
     
    void Shoot(){

        GameObject bulletGO =Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bulletGO.GetComponent<Rigidbody2D>().velocity = dir.normalized * bulletSpeed;
    }
}
