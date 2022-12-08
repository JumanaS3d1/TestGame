public static class InputDevice
{
    public const string keyboard = "keyboard";
    public const string hand = "hand";

    public static string getInputDeviceByName(string inputDeviceName)
    {
        switch (inputDeviceName)
        {
            case keyboard:
                return keyboard;
            case hand:
                return hand;
            default:
                break;
        }

        return "";
    }
}