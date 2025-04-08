using System;
using UnityEngine;
using UnityEngine.Events;
 
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onGameStart;
 
    [SerializeField]
    private UnityEvent onRespawnGame;
 
    [SerializeField]
    private UnityEvent onFinishGame;
    [SerializeField]
    private UnityEvent onLoseGame;
    [SerializeField]
    private UnityEvent onShowGameOverScreen;
    [SerializeField]
    private UnityEvent<int> onShowTimer;
    [SerializeField]
    private float secondsToRestart = 3f;
 
    [SerializeField]
    private float finalSecondsToRestart = 5f;
    [SerializeField]
    private float secondsToShowGameOverScreen = 3f;

    void Awake()
    {
        secondsToRestart += secondsToShowGameOverScreen;
        finalSecondsToRestart += secondsToShowGameOverScreen;
    }
    void Start()
    {
        onGameStart?.Invoke();
    }

    public void LoseGame()
    {
       onLoseGame?.Invoke();
       Invoke("ShowGameOverScreen", secondsToShowGameOverScreen);
    }
    private void ShowGameOverScreen()
    {
        onShowGameOverScreen?.Invoke();
        onShowTimer?.Invoke(3);
    }
 
    public void RespawnGame()
    {
         Invoke(("RestartGame"), secondsToRestart);
    }
 
    public void FinishGame()
    {
        onFinishGame?.Invoke();
        Invoke("Start", finalSecondsToRestart);
        Invoke("RestartGame", finalSecondsToRestart);
    }
    private void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
 