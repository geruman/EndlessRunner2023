using System.Collections.Generic;
using UnityEngine;

public class LeaderboardMono : MonoBehaviour
{
    [SerializeField] GameObject scoreEntryPrefab;

    public void InitializeLeaderboard(List<Score> scores)
    {
        foreach(var score in scores)
        {
            var prefab = Instantiate(scoreEntryPrefab);
            var comp = prefab.GetComponent<ScoreEntryPrefab>();
            comp.SetPlayerName(score.playerName);
            comp.SetScore(score.score.ToString());
            comp.GetComponent<RectTransform>().SetParent(transform, true);
        }
    }
}
