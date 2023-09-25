using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardInitializer : MonoBehaviour
{
    private string URL = "https://endless-runner-leaderboard.onrender.com/";
    //"https://localhost:44367/"
    private float _waitingFor = 0;
    [SerializeField] GameObject welcomeImage;
    [SerializeField] GameObject loadingText;
    [SerializeField] GameObject loadingImage;
    async void Awake()
    {
        _waitingFor = 0;
        StartCoroutine("GetScoresAsync");
        Debug.Log("Leaderboard obtenido");
    }

    public IEnumerator GetScoresAsync()
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + "leaderboard");
        request.SendWebRequest();
        while (!request.isDone)
        {
            _waitingFor +=Time.deltaTime;
            if (_waitingFor>60)
            {
                ScoreData.Instance().leaderboard = new List<Score>() { new Score(0, "LINK ERROR") };
                loadingImage.SetActive(false);
                loadingText.SetActive(false);
                yield break;   
            }
            yield return new WaitForEndOfFrame();
        }
        loadingImage.SetActive(false);
        loadingText.SetActive(false);
        if (!(request.result == UnityWebRequest.Result.ConnectionError) && !(request.result == UnityWebRequest.Result.ProtocolError))
        {
            try
            {
                var wrappedResponse = "{\"leaderboard\":" + request.downloadHandler.text + "}";
                ScoreData.Instance().leaderboard = JsonUtility.FromJson<LeaderboardWrapper>(wrappedResponse).leaderboard;
            }
            catch(Exception ex)
            {
                ScoreData.Instance().leaderboard = new List<Score>() { new Score(0, "LINK ERROR") };
            }
        }
        Debug.Log(ScoreData.Instance().leaderboard);
    }
}

public class LeaderboardWrapper
{
    public List<Score> leaderboard;
}