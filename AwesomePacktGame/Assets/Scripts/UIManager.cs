using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Panel
{
    InGame,
    Pause
}

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<UIManager>();
        }

        return instance;
    }

    public Text message;
    private float messageTimer = 0;
    public GameObject messagePanel;
    public GameObject indicator;
    public GameObject inGamePanel;
    public GameObject pausePanel;
    public AudioSource source;
    public AudioClip messageBeep;

    public void OnQuit()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Quitting");
    }

    public void SetPanel(Panel type)
    {
        inGamePanel.SetActive(type == Panel.InGame);
        pausePanel.SetActive(type == Panel.Pause);
    }

    public void DisplayMessage(string msg, float msgTimer = 3)
    {
        source.PlayOneShot(messageBeep);
        messageTimer = msgTimer;
        messagePanel.SetActive(true);
        message.text = msg;
    }

    private void Update()
    {
        if(messageTimer <= 0)
        {
            messagePanel.SetActive(false);
        }
        else
        {
            messageTimer -= Time.deltaTime;
        }
    }
}
