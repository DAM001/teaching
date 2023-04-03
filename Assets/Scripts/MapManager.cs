using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    private static int _currentMapIdx = 0;

    private void Start()
    {
        _currentMapIdx = SceneManager.GetActiveScene().buildIndex;
    }

    public static void NextMap()
    {
        _currentMapIdx++;
        OpenMap(_currentMapIdx);
    }

    public static void OpenMap(int mapIdx)
    {
        if (SceneManager.sceneCount < mapIdx + 1) _currentMapIdx = SceneManager.sceneCount;
        else if (mapIdx < 1) _currentMapIdx = 0;
        else _currentMapIdx = mapIdx;

        SceneManager.LoadScene(_currentMapIdx);
    }
}
