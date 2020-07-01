using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Walker myPrefab;
    public int timer = 200;
    public int roundTimer = 0;
    public int actualTimer = 50;
    public float speed = 0.3f;
    public int round = 1;
    public int enemies = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (roundTimer <= 0)
        {
            actualTimer--;
            if (actualTimer == 0)
            {
                enemies--;
                myPrefab.moveSpeed = Random.Range(speed, (speed + 1));
                Instantiate(myPrefab, new Vector2(-6.5f, 0f), Quaternion.identity);
                if (enemies == 0)
                {
                    round++;
                    enemies = round;
                    speed += 0.01f;
                    timer -= 10;
                    roundTimer = 300;
                }
                actualTimer = timer;
            }
        }
        else
            roundTimer--;
    }
}
