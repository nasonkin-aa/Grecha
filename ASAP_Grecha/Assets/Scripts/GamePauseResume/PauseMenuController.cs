using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;

        OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        gameObject.SetActive(newGameState == GameState.Paused);
    }
}
