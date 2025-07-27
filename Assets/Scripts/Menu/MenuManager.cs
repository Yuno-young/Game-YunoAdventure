using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public GameObject menuGame;
    public GameObject gamePlay;

    public GameObject gamePause;
    public GameObject gameFail;
    public GameObject gameSuccess;

    public bool isMusic;
    public GameObject[] mussicOff;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Time.timeScale = 0;
        isMusic = PlayerPrefs.GetInt("isMusic", 1) == 1;
        if (isMusic)
        {
            AudioListener.volume = 1;
            foreach (GameObject obj in mussicOff)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            AudioListener.volume = 0;
            foreach (GameObject obj in mussicOff)
            {
                obj.SetActive(true);
            }
        }
    }
    public void ButtonPlay()
    {
        Time.timeScale = 1;
        menuGame.SetActive(false);
        gamePlay.SetActive(true);

        GameManager.instance.LoadMap();
    }
    public void ButtonMusic()
    {
        isMusic = !isMusic;

        if (isMusic)
        {
            AudioListener.volume = 1;
            foreach (GameObject obj in mussicOff)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            AudioListener.volume = 0;
            foreach (GameObject obj in mussicOff)
            {
                obj.SetActive(true);
            }
        }
        PlayerPrefs.SetInt("isMusic", isMusic ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ButtonPause()
    {
        Time.timeScale = 0;
        gamePause.SetActive(true);
    }
    public void ButtonResume()
    {
        Time.timeScale = 1;
        gamePause.SetActive(false);
    }

    public void ButtonHome()
    {
        SceneManager.LoadScene(0);
    }
    public void GameFail()
    {
        Time.timeScale = 0;
        gameFail.SetActive(true);
    }
    public void ButtonRetry()
    {
        Time.timeScale = 1;
        gameFail.SetActive(false);

        GameManager.instance.LoadMap();
    }

    public void GameSuccess()
    {
        Time.timeScale = 0;
        gameSuccess.SetActive(true);

        PlayerPrefs.SetInt("level", GameManager.instance.level);
        PlayerPrefs.Save();
    }
    public void ButtonNext()
    {
        Time.timeScale = 1;
        gameSuccess.SetActive(false);
        GameManager.instance.level++;

        if (GameManager.instance.level <= 7)
        {
            GameManager.instance.LoadMap();
        }
        else
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
        }

    }




}
