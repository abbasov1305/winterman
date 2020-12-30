using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int animalCount = 0;
    public float money = 100f;
    public float moneyRate = 10f;
    public bool isGameOver;

    [Header("UI")]
    public GameObject GameOverPanel;

    public Text animalText;
    public Text moneyText;

    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
        }

        animalCount = 0;
    }

    void Start(){
        isGameOver = false;
        GameOverPanel.SetActive(false);
        
    }

    void Update(){

        money += animalCount * moneyRate * Time.deltaTime;
        animalText.text = "Animals " + animalCount.ToString();
        moneyText.text = "$" + money.ToString("0");

        if(animalCount <= 0){
            isGameOver = true;
            GameOverPanel.SetActive(true);
            Cursor.visible = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
