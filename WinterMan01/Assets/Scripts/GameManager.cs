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

    public GameObject cursorGFX;

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

        cursorGFX.transform.position = Input.mousePosition;

        money += animalCount * moneyRate * Time.deltaTime;
        animalText.text = "Animals " + animalCount.ToString();
        moneyText.text = "$" + money.ToString("0");

        if(animalCount <= 0){
            isGameOver = true;
            GameOverPanel.SetActive(true);
            Cursor.visible = true;
            ShowCursorGFX(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    public void ShowCursorGFX(bool show)
    {
        cursorGFX.SetActive(show);
    }
}
