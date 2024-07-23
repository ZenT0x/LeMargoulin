using UnityEngine;

public class WeatherDraw : Deck
{
    public override Card DrawCard()
    {
        Debug.Log("Tirage de carte météo");
        return base.DrawCard();
    }
}
