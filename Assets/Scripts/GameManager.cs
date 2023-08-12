using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public bool isGameOver = false;
    void Start()
    {
        Time.timeScale = 1;
    }

    
    void Update()
    {
        
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
        Time.timeScale = 0;
    }
}
