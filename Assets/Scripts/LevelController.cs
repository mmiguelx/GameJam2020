using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
	public Walker walker;
	public Tile[] tiles;
	private int steps = 1;
	public Text text;
	private static int remake = 0;

	void Start()
	{
    	walker.moveSpeed = 1;
	}

	// Update is called once per frame
	void Update()
	{
    	if (remake > 0)
        	text.text = "Dont try to be god";

    	Debug.Log(steps);
    	if (steps == 1 && walker.transform.position.x > -3.5 && tiles[0].life < 4)
    	{
        	walker.moveSpeed = 0f;

        	text.text = "Walker can't go through broken or repairing tiles";

    	}
    	else if (steps == 1 && walker.transform.position.x > -3.5 && tiles[0].life == 4)
    	{
        	walker.moveSpeed = 1f;
        	steps = 2;
    	}

    	if (steps == 2 && walker.transform.position.x > 1.5 && tiles[1].life < 5 && tiles[2].life < 4)
    	{
        	walker.moveSpeed = 0f;
        	text.text = "Walker needs a tile to walk";
    	}
    	else if (steps == 2 && walker.transform.position.x > 1.5 && tiles[1].life == 4 && tiles[2].life == 4)
    	{
        	walker.moveSpeed = 1f;
        	steps = 3;
    	}

    	if (steps == 3)
    	{
        	text.text = "Walker show gratitude";
    	}

    	if (walker == null)
    	{
        	remake = 1;
        	SceneManager.LoadScene("tutorial");
    	}
        if (walker.transform.position.x > 8.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Input.GetKeyDown("escape"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}

}

