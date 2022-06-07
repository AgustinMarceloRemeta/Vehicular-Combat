using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    void Start()
    {
        
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
}
