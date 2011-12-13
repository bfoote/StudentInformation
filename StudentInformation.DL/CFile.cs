using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace StudentInformation.DL
{
    public class CFile
    {
        string _sFileName;
    
    // Create a constructor
    public CFile()
    {
        // Add a new listener to the class
        TextWriterTraceListener tr = new TextWriterTraceListener(System.Console.Out);
        Debug.Listeners.Add(tr);
        _sFileName = @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "CStudents.txt";
    }

    public bool Write(string sOutput)
    {
        StreamWriter oSW = File.AppendText(_sFileName);
        Debug.WriteLine(DateTime.Now.ToString() + "|" + sOutput);
        oSW.WriteLine(DateTime.Now.ToString() + "|" + sOutput);
        oSW.Close();
        oSW.Dispose();
        oSW = null;
        return true;
    }
    public void Delete()
    { 
        // If the file exists, delete it.
        if (File.Exists(_sFileName))
        {
            File.Delete(_sFileName);
        }
    }

    public string Read()
    {
        // Read the text file and return the contents.
        StreamReader oSR = File.OpenText(_sFileName);
        string sOutput = oSR.ReadToEnd();
        oSR.Close();
        oSR.Dispose();
        oSR = null;
        return sOutput;

    }


    }

}
