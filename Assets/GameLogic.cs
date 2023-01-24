using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Standby,
    Paused,
    Running,
}

public class GameLogic : MonoBehaviour
{
    public GameState State = GameState.Standby;

    public Map map;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (State != GameState.Running)
            return;

    }
}
