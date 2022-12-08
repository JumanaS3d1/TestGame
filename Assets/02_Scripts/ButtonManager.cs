using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonManager : MonoBehaviour
{

    public Button expButton;
    public static GameObject textButton;
    public static ButtonManager Instance;
    public static bool pressed = false;

    //public Button mole;
    //bool pressed = false;




    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateCanged;
        Instance = this;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateCanged;
    }

    private void GameManagerOnGameStateCanged(GameState state)
    {

        if (state == GameState.PressTime)
        {
            if (GameManager.Instance.scene.name == "Sample Scene")
            {
                pressed = true;
                expButton.interactable = false;
                expButton.GetComponent<Image>().color = Color.yellow;
            }
            if (GameManager.Instance.scene.name == "Enhanced Scene") {
                SoundManager.Instance.smashSound.Play();
                expButton.transform.position = GameManager.Instance.molePrefab.transform.position;
                expButton.GetComponent<Animator>().Play("HammerAnimation");
                pressed = true;
                expButton.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                expButton.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.scene.name == "Sample Scene")
        {
            textButton = expButton.transform.GetChild(0).gameObject;

        }
        if (GameManager.Instance.scene.name == "Enhanced Scene")
        {
            GameManager.Instance.startingPos = expButton.transform.position;
            expButton.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void OnClickButton()
    {

        if (!pressed)
        {
            GameManager.Instance.UpdateGameState(GameState.PressTime);
        }

    }
}
