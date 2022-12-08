using UnityEngine;

public class ConfigReader : MonoBehaviour
{

    private TextAsset configFile;
    public static ExperienceInfo _experience;


    void Start()
    {
        configFile = Utilities.LoadConfigFile();
        _experience = JsonUtility.FromJson<ExperienceInfo>(configFile.text);
    }

}
