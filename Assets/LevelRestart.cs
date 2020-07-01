using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    public Walker walker;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (walker == null)
            SceneManager.LoadScene("Level01");

        if (walker.transform.position.x > 8.5)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);

        if (Input.GetKeyDown("escape"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
