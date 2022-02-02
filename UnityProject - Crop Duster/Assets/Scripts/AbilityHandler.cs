using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using EZCameraShake;

public class AbilityHandler : MonoBehaviour, IPointerDownHandler
{
    private int chance;
    private GameObject[] buildingAmount;

    private void Start()
    {
        buildingAmount = GameObject.FindGameObjectsWithTag("Building");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buildingAmount = GameObject.FindGameObjectsWithTag("Building");

        CameraShaker.Instance.ShakeOnce(6f, 6f, 4f, 4f);

        Debug.Log(buildingAmount);
        for (int i = 0; i < buildingAmount.Length; i++)
        {
            chance = Random.Range(1, 4);
            Debug.Log(chance);
            if(chance == 1)
            {
                Destroy(buildingAmount[i]);
            }

        }
    }

}
