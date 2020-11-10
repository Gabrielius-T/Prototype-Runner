using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesController : MonoSingleton<ObstaclesController>
{
    List<Obstacle> obstacles;

    void Start()
    {
        obstacles = FindObjectsOfType<Obstacle>().ToList();
    }

    public void DisableAllObstacles()
    {
        foreach (Obstacle _obstacle in obstacles)
        {
            _obstacle.Disable();
        }
    }

    public void EnableAllObstacles()
    {
        foreach (Obstacle _obstacle in obstacles)
        {
            _obstacle.Enable();
        }
    }
}
