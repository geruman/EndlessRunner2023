using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using System;

public class LeaderboardService : MonoBehaviour 
{
    private static string URL = "https://endless-runner-leaderboard.onrender.com/leaderboard";
        //"https://localhost:44367/";

    public static IEnumerator SaveHighScoreAsync(Score score, PlayerData playerData)
    {
        UnityWebRequest request = UnityWebRequest.Post(URL, JsonUtility.ToJson(new KeyValuePair<string, string>[]{
                new KeyValuePair<string, string>("playerId",playerData.playerId),
                new KeyValuePair<string, string>("accessToken",playerData.accessToken),
                new KeyValuePair<string, string>("playerName",score.playerName),
                new KeyValuePair<string, string>("playerScore", score.score.ToString())
                }));        
        request.SetRequestHeader("Content-Type", "application/json");
        request.SendWebRequest();
        while (!request.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        if (!(request.result == UnityWebRequest.Result.ConnectionError) && !(request.result == UnityWebRequest.Result.ProtocolError))
        {
            try
            {
                var wrappedResponse = "{\"leaderboard\":" + request.downloadHandler.text + "}";
                ScoreData.Instance().leaderboard = JsonUtility.FromJson<LeaderboardWrapper>(wrappedResponse).leaderboard;
            }
            catch (Exception ex)
            {
                //Mostrar error
                ScoreData.Instance().leaderboard = new List<Score>() { new Score(0, "LINK ERROR")};
            }
        }
    }
}