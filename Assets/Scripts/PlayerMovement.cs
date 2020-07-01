using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //controles: ^v<> x coger baldosa z reparar
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    private GameObject closestTile;
    public int tiletoutch = 0;
    public int state = 0;
    // 0 = normal
    // 1 = con baldosa
    // 2 = reparando
    public float tilelife = 0;
    Vector2 movement;
    /*Sound variables*/
    public AudioClip grab_tile;
    public AudioClip drop_tile;
    public AudioClip hammer_sound;
    public AudioSource source;

    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (state == 1)
            anim.SetBool("holding", true);
        else
            anim.SetBool("holding", false);

        closestTile = FindClosestTile();
        anim.SetBool("moving", true);
        anim.SetBool("repairing", false);
        if (movement.x == 0 && movement.y == 0)
            anim.SetBool("moving", false);

        if (state != 2) //si no esta reparando
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            anim.SetFloat("moveX", movement.x);
            anim.SetFloat("moveY", movement.y);

            if (tiletoutch > 0 && Input.GetKeyDown("x") && state == 0 && closestTile.GetComponent<Tile>().life >= 0
                && closestTile.GetComponent<Tile>().repairing == false)
            {
                source.Stop();
                source.PlayOneShot(grab_tile,7F);
                tilelife = closestTile.GetComponent<Tile>().getLife();
                closestTile.GetComponent<Tile>().setLife(-1);
                state = 1;
            }
            else if (tiletoutch > 0 && Input.GetKeyDown("x") && state == 1 && closestTile.GetComponent<Tile>().life < 0)
            {
                source.Stop();
                source.PlayOneShot(drop_tile,7F);
                closestTile.GetComponent<Tile>().setLife(tilelife);
                state = 0;
            }
            if (tiletoutch > 0 && state == 0 && Input.GetKeyDown("z") &&
                closestTile.GetComponent<Tile>().life < 5 && closestTile.GetComponent<Tile>().life != -1)
            {
                state = 2;
                source.PlayOneShot(hammer_sound, 7f);
            }
        }
        else //si esta reparando
        {
            anim.SetBool("repairing", true);
            movement.x = 0;
            movement.y = 0;
            closestTile.GetComponent<Tile>().repairValue -= Time.deltaTime;
            closestTile.GetComponent<Tile>().repair();
            if (closestTile.GetComponent<Tile>().repairValue == 0)
            {
                closestTile.GetComponent<Tile>().repairValue = 3;
                closestTile.GetComponent<Tile>().life++;
                if (closestTile.GetComponent<Tile>().life >= 5)
                    state = 0;
            }
            if (Input.GetKeyUp("z"))
            {
                source.Stop();
                state = 0;
            }

        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Tile") == true)
            tiletoutch++;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Tile") == true)
            tiletoutch--;
    }

    public GameObject FindClosestTile()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Tile");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}





