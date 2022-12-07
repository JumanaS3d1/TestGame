using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigReader : MonoBehaviour
{
    public TextAsset[] textJSON;

    [System.Serializable]
    public class ExperienceInfo
    {
        public string username;
        public string inputDevice;
        public float buttonPressedTimeMsec;
        public float experimentTimeSeconds;
        public bool isLogging;
    }

    public static List<ExperienceInfo> experiences = new List<ExperienceInfo>();
    public static int currentExperienceIndex = 0;

    void Start()
    {
        textJSON = Resources.LoadAll<TextAsset>("Examples/");
        print(textJSON.ToString());
        for (int i = 0; i < textJSON.Length; i++)
        {
            ExperienceInfo expInfo = JsonUtility.FromJson<ExperienceInfo>(textJSON[i].text);
            experiences.Add(expInfo);
        }
    }
}
