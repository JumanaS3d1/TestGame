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

    void Awake()
    {
        textButton = expButton.transform.GetChild(0).gameObject;
        textButton.SetActive(false);
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

        if (state == GameManager.GameState.PressEnabled) {
            expButton.interactable = true;
            pressed = false;
            textButton.SetActive(true);
        }

        //expButton.interactable = state == GameManager.GameState.PressEnabled;

        if (state == GameManager.GameState.PressTime) {
            pressed = true;
            expButton.interactable = false;
            expButton.GetComponent<Image>().color = Color.yellow;
            //expButton.GetComponent<Image>().color = Color.yellow;//new Color(248, 131, 121);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        print(ConfigReader.experiences[ConfigReader.currentExperienceIndex].experimentTimeSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if ((GameManager.pressState== true))
        {
            if (Input.GetKeyDown(KeyCode.Space) && (pressed == false))
            {
                print("ButtonPressed");
              expButton.onClick.Invoke();
            }
        }
        */
    }

    public void OnClickButton()
    {
        if (!pressed)
        {
            pressed = true;
            expButton.interactable = false;
            GameManager.Instance.UpdateGameState(GameManager.GameState.PressTime);
        }
    }

    IEnumerator WaitTime()
    {
        //pressed = true;
        //expButton.interactable = false;
        //expButton.GetComponent<Image>().color = Color.white;
        //textButton.SetActive(false);
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        textButton.SetActive(true);
        //GameManager.Instance.UpdateGameState(GameManager.GameState.PressEnabled);

    }


}
