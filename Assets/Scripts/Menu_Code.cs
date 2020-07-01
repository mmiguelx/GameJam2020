using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Code : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Tutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Level_1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void Level_2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void Level_3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }
      public void Level_Infinite()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void Close_Game()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
