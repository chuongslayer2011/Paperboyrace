using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class GameState
{
    protected GameManager _gameManager;

    public GameState(GameManager _gameManager)
    {
        this._gameManager = _gameManager;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}

public class StartGameState : GameState
{

    public StartGameState(GameManager _gameManager) : base(_gameManager) { }


    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}

public class PlayGameState : GameState
{

    public PlayGameState(GameManager _gameManager) : base(_gameManager) { }


    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}

public class PauseGameState : GameState
{

    public PauseGameState(GameManager _gameManager) : base(_gameManager) { }


    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}

public class EndGameState : GameState
{

    public EndGameState(GameManager _gameManager) : base(_gameManager) { }


    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Execute()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }
}

