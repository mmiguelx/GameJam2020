using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public float life = 4f;
    public float repairValue = 0.5f;
    public bool walkable = true;
    public bool repairing = false;
    public Color defclr;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        defclr = this.GetComponent<SpriteRenderer>().color;
    }

    public void FixedUpdate()
    {
        anim.SetFloat("vida", life);
        if (life >= 4)
        {
            life = 4;
            repairing = false;
            repairValue = 0.5f;
        }
        if (life < 0 && life != -1f)
            life = 0;
        if (repairValue < 0)    //si ha llegado a reparar un tier
        {
            repairValue = 0.5f;
            life++;
        }
        if (repairing == true)
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        else
            this.GetComponent<SpriteRenderer>().color = Color.white;

        if (life <= 0 || repairing == true)
            walkable = false;
        else
            walkable = true;
    }

    public void setLife(float i)
    {
        life = i;
    }

    public float getLife()
    {
        return life;
    }

    public void repair()
    {
        if (life != 4 && life != -1)
            repairing = true;
    }
}
