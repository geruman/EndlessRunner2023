using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;



public class ObstacleSpawner : MonoBehaviour
{
    private readonly float DEFAULT_SPAWN_TIME = 2;
    private double timeTillSpawn;
    [SerializeField] GameObject obstacle1;
    [SerializeField] GameObject obstacle2;
    [SerializeField] GameObject obstacle3;
    [SerializeField] GameObject obstacle4;
    [SerializeField] GameObject obstacle5;
    [SerializeField] GameObject obstacle6;
    [SerializeField] GameObject obstacle7;
    [SerializeField] GameObject obstacle8;
    [SerializeField][Range(0, 20)] float difference;
    private Queue<int> nextSpawn;
    // Start is called before the first frame update
    private ObstacleFactory obstacleFactory;
    private void Awake()
    {
        obstacleFactory = GetComponent<ObstacleFactory>();
    }
    void Start()
    {
        
        nextSpawn = new Queue<int>();
        InvokeRepeating("RandomizeAndSpawn", DEFAULT_SPAWN_TIME, DEFAULT_SPAWN_TIME);
    }

    // Update is called once per frame
    void Update()
    {
       
            
    }

    private void RandomizeAndSpawn()
    {
        int randomValue = Random.Range(0, 7);
        SelectForQueue(randomValue);
    }

    private void FixedUpdate()
    {
        //if (timeTillSpawn <= 0)
        if (true)
        {
            if (nextSpawn.Count>0)
            {
                GameObject go;
                timeTillSpawn = DEFAULT_SPAWN_TIME;
                switch (nextSpawn.Dequeue())
                {
                    case 1:

                        obstacleFactory.CreateObstacleClusterXAt(0, transform);
                        break;
                    case 2:
                        obstacleFactory.CreateObstacleClusterXAt(1, transform);
                        break;
                    case 3:
                        obstacleFactory.CreateObstacleClusterXAt(2, transform);
                        break;
                    case 4:
                        obstacleFactory.CreateObstacleClusterXAt(3, transform);
                        break;
                    case 5:
                        obstacleFactory.CreateObstacleClusterXAt(4, transform);
                        break;
                    case 6:
                        obstacleFactory.CreateObstacleClusterXAt(5, transform);
                        break;
                    case 7:
                        go = Instantiate(obstacle7);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y);
                        break;
                    case 8:
                        go = Instantiate(obstacle8);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y);
                        break;

                }
            }





        }
    }

    private void GetKeyForNextSpawn()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectForQueue(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectForQueue(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectForQueue(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectForQueue(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectForQueue(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectForQueue(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectForQueue(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SelectForQueue(8);
        }
    }

    private void SelectForQueue(int numberTospawn)
    {
        if (nextSpawn.Count>0)
        {
            nextSpawn.Dequeue();

        }
        nextSpawn.Enqueue(numberTospawn);
    }
}
