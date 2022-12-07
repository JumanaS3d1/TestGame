using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public float pressWaitingTime;
    public static float timeRemaining;
    InputDevice device;



    void Start()
    {
        pressWaitingTime = ConfigReader.experiences[ConfigReader.currentExperienceIndex].buttonPressedTimeMsec / 1000;
        timeRemaining = ConfigReader.experiences[ConfigReader.currentExperienceIndex].experimentTimeSeconds;
        device = InputDevice.hand;
        print("ASdasDASD"+ConfigReader.experiences[ConfigReader.currentExperienceIndex+1].getInputDevice());
        UpdateGameState(GameState.WaitTime);
    }

    void Awake()
    {
        Instance = this;
        //  print(ConfigReader.experiences.Count +ConfigReader.experiences[0].buttonPressedTimeMsec);
    }



    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //print(timeRemaining);
        }
        else
            UpdateGameState(GameState.ExperienceDone);

        if (device == InputDevice.keyboard)
        {

            if (Input.GetKeyDown(KeyCode.Space) && !ButtonManager.pressed)
            {
                print("keyboard");
                ButtonManager.Instance.expButton.onClick.Invoke();
            }
        }
        else if (device == InputDevice.hand)
        {
            print("hand");

            ButtonManager.Instance.expButton.onClick.Invoke();
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
            case GameState.PressTime:
                Invoke("HandlePressTime", pressWaitingTime);
                break;
            case GameState.ExperienceDone:
                HandleExperienceDone();
                break;
            default:
                break;
        }

        OnGameStateChanged(newState);

    }

    private void HandleExperienceDone()
    {
        EditorApplication.isPaused = true;
        //Application.Quit();

    }

    private void HandlePressTime()
    {
        ButtonManager.pressed = false;
        ButtonManager.Instance.expButton.interactable = enabled;
        ButtonManager.Instance.expButton.GetComponent<Image>().color = Color.white;
    }


    private void HandleWaitingTime()
    {

    }

    public enum GameState
    {
        WaitTime,
        PressTime,
        ExperienceDone
    }
}
