using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementMono : MonoBehaviour
{
    [SerializeField] SpeedData obstacleSpeedData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x-obstacleSpeedData.speed*Time.deltaTime, transform.position.y);
    }
}
