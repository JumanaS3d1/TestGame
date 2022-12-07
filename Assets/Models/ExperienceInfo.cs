
public class ExperienceInfo
{
    public string username;
    public string inputDevice;
    public float buttonPressedTimeMsec;
    public float experimentTimeSeconds;
    public bool isLogging;


    public string getUserName()
    {
        return this.username;
    }

    public string getInputDevice()
    {
        return this.inputDevice;
    }
    public float getButtonPressedTimeMsec()
    {
        return this.buttonPressedTimeMsec;
    }
    public float getExperimentTimeSeconds()
    {
        return this.experimentTimeSeconds;
    }
    public bool getIsLogging()
    {
        return this.isLogging;
    }

    public void setUserName(string username)
    {
        this.username = username;
    }

    public void setInputDevice(string inputDevice)
    {
        this.inputDevice = inputDevice;
    }
    public void setButtonPressedTimeMsec(float buttonPressedTimeMsec)
    {
        this.buttonPressedTimeMsec = buttonPressedTimeMsec;
    }
    public void setExperimentTimeSeconds(float experimentTimeSeconds)
    {
        this.experimentTimeSeconds = experimentTimeSeconds;
    }
    public void setIsLogging(bool isLogging)
    {
        this.isLogging = isLogging;
    }

}