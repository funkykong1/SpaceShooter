using UnityEngine;
//these three needed for The Process
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

//nay monobehaviour + static
public static class SaveLoad
{
    private static string fileName = "SaveData.txt";
    private static string directoryName = "SaveData";
    public static void saveState(SaveObject so)
    {
        if(!DirectoryExists())
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directoryName);
        //if statement only applies to the first(?) line of code



        //save function every time when function called
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetSavePath());
        bf.Serialize(file, so);
        //closing the file prevents errors
        file.Close();
        

    }

    public static SaveObject LoadState()
    {

        SaveObject so = new SaveObject();

        if(SaveExists())
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(GetSavePath(), FileMode.Open); 
                //(SaveObject) is being cast before deserialization, prevents error here
                so = (SaveObject)bf.Deserialize(file);
                file.Close();
            }
            catch (SerializationException)
            {
                Debug.LogWarning("Failed to load save");
            }
        }

        return so;
    }



    private static bool SaveExists()
    {
        return File.Exists(GetSavePath());
    }

    private static bool DirectoryExists()
    {
        //Directory is Sys.IO, Application is UnityEngine
        return Directory.Exists(Application.persistentDataPath + "/" + directoryName);
    }

    private static string GetSavePath()
    {
        return Application.persistentDataPath + "/" + directoryName + "/" + fileName;
    }
}
