using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject Qs1, Qs2;
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        transform.Rotate(0, 20*Time.deltaTime, 0);
    }
     public void Fulbito()
    {
        SceneManager.LoadScene(2);
    }
     public void Survival()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Question1()
    {
        Qs1.SetActive(!Qs1.activeSelf);
    } 
    public void Question2()
    {
        Qs2.SetActive(!Qs2.activeSelf);
    }
}
