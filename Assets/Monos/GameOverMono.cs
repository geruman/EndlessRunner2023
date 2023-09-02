using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMono : MonoBehaviour
{
    [SerializeField] GameObject gameOverImage;
    [SerializeField] PlayerData playerData;
    [SerializeField] Text score;
    [SerializeField] Text loading;
    [SerializeField] HighScoreMono highScore;    
    [SerializeField] LeaderboardMono leaderboardMono;

    private Action updateBehaviour;

    void Awake()
    {
        if (IsNewHighScore())
        {
            highScore.onNameSet += ShowScores;
            updateBehaviour = highScore.SetHighScore;
            highScore.gameObject.SetActive(true);
        }
        else
        {
            gameOverImage.gameObject.SetActive(true);
            gameObject.SetActive(true);
            score.gameObject.SetActive(true);
            updateBehaviour = ReturnToGameScreenBehaviour;
            score.text = $"SCORE: {playerData.playerScore}";
        }
    }

    private bool IsNewHighScore()
        => playerData.playerScore > (ScoreData.Instance().leaderboard.LastOrDefault()?.score ?? 0);

    void Update()
    {
        updateBehaviour();
    }

    void ReturnToGameScreenBehaviour()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void ShowScores(string highScoreName)
    {
        updateBehaviour = () => { };           
        StartCoroutine(SaveHighScore(new Score(playerData.playerScore, highScoreName), playerData));
        updateBehaviour = ReturnToGameScreenBehaviour;
    }    
    
    public IEnumerator SaveHighScore(Score score, PlayerData playerData)
    {
        loading.gameObject.SetActive(true);
        highScore.gameObject.SetActive(false);
        string URL = "https://endless-runner-leaderboard.onrender.com/leaderboard";
            //"https://localhost:44367/" + "leaderboard";
        UnityWebRequest webRequest = new UnityWebRequest(URL, "POST");        
        UploadHandlerRaw uploadHandler = new UploadHandlerRaw(new UTF8Encoding().GetBytes(JsonConvert.SerializeObject(new UpdateLeaderBoardRequest(
            playerData.playerId,
            playerData.accessToken,
            score.playerName,
            score.score
        ))));
        uploadHandler.contentType = "application/json";
        webRequest.uploadHandler = uploadHandler;
        DownloadHandlerBuffer downloadHandler = new DownloadHandlerBuffer();
        webRequest.downloadHandler = downloadHandler;
        webRequest.SendWebRequest();
        while(!webRequest.isDone)
            yield return new WaitForEndOfFrame();
        if (!(webRequest.result == UnityWebRequest.Result.ConnectionError) 
            && !(webRequest.result == UnityWebRequest.Result.ProtocolError))
        {
            try
            {
                var wrappedResponse = "{\"leaderboard\":" + webRequest.downloadHandler.text + "}";
                ScoreData.Instance().leaderboard = JsonUtility.FromJson<LeaderboardWrapper>(wrappedResponse).leaderboard;
                
            }
            catch
            {
                ScoreData.Instance().leaderboard = new List<Score>() { new Score(0, "LINK ERROR") };                
            }
            finally
            {
                loading.gameObject.SetActive(false);
                gameOverImage.gameObject.SetActive(true);
                gameObject.SetActive(true);
                ScoreData.Instance().playerName = score.playerName;                
                leaderboardMono.gameObject.SetActive(true);
                leaderboardMono.InitializeLeaderboard(ScoreData.Instance().leaderboard);
            }
        }        
    }
}
