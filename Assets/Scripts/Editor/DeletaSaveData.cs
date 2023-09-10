using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DeletaSaveData
{
    [MenuItem("Data/Delete")]
    static void DeleteSaveDataJson()
    {
        var saveData = new PlayerSaveData(string.Empty, 0);
        JsonSaveUtility.Save(saveData);
    }
}
