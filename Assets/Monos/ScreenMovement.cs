using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ScreenMovement : MonoBehaviour
{
    [SerializeField]
    private SpeedData speedData;

    private Vector2 newPosition;
    private void Start()
    {
        newPosition =  transform.position;
    }
    void Update()
    {
        if(newPosition.x <= -18)
        {
            newPosition.x = 18f;
        }
        transform.position = newPosition;
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        Vector2 movement = new Vector2(-1 * speedData.speed * Time.fixedDeltaTime, 0);
        newPosition = pos+movement;

    }

}
