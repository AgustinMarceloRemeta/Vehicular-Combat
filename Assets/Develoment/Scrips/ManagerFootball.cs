using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerFootball : MonoBehaviour
{
    [SerializeField] GameObject End,CarNob,CarSina,Ball;
    [SerializeField] TextMeshProUGUI NobText, SinaText, WinnerText, TimeText;
    public int Nob = 0, Sina = 0; 
    [SerializeField] float TimeToFinish;
    [SerializeField] Transform InitNob, InitSina, InitBall;
    void Start()
    {
        Time.timeScale = 1;
    }


    void Update()
    {
        TimeToFinish -= Time.deltaTime;
        Text();
        NobText.text = Nob.ToString();
        SinaText.text = Sina.ToString();
        if(TimeToFinish<= 0)
        {
            End.SetActive(true);
            Time.timeScale = 0;
            if (Nob > Sina) WinnerText.text = "Ganador Newells";
            else if (Nob < Sina) WinnerText.text = "Ganador Central";
            else if (Nob == Sina) WinnerText.text = "Empate";
        }
        
    }
    void Text()
    {
        float minute = (TimeToFinish/ 60) - 1;
        if (TimeToFinish % 60 <= 30) minute += 1;
        float Seconds = TimeToFinish % 60;
        TimeText.text = minute.ToString("00") + ":" + ((int)Seconds).ToString("00");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }
    public void Menu() { SceneManager.LoadScene(0); }
    public void Goal()
    {
        CarNob.transform.position = InitNob.position;
        CarNob.transform.rotation = InitNob.rotation;
        CarSina.transform.position = InitSina.position;
        CarSina.transform.rotation = InitSina.rotation;
        Ball.transform.position = InitBall.position;
        Ball.transform.rotation = InitBall.rotation;
        Ball.GetComponent<Rigidbody>().Sleep();
        CarNob.GetComponent<Rigidbody>().Sleep();
        CarSina.GetComponent<Rigidbody>().Sleep();
    }
}
