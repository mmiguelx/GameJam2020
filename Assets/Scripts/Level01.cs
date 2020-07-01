using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01 : MonoBehaviour
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
        {
            SceneManager.LoadScene("Level02");
        }
        if (Input.GetKeyDown("escape"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
