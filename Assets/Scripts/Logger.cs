using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{
    private StreamWriter writer;
    private string filename;

    //Logger logger = new Logger("username")
    //logger.log =()


    public Logger(string filename) {
        this.filename = filename;
        createLogFile(filename);
    }

    private void createLogFile(string filename)
    {
        this.writer = new StreamWriter("Assets/Logs/"+filename+".txt", true);

        //writer.Write(serializedData);
        //throw new NotImplementedException();
        //create text file for the logs
    }

    public void log(DateTime logTime, float frameNumber, string triggetType) {
        string logMessage = logTime + " " + triggetType + " " + frameNumber;
        print(logMessage);
        this.log(logMessage);
    }

    private void log(string logMessage) {
        try
        {
            using (this.writer)
            {
                writer.WriteLine(logMessage);
            }
        }
        catch (Exception exp)
        {
            Console.Write(exp.Message);
        }
    }

}
