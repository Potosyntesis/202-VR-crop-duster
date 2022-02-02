using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamepausemenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject Settings;
    public GameObject Quit;
    public GameObject MainGameHud;
    public GameObject BuildingHud;
    public GameObject Spelldisplay;
    // Start is called before the first frame update
    void Start()
    {
        MainGameHud.SetActive(true);
        BuildingHud.SetActive(false);
        MainMenuPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
                MainMenuPanel.SetActive(true);
                MainGameHud.SetActive(false);
                BuildingHud.SetActive(false);
                Time.timeScale = 0.0f;
        }


    }
    public void ShowSettings()
    {
        MainMenuPanel.SetActive(false);
        BuildingHud.SetActive(false);
    }
   public void unpause()
    {
       
        MainMenuPanel.SetActive(false);
        BuildingHud.SetActive(false);
        MainGameHud.SetActive(true);
        Time.timeScale = 1.0f;
        
   }
    public void Main()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void BuildHud()
    {
        MainMenuPanel.SetActive(false);
        MainGameHud.SetActive(false);
        BuildingHud.SetActive(true);
        Time.timeScale = 1.0f;
    }
    public void SpellsHud()
    {
        MainMenuPanel.SetActive(false);
        MainGameHud.SetActive(true);
        BuildingHud.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
