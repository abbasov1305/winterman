using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject spawner;

    [Header("Panels")]
    public GameObject menuPanel;
    public GameObject tutorialPanel;
    public GameObject gamePlayPanel;
    
    void Start(){

        Cursor.visible = true;
        menuPanel.SetActive(true);
        gamePlayPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        spawner.SetActive(false);
    }
    public void LoadScene(int index){

        SceneManager.LoadScene(index);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void Play(){

        tutorialPanel.SetActive(true);
        gamePlayPanel.SetActive(true);
        menuPanel.SetActive(false);
        spawner.SetActive(true);
        Cursor.visible = false;
    }

}
