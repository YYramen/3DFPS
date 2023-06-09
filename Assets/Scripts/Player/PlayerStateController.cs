using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    None = 0,
    Move = 1,
    Grap = 2,
    Jump = 3,
    WallRun = 4,
    Inactive = 5,
}

public class PlayerStateController
{
    public static  PlayerStateController StateInstance = new PlayerStateController();

    PlayerState _state = PlayerState.Move;

    public PlayerState State { get => _state;}

    public void ChangePlayerState(PlayerState state)
    {
        _state = state;
    }
}
