using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScalerMono : MonoBehaviour
{
    private float _previousTimeScale = 1;
    private float timeSpent;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        timeSpent = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
        if (timeSpent > 60)
        {
            Time.timeScale = 1.1f;
        }
        if (timeSpent > 90)
        {
            Time.timeScale = 1.2f;
        }
        if (timeSpent > 120)
        {
            Time.timeScale = 1.3f;
        }
        if (timeSpent > 150)
        {
            Time.timeScale = 1.4f;
        }
        if (timeSpent > 180)
        {
            Time.timeScale = 1.5f;
        }
        if (timeSpent > 210)
        {
            Time.timeScale = 1.6f;
        }


    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Time.timeScale = _previousTimeScale;
        }
        else
        {
            _previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
    }
}
