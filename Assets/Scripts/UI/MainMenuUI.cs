using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButtton;
    [SerializeField] private Button quitButtton;



    private void Awake()
    {
        playButtton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        quitButtton.onClick.AddListener(() =>
        {
            Application.Quit();
            
        });

        Time.timeScale = 1f;  
    }
}
