using System;
using UnityEngine;

/// <summary>
/// This class will create clusters of obstacles gameObjects for the game.
/// </summary>
public class ObstacleFactory:MonoBehaviour
{
    [SerializeField] GameObject obstacleCluster1;
    [SerializeField] GameObject obstacleCluster2;

    void Awake()
    {
        
    }
    public void CreateObstacleCluster1At(Transform parentTransform)
    {
        Instantiate(obstacleCluster1, parentTransform);
    }

    public void CreateObstacleCluster2At(Transform parentTransform)
    {
        Instantiate(obstacleCluster2, parentTransform);
    }



}
