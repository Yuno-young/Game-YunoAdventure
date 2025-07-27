using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int level;
    public GameObject[] maps;

    public Text textLevel;
    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 120;
    }

    private void Start()
    {
        level = PlayerPrefs.GetInt("level", 1);
    }
    public void LoadMap()
    {
        if(level < 7)
        {
            textLevel.text = "LEVEL " + level;
        }
        else
        {
            textLevel.text = "FINAL MAP";
        }

        GameObject[] map = GameObject.FindGameObjectsWithTag("map");

        foreach(GameObject obj in map)
        {
            Destroy(obj);
        }

        int cout;
        cout = level - 1;

        Instantiate(maps[cout]);
    }

}
