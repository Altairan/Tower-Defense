using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    public GameObject ui;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
        ui.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Debug.Log("Go To Menu");
    }
}
