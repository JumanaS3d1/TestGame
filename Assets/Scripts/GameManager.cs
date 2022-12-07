using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public static bool pressState=false;
    //buttonPressedTimeMsec
    float pressWaitingTime = 10f;

    //EnabledTime
    public float timeToRemainEnabled=1f;
    private float currentWaitTime;
    private bool checkTime;

    void Awake()
    {
        Instance = this;

    }

    void Start()
    {
        UpdateGameState(GameState.WaitTime);
    }

    void Update()
    {

        if (pressState == true)
        {
            
            if (checkTime)
            {
                currentWaitTime -= Time.deltaTime;
                if (currentWaitTime < 0)
                {
                    UpdateGameState(GameState.WaitTime);
                    checkTime = false;
                }
            }  

            if (Input.GetKeyDown(KeyCode.Space) && (!ButtonManager.pressed))
            {
                print("ButtonPressed" + ButtonManager.pressed);
                ButtonManager.Instance.expButton.onClick.Invoke();
            }
        }

    }


    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.WaitTime:
                HandleWaitingTime();
                break;
            case GameState.PressEnabled:
                HandlePressEnabled();
                break;
            case GameState.PressTime:
                Invoke("HandlePressTime",pressWaitingTime);
                break;
            case GameState.PressDisabled:
                break;
            case GameState.ExperienceDone:
                break;
            default:
                break;
        }

        OnGameStateChanged(newState);
      //  OnGameStateChanged?.Invoke(newState);

    }

    private void HandlePressTime()
    {
        UpdateGameState(GameState.WaitTime);
    }

    private void HandlePressEnabled()
    {
        pressState = true;
        currentWaitTime = timeToRemainEnabled;
        checkTime = true;
    }

    private void HandleWaitingTime()
    {
        pressState = false;
    }

    public enum GameState {  
    WaitTime, // showText
   // Pressed,
    PressEnabled,
    PressTime,
    PressDisabled,
    ExperienceDone
    }
}
