using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    //Logger logger = new Logger("username")
    //logger.log =()

    private string filename;

    public Logger(string filename) {
        this.filename = filename;
        createLogFile(filename);
    }

    private void createLogFile(string filename)
    {
        throw new NotImplementedException();
        //create text file for the logs
    }

    public void Logs() {

        const string logMessage = "";
        this.logs(logMessage);
        
    }

    private void logs(string logMessage) { 
    // write the log message to this.filename
    }

}
