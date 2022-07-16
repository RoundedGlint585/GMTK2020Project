using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsDataLoader : MonoBehaviour
{
    public Dictionary<int, LevelsData.LevelData> ReadLevelsData()
    {
        var file = Resources.Load(path: "Levels", typeof(TextAsset)) as TextAsset;
        
        if(file == null)
        {
            throw new ApplicationException(message: "Levels file is not accessible!");
        }

        var levelsData = JsonUtility.FromJson<LevelsData>(file.text);

        return levelsData.levels.ToDictionary(level => level.number, level => level);
    }
}
