using System;
using System.Collections.Generic;
using System.Linq;

public class ScoreData
{
    public List<Score> leaderboard { get; set; }
    public int score;
    public string playerName;
    private static ScoreData _instance;
    public static ScoreData Instance() 
    {
        if (_instance == null)
        {
            _instance = new ScoreData();
        }
        return _instance;
    }
    private ScoreData() { }
}

[Serializable]
public class Score
{
    public int score;
    public string playerName;

    public Score(int score, string playerName)
    {
        this.score = score;
        this.playerName = playerName;
    }
}