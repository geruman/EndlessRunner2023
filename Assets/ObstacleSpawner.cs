using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private readonly double DEFAULT_SPAWN_TIME = 3;
    private double timeTillSpawn;
    [SerializeField] GameObject obstacle;
    [SerializeField] GameObject obstacleTall;
    [SerializeField] GameObject obstacleFly1;
    [SerializeField] GameObject obstacleLow1;
    [SerializeField][Range(0, 20)] float difference;
    // Start is called before the first frame update
    void Start()
    {
        timeTillSpawn = DEFAULT_SPAWN_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        timeTillSpawn -= Time.deltaTime;
        if (timeTillSpawn <= 0)
        {
            timeTillSpawn = DEFAULT_SPAWN_TIME;
            int random = Random.Range(1, 12);
            GameObject go;
            switch (random)
            {
                case 1:
                    go = Instantiate(obstacle);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y);
                    break;
                case 2:
                    go = Instantiate(obstacleTall);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y+1.2f);
                    break;
                case 3:
                    go = Instantiate(obstacleFly1);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y);
                    break;
                case 4:
                    go = Instantiate(obstacleFly1);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y+1f);
                    break;
                case 5:
                    go = Instantiate(obstacle);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y);
                    go = Instantiate(obstacleFly1);
                    go.transform.position = new Vector2(transform.position.x+5, transform.position.y);
                    break;
                case 6:
                    go = Instantiate(obstacleLow1);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y-1.1f);
                    break;
                case 8:
                    go = Instantiate(obstacle);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y);
                    go = Instantiate(obstacleTall);
                    go.transform.position = new Vector2(transform.position.x+3, transform.position.y+1.2f);
                    break;
                case 9:
                    go = Instantiate(obstacle);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y);
                    go = Instantiate(obstacleTall);
                    go.transform.position = new Vector2(transform.position.x+3, transform.position.y+1.2f);
                    go = Instantiate(obstacleFly1);
                    go.transform.position = new Vector2(transform.position.x+7, transform.position.y+1f);
                    break;
                case 10:
                    go = Instantiate(obstacleFly1);
                    go.transform.position = new Vector2(transform.position.x+6, transform.position.y+2);
                    go = Instantiate(obstacle);
                    go.transform.position = new Vector2(transform.position.x+3, transform.position.y);
                    go = Instantiate(obstacleFly1);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y-1f);
                    break;
                case 11:
                    go = Instantiate(obstacle);
                    go.transform.position = new Vector2(transform.position.x, transform.position.y);
                    go = Instantiate(obstacleTall);
                    go.transform.position = new Vector2(transform.position.x+3, transform.position.y+4);
                    go = Instantiate(obstacleFly1);
                    go.transform.position = new Vector2(transform.position.x+5, transform.position.y-1f);
                    
                    break;
            }
            
        }
    }
}
