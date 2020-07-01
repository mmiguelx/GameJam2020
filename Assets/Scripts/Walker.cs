using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Walker : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    private GameObject tile;
    private bool onTile = false;
    public int direction = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0)
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        else if (direction == 1)
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
        else if (direction == 2)
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        else
            transform.Translate(Vector2.down * Time.deltaTime * moveSpeed);
        if (onTile == true && tile.GetComponent<Tile>().walkable == false)
            lose();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Tile") == true)
        {
            onTile = true;
            tile = other.gameObject;
            if (tile.GetComponent<Tile>().life > 0)
                tile.GetComponent<Tile>().life -= Random.Range(0.5f, 1f);
            else
                lose();
        }

        if (other.gameObject.tag.Equals("End") == true)
        {
            //punto
            Destroy(gameObject);
        }
                if (other.gameObject.tag.Equals("WayPoint") == true)
        {
            //cambio de dirección
            direction = other.gameObject.GetComponent<WayPoint>().direction;
        }
    }
    void lose()
    {
        Destroy(gameObject);
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

}
