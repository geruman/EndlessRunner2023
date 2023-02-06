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
    [SerializeField][Range(0, 20)] float difference;
    private Queue<int> nextSpawn;
    // Start is called before the first frame update
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
        if (timeTillSpawn <= 0)
        {
            if (nextSpawn.Count>0)
            {
                GameObject go;
                timeTillSpawn = DEFAULT_SPAWN_TIME;
                switch (nextSpawn.Dequeue())
                {
                    case 1:
                        go = Instantiate(obstacle1);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y+1.3f);
                        break;
                    case 2:
                        go = Instantiate(obstacle2);
                        go.transform.position = new Vector2(transform.position.x+10, transform.position.y+2.3f);
                        break;
                    case 3:
                        go = Instantiate(obstacle3);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y+3f);
                        break;
                    case 4:
                        go = Instantiate(obstacle4);
                        go.transform.position = new Vector2(transform.position.x, transform.position.y+1f);
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
