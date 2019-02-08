using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text titleText;
    public Text descriptionText;
    public Text manaCostText;

    public Image picture;
    // Start is called before the first frame update
    void Start()
    {
        titleText.text = card.CardTitle;
        descriptionText.text = card.description;
        manaCostText.text = card.ManaCost.ToString();
        picture.sprite = card.picture;
    }


}
