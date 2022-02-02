using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject Settings;
    public GameObject Quit;
    // Start is called before the first frame update
    void Start()
    {
        Settings.SetActive(false);
        Quit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowSettings()
    {
        StartMenu.SetActive(false);
        Settings.SetActive(true);
        Quit.SetActive(false);
    }
    public void ShowQuit()
    {
        StartMenu.SetActive(false);
        Settings.SetActive(false);
        Quit.SetActive(true);
    }
    public void ShowMainMenu()
    {
        StartMenu.SetActive(true);
        Settings.SetActive(false);
        Quit.SetActive(false);
    }
    public void startMain()
    {
        SceneManager.LoadScene("Main game");
    }
}
