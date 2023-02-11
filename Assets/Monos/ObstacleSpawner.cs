using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private readonly double DEFAULT_SPAWN_TIME = 5;
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
        timeTillSpawn = 0;
        nextSpawn = new Queue<int>();
    }

    // Update is called once per frame
    void Update()
    {
        timeTillSpawn -= Time.deltaTime;
        GetKeyForNextSpawn();

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
                        
                        obstacleFactory.CreateObstacleCluster1At(transform);
                        break;
                    case 2:
                        obstacleFactory.CreateObstacleCluster2At(transform);
                        break;
                    case 3:
                        go = Instantiate(obstacle3);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y);
                        break;
                    case 4:
                        go = Instantiate(obstacle4);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y);
                        break;
                    case 5:
                        go = Instantiate(obstacle5);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y);
                        break;
                    case 6:
                        go = Instantiate(obstacle6);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y);
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
