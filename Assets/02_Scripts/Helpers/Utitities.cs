using UnityEngine;

public static class Utilities
{

    public static TextAsset LoadConfigFile()
    {
        try
        {
            TextAsset configFile = Resources.Load<TextAsset>("Examples/config");
            return configFile;
        }
        catch (System.Exception)
        {
            Debug.LogError("Can't locate config file under Examples/");
            Application.Quit();
            throw;
        }
    }
}