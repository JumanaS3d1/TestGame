using UnityEngine;

public class ConfigReader : MonoBehaviour
{
    public bool readMyFile=false;
    public TextAsset configFile;
    public static ExperienceInfo _experience;


    void Start()
    {
        if (readMyFile)
        {
            _experience = JsonUtility.FromJson<ExperienceInfo>(configFile.text);
        }
        else
        {
            configFile = Utilities.LoadConfigFile();
            _experience = JsonUtility.FromJson<ExperienceInfo>(configFile.text);
        }
    }

}