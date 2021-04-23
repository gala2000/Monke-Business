using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatVisualTest : MonoBehaviour
{
    public Image TestImage1;
    public Image TestImage2;
    public Image TestImage3;

    public void RandomizeColorOnBeat() //On Event
    {
        TestImage1.color = Random.ColorHSV();
    }

    public void RandomizeColorOnHalfBeat()
    {
        Color32 tempColor = Random.ColorHSV();
        TestImage2.color = tempColor;
        TestImage3.color = tempColor;
    }
}
