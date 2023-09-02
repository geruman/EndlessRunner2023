using UnityEngine;
using UnityEngine.UI;

public class ScoreMono : MonoBehaviour
{
    [SerializeField] Text scoreText;
    public float _score = 0f;    

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _score += Time.deltaTime*5;
        scoreText.text = ((int)_score).ToString().PadLeft(10, '0');
    }
}
