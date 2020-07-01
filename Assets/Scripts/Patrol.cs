using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
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
            transform.Translate(Vector2.right * Time.deltaTime);
        else if (direction == 1)
            transform.Translate(Vector2.up * Time.deltaTime);
        else if (direction == 2)
            transform.Translate(Vector2.left * Time.deltaTime);
        else
            transform.Translate(Vector2.down * Time.deltaTime);
        if (onTile == true && tile.GetComponent<Tile>().walkable == false)
            Destroy(gameObject); //morir
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Tile") == true)
        {
            onTile = true;
            tile = other.gameObject;
            if (tile.GetComponent<Tile>().life > 0)
                tile.GetComponent<Tile>().life -= Random.Range(0f,0.3f);
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

}

