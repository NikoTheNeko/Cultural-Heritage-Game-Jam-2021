using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [Header("Level Build Settings")]

    [Tooltip("The parent object containing one side of the level")]
    public GameObject levelParentObject;

    [Tooltip("Flips the color of black and white squares in the opposite level")]
    public bool flipBlackAndWhite = true;

    [Tooltip("Keeps track of the flipped level so that it can be deleted if needed")]
    [ReadOnly] public GameObject flippedLevel;



    public void FlipLevel()
    {
        // Make sure that there is a parent object
        if (!levelParentObject)
        {
            Debug.LogError($"{GetType().Name}: No gameObject provided for level building");
        }

        // Set the x scale to -1 to flip around the center
        flippedLevel = Instantiate(levelParentObject);
        flippedLevel.transform.position = levelParentObject.transform.position;
        
        flippedLevel.transform.localScale = new Vector3(
            -1 * flippedLevel.transform.localScale.x,
            flippedLevel.transform.localScale.y,
            flippedLevel.transform.localScale.z);


        if (flipBlackAndWhite)
        {
            // Go through each child and flip colors
            foreach (Transform child in flippedLevel.transform)
            {
                SpriteRenderer childSprite = child.GetComponent<SpriteRenderer>();

                // Check if the child object has a sprite renderer
                if (!childSprite)
                {
                    Debug.LogWarning($"{GetType().Name}: GameObject {child.name} has no SpriteRenderer component. Skipping...");
                    continue;
                }

                // Flip black and white color
                if (childSprite.color == Color.white)
                {
                    childSprite.color = Color.black;
                }
                else if (childSprite.color == Color.black)
                {
                    childSprite.color = Color.white;
                }
            }
        }
    }


    public void DeleteFlippedLevel()
    {
        DestroyImmediate(flippedLevel);
    }
}
