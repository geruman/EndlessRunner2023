using System;

[Serializable]
public struct UpdateLeaderBoardRequest
{
    public string playerId, accessToken, playerName;
    public int playerScore;

    public UpdateLeaderBoardRequest(string playerId, string accessToken, string playerName, int playerScore)
    {
        this.playerId = playerId;
        this.accessToken = accessToken;
        this.playerName = playerName;
        this.playerScore = playerScore;
    }
}