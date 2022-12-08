using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonManager : MonoBehaviour
{
    string s1 = ProjectConsts.sampleExp;
    string s2 = ProjectConsts.sample2D;
    string s3 = ProjectConsts.sample3D;
    public Button expButton;
    public static GameObject textButton;
    public static ButtonManager Instance;
    public static bool pressed = false;




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
            pressed = true;
            if (GameManager.Instance.scene.name == s1)
            {
                expButton.interactable = false;
                expButton.GetComponent<Image>().color = Color.yellow;
            }
            if (GameManager.Instance.scene.name == s2) {
                SoundManager.Instance.smashSound.Play();
                expButton.transform.position = GameManager.Instance.molePrefab.transform.position;
                expButton.GetComponent<Animator>().Play("HammerAnimation");
                expButton.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                expButton.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            }
            if (GameManager.Instance.scene.name == s3) {
                GameManager.Instance.captin.GetComponent<Animator>().Play("Shoot");
                Rigidbody shot = Instantiate(GameManager.Instance.ball, GameManager.Instance.shootPos.position, GameManager.Instance.shootPos.rotation) as Rigidbody;
                shot.AddForce(GameManager.Instance.shootPos.forward * GameManager.Instance.shootingForce);
            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.scene.name == s1)
        {
            textButton = expButton.transform.GetChild(0).gameObject;

        }
        if (GameManager.Instance.scene.name == s2)
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
