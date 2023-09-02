using UnityEngine;
using UnityEngine.UI;

public class ScoreEntryPrefab : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text[] playerName;

    public void SetScore(string scoreText) 
        => score.text = scoreText.PadLeft(12, '0');

    public void SetPlayerName(string playerNameText)
    {
        for (int i = 0; i < playerName.Length; i++)
        {
            playerName[i].text = playerNameText.Substring(i, 1);
        }
    }
}
