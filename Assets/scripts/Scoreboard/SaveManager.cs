using UnityEngine;
using System.IO;

public static class SaveManager
{
    public static string directory = "/ScoreData/";
    public static string FileName = "TestScoreboard.Dev";

    public static void Save(ScoreData SD)
    {
        string Path = Application.persistentDataPath + directory;

        if (!Directory.Exists(Path))
            Directory.CreateDirectory(Path);

        string json = JsonUtility.ToJson(SD);
        File.WriteAllText(Path + FileName, json);
    }

    public static ScoreData load()
    {
        string fullpath = Application.persistentDataPath + directory + FileName;
        ScoreData SD = new ScoreData();


        if (File.Exists(fullpath))
        {
            //Debug.LogWarning("path has been found");
            string json = File.ReadAllText(fullpath);
            SD = JsonUtility.FromJson<ScoreData>(json);
            //Debug.LogError(SD);
        }
        else
        {
            Debug.LogError("Save file does not excist");

        }

        return SD;
    }

}
