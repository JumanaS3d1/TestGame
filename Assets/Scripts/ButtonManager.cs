using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonManager : MonoBehaviour
{

    public Button expButton;
    private GameObject textButton;
    public static ButtonManager Instance;
    public static bool pressed = false;
    private Logger logger;

     static float framCountTrigger;
     static float frameCountButton;

    void Awake()
    {
        textButton = expButton.transform.GetChild(0).gameObject;
        GameManager.OnGameStateChanged += GameManagerOnGameStateCanged;
        Instance = this;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateCanged;
    }

    private void GameManagerOnGameStateCanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.WaitTime)
        {
            StartCoroutine(WaitTime());
        }

        if (state == GameManager.GameState.PressTime)
        {
            pressed = true;
            expButton.interactable = false;
            expButton.GetComponent<Image>().color = Color.yellow;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        this.logger = new Logger(ConfigReader.experiences[ConfigReader.currentExperienceIndex].getUserName());
        //print(ConfigReader.experiences[ConfigReader.currentExperienceIndex].getExperimentTimeSeconds());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClickButton()
    {
      
        if (!pressed)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.PressTime);
            frameCountButton = GameManager.timeRemaining;
            print(frameCountButton + "Button");
            this.logger.log(new DateTime(), frameCountButton, "BUTTON_PRESSED");

        }

    }

    IEnumerator WaitTime()
    {
        print("wait");
        textButton.SetActive(false);
        yield return new WaitForSeconds(Random.Range(.5f, 1.1f));
        textButton.SetActive(true);
        this.logger.log(new DateTime(),  121, "TRIGGER_APPEARED");
        framCountTrigger =  ConfigReader.experiences[ConfigReader.currentExperienceIndex].experimentTimeSeconds - GameManager.timeRemaining;
        framCountTrigger = GameManager.timeRemaining;
        print(framCountTrigger +"Trigger");

        yield return new WaitForSeconds(Random.Range(.5f, 1.1f));
        GameManager.Instance.UpdateGameState(GameManager.GameState.WaitTime);
    }




}
