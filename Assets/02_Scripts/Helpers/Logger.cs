using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{
    private StreamWriter writer;
    private string filename;

    public Logger(string filename)
    {
        this.filename = filename;
        createLogFile(filename);
    }

    private void createLogFile(string filename)
    {
        this.writer = new StreamWriter("Assets/06_Logs/" + filename + ".txt", true);
    }

    public void log(float frameNumber, string triggetType)
    {
        string logMessage = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds() + " " + triggetType + " " + frameNumber;
        print(logMessage);
        this.log(logMessage);
    }

    private void log(string logMessage)
    {
        this.writer.WriteLine(logMessage + "\n");
        this.writer.Flush();
    }

}
