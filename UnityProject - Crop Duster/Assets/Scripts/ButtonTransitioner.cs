using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 m_NormalColour = Color.white;
    public Color32 m_HoverColour = Color.grey;
    public Color32 m_DownColour = Color.white;

    private Image m_Image = null;
    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Enter");
        m_Image.color = m_HoverColour;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exit");
        m_Image.color = m_NormalColour;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Down");
        m_Image.color = m_DownColour;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("Up");

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("Click");
        m_Image.color = m_HoverColour;

    }



}
