using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public int id;
    public string cardName;
    public string description;
    public Sprite artwork;
}
