using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextTime;
    public float TimeToWin;
    [SerializeField] GameObject Win, Lose;
    CarController Player;
    void Start()
    {
        Time.timeScale = 1;
        Player = FindObjectOfType<CarController>();
    }


    void Update()
    {
        TimeToWin -= Time.deltaTime;
        Winner();
        Loser();
        Text();
    }
    void Winner()
    {
        if (TimeToWin <= 0)
        {
            Win.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void Loser()
    {
        if (Player.Life <= 0)
        {
            Time.timeScale = 0;
            Lose.SetActive(true);
        }
    }
    void Text()
    {
        float minute = (TimeToWin / 60)-1;
        if (TimeToWin% 60 <= 30) minute +=1;
        float Seconds = TimeToWin % 60;
        TextTime.text = minute.ToString("00") + ":" + ((int)Seconds).ToString("00");
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu() { SceneManager.LoadScene(0); }
}
