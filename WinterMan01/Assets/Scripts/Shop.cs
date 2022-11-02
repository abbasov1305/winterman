using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    public AnimalState[] animals;
    private Transform spawnPoint;

    void Start(){
        shopPanel.SetActive(false);
        spawnPoint = gameObject.transform.GetChild(1);
    }
    public void PurchaseAnimal(int index){
        spawnPoint = gameObject.transform.GetChild(Random.Range(1,4));
        if(animals[index].price <= GameManager.instance.money){
            GameManager.instance.money -= animals[index].price;
            Instantiate(animals[index].animalPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    void EnableShop(){
        Cursor.visible = true;
        GameManager.instance.ShowCursorGFX(false);
        shopPanel.SetActive(true);
    }

    void DisableShop(){
        Cursor.visible = false;
        GameManager.instance.ShowCursorGFX(true);
        shopPanel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.CompareTag("Player")){
            EnableShop();
        }
    }

     void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            DisableShop();
        }
    }
}
