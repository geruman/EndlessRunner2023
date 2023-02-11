using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxMono : MonoBehaviour
{
    
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += new Vector2(0.5f*Time.deltaTime, 0);
    }
}
