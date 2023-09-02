using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerData",menuName ="Scriptable/Player")]
public class PlayerData : ScriptableObject
{
    public float jumpForce;
    public float doubleJumpForce;
    public float goingDownForce;
    public float delayForDoubleJumpAndDownActive;
    public int playerScore;
    public string playerId;
    public string accessToken;
}
