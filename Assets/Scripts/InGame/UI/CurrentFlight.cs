using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentFlight : MonoBehaviour
{
    public Image flightImage;
    public Sprite[] sprites;

    public void SetFlight(int index)
    {
        flightImage.sprite = sprites[index];
    }
}
