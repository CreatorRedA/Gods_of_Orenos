using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MindParasite : MonoBehaviour, IDragHandler,IEndDragHandler
{
    public Image drawOneCard;
    public Image gainOneMana;

    GameObject Tabletop;

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;


    public void DrawOneCard()
    {
        GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameController>().drawOneCard();
        drawOneCard.gameObject.SetActive(false);
        gainOneMana.gameObject.SetActive(false);
    }
    public void GainOneMana()
    {
        GameObject.FindGameObjectWithTag("GameControl").GetComponent<GameController>().gainOneMana();
        drawOneCard.gameObject.SetActive(false);
        gainOneMana.gameObject.SetActive(false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        int d = 0;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (this.transform.parent == Tabletop.transform)
        {
            drawOneCard.gameObject.SetActive(true);
            gainOneMana.gameObject.SetActive(true);
        }
    }
}
