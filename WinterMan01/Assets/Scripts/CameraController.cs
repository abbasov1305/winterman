using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public ParticleSystem snowParticle;
    public float snowTime = 10f;

    void Start(){

        StartCoroutine(SnowEffect());
    }

    IEnumerator SnowEffect(){
        while(true){

            snowParticle.Play();
            yield return new WaitForSeconds(snowTime);
            snowParticle.Stop();
            yield return new WaitForSeconds(snowTime);

        }
    }

    void LateUpdate(){
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), 2f);
    }
}
