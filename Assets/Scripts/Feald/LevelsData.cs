using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelsData
{
     public LevelData[] levels;

    [Serializable]
    public class LevelData
    {
        public int number;
        public string size;
        public int[] green;
        public int[] blue;
        public int[] red;
        public int[] yellow;
        public int[] purple;
        public int[] orange;
        public int[][] avoid;
        public int[] monstr;
        public int[] wall;
    }
}
