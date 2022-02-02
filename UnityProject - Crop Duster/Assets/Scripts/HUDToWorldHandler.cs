using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HUDToWorldHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject ResouceTile;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        Instantiate(ResouceTile, Input.mousePosition, Quaternion.identity);
    }
}
