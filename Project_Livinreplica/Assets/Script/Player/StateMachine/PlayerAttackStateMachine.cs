using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackStateMachine : PlayerStateMachine
{
    public Player Player { get; }
    public PlayerReusableStateData ReusableData { get; }

    public PlayerAttackStateMachine(Player player)
    {
        Player = player;
        ReusableData = new PlayerReusableStateData();
    }
}
