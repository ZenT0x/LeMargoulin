using UnityEngine;
using UnityEditor;

public class CardGenerator : EditorWindow
{
    private int numberOfCards = 10; // Nombre de cartes à générer
    private string baseName = "Card_"; // Nom de base pour les cartes
    private string description = "Default description";
    private Sprite artwork;

    [MenuItem("Tools/Card Generator")]
    public static void ShowWindow()
    {
        GetWindow<CardGenerator>("Card Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Generate Cards", EditorStyles.boldLabel);

        numberOfCards = EditorGUILayout.IntField("Number of Cards", numberOfCards);
        baseName = EditorGUILayout.TextField("Base Name", baseName);
        description = EditorGUILayout.TextField("Description", description);
        artwork = (Sprite)EditorGUILayout.ObjectField("Artwork", artwork, typeof(Sprite), false);

        if (GUILayout.Button("Generate Cards"))
        {
            GenerateCards();
        }
    }

    private void GenerateCards()
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            Card newCard = ScriptableObject.CreateInstance<Card>();
            newCard.id = i + 1;
            newCard.cardName = baseName + (i + 1);
            newCard.description = description;
            newCard.artwork = artwork;

            string path = $"Assets/Cards/{newCard.cardName}.asset";
            AssetDatabase.CreateAsset(newCard, path);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
