using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRGameUI : MonoBehaviour
{
    public GameObject BuildingHud;
    public GameObject SpellHud;
    // Start is called before the first frame update
    void Start()
    {
        BuildingHud.SetActive(true);
        SpellHud.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BuildHud()
    {
        BuildingHud.SetActive(true);
        SpellHud.SetActive(false);

        Time.timeScale = 1.0f;
    }
    public void SpellsHud()
    {
        SpellHud.SetActive(true);
        BuildingHud.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
