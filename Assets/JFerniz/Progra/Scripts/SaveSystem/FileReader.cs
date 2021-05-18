using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader : MonoBehaviour
{
    private const string fileName = "save.dat";

    private void Start()
    {
        ReadFile();
    }

    private void ReadFile()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);

        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            Debug.Log("Data: " + data);
        }
        else
        {
            Debug.LogWarning("No existe el archivo " + fileName);
        }
    }
}
