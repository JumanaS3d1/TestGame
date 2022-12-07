using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigReader : MonoBehaviour
{
    public TextAsset[] textJSON;

    public static List<ExperienceInfo> experiences = new List<ExperienceInfo>();
    public static int currentExperienceIndex = 0;


    void Start()
    {
        textJSON = Resources.LoadAll<TextAsset>("Examples/");
        //print(textJSON.ToString());
        for (int i = 0; i < textJSON.Length; i++)
        {
            ExperienceInfo expInfo = JsonUtility.FromJson<ExperienceInfo>(textJSON[i].text);
            experiences.Add(expInfo);
            print("Aasdasdasdasdasd bla bla"+expInfo.getInputDevice());
        }
        //print(experiences[currentExperienceIndex].buttonPressedTimeMsec);
        //GameManager.Instance.pressWaitingTime = experiences[currentExperienceIndex].buttonPressedTimeMsec/1000;
        print(experiences[currentExperienceIndex+1].buttonPressedTimeMsec);
        print(experiences[currentExperienceIndex + 1].getInputDevice());

        Logger logger = new Logger(experiences[currentExperienceIndex + 1].username);
        //logger.Logs("hello");
        //print(DateTime.Now);
    }

}
