using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    CardEffects cardEffects;
    public Card card;

    public Text titleText;
    public Text descriptionText;
    public Text manaCostText;
    public Text CardType;
    public Image picture;

    public int ManaCost;
    public int ManaGain;
    public int Draw;
    public int Discard;
    public int LookTopCard;

    // Start is called before the first frame update
    void Start()
    {
        titleText.text = card.CardTitle;
        descriptionText.text = card.description;
        manaCostText.text = card.ManaCost.ToString();
        CardType.text = card.cardType;
        picture.sprite = card.picture;
        
    }

    private void OnMouseDown()
    {
        cardEffects.addMana(ManaGain);
    }
}
