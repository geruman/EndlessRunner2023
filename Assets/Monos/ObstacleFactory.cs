using System;
using UnityEngine;

/// <summary>
/// This class will create clusters of obstacles gameObjects for the game.
/// </summary>
public class ObstacleFactory:MonoBehaviour
{
    [SerializeField] GameObject[] obstacleClusters;
    

    void Awake()
    {
        
    }
    public void CreateObstacleClusterXAt(int index, Transform parentTransform)
    {
        Instantiate(obstacleClusters[index], parentTransform);
    }




}
