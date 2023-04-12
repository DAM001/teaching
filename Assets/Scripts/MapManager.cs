using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static void NextMap()
    {
        OpenMap(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void OpenMap(int mapIdx)
    {
        if (mapIdx > SceneManager.sceneCountInBuildSettings + 1) mapIdx = SceneManager.GetActiveScene().buildIndex;
        if (mapIdx < 1) mapIdx = 0;

        SceneManager.LoadScene(mapIdx);
    }
}
