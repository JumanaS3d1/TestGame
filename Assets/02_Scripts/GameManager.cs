using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{ 
    public Scene scene;
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public static float timeRemaining;

    public GameObject molePrefab = null;
    public Transform[] Spwnerpoints = null;
    public Text gameText = null;
    public Vector3 startingPos = new Vector3(0,0,0);
    public GameObject thankYouImage= null;

    private float pressWaitingTime;
    private string inputDevice;
    private bool isLogging;

    public Logger logger;



    void Start()
    {
        scene = SceneManager.GetActiveScene();
        pressWaitingTime = ConfigReader._experience.buttonPressedTimeMsec / 1000;
        timeRemaining = ConfigReader._experience.experimentTimeSeconds;
        inputDevice = ConfigReader._experience.getInputDevice();
        isLogging = ConfigReader._experience.getIsLogging();

        if (isLogging)
        {
            logger = new Logger(ConfigReader._experience.getUserName());

        }
        UpdateGameState(GameState.WaitTime);
    }

    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        CalculateExperimentTime();
        HandleUserInput();
    }


    public void UpdateGameState(GameState newState)
    {
        UpdateButtonGameState(newState);
    }

    private void HandleWaitingTime()
    {
            StartCoroutine(WaitTime());      
    }
    private void HandleExperienceDone()
    {
        if (scene.name == "Enhanced Scene")
        {
            thankYouImage.SetActive(true);
            ButtonManager.Instance.expButton.gameObject.SetActive(false);
        }
        EditorApplication.isPaused = true;
        Application.Quit();
    }

    private void CalculateExperimentTime()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (scene.name == "Enhanced Scene")
            {
                gameText.text = timeRemaining.ToString();
            }
        }
        else
            UpdateGameState(GameState.ExperienceDone);
    }

    private void HandleUserInput()
    {
        if (inputDevice == InputDevice.keyboard && Input.GetKeyDown(KeyCode.Space) && !ButtonManager.pressed)
        {
            ButtonManager.Instance.expButton.onClick.Invoke();
        }
        else if (inputDevice == InputDevice.hand && !ButtonManager.pressed)
        {
            Hand handController = new Hand();
            if (handController.IsFingerSnap())
            {
                ButtonManager.Instance.expButton.onClick.Invoke();
            }
        }
    }
    private void HandlePressTime()
    {
        if(scene.name == "Sample Scene") { 
        ButtonManager.pressed = false;
        ButtonManager.Instance.expButton.interactable = enabled;
        ButtonManager.Instance.expButton.GetComponent<Image>().color = Color.white;
            }
        if (scene.name == "Enhanced Scene") {
            ButtonManager.pressed = false;
            ButtonManager.Instance.expButton.transform.position = startingPos;
            ButtonManager.Instance.expButton.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            ButtonManager.Instance.expButton.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    private void LogButtonPressed()
    {
        float frameCountButton = Time.frameCount ;
        if (isLogging)
            logger.log(frameCountButton, "BUTTON_PRESSED");

    }

    private void UpdateButtonGameState(GameState newState)
    {
        
            State = newState;
            switch (newState)
            {
                case GameState.WaitTime:
                    HandleWaitingTime();
                    break;
                case GameState.PressTime:
                    LogButtonPressed();
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

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(.1f);
        if (scene.name == "Sample Scene")
        {
            ButtonManager.textButton.SetActive(false);
            yield return new WaitForSeconds(Random.Range(.5f, 1.1f));
            ButtonManager.textButton.SetActive(true);
        }

        if (scene.name == "Enhanced Scene") {
            thankYouImage.SetActive(false);
            yield return new WaitForSeconds(Random.Range(.5f, 1.1f));
            GameObject mole = molePrefab;//Instantiate(molePrefab) as GameObject;
            mole.transform.position = Spwnerpoints[Random.Range(0, Spwnerpoints.Length)].transform.position;
        }

            float frameCountTrigger = Time.frameCount;
        if (isLogging)
            logger.log(frameCountTrigger, "TRIGGER_APPEARED");

        yield return new WaitForSeconds(Random.Range(.5f, 1.1f));
        UpdateGameState(GameState.WaitTime);
    }

}
