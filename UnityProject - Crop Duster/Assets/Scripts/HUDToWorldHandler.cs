using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HUDToWorldHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject ResouceTile;
    Pointer pointer;

    private void Awake()
    {
        pointer = GameObject.Find("PR_Pointer").GetComponent<Pointer>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        Instantiate(ResouceTile, Input.mousePosition, Quaternion.identity);
    }

    public void TilePlacement()
    {
        Debug.Log("Down");
        Instantiate(ResouceTile, pointer.m_Dot.transform.position, Quaternion.identity);
    }
}
