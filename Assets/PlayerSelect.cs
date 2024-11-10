using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public Sprite[] characterSprites; // Array of different character sprites
    private SpriteRenderer playerSpriteRenderer;

    private const string SelectedPlayerKey = "Player";

   

    void Start()
    {
        playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        int selectedCharacterIndex = PlayerPrefs.GetInt(SelectedPlayerKey, 0);
        if (characterSprites.Length > 0 && selectedCharacterIndex < characterSprites.Length)
        {
            playerSpriteRenderer.sprite = characterSprites[selectedCharacterIndex];
        }
        else
        {
            Debug.LogError("Character index is out of bounds or no sprites assigned!");
        }
    }
}
