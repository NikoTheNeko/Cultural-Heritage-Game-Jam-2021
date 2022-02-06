using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [Header("Level Build Settings")]

    [Tooltip("The parent object(s) containing one side of the level")]
    public List<GameObject> sectionsToClone = new List<GameObject>();

    [Tooltip("Flips the color of black and white squares in the opposite level")]
    public bool flipBlackAndWhite = true;

    [Tooltip("Keeps track of the flipped level(s) so that it can be deleted if needed")]
    [ReadOnly] public List<GameObject> lastFlippedSections = new List<GameObject>();



    public void FlipLevel()
    {
        // Make sure that there is a parent object
        if (sectionsToClone.Count == 0)
        {
            Debug.LogError($"{GetType().Name}: No gameObject(s) provided for level building");
        }

        lastFlippedSections = new List<GameObject>();

        // Set the x scale to -1 to flip around the center
        foreach(GameObject section in sectionsToClone)
        {
            GameObject flippedSection = Instantiate(section);
            flippedSection.transform.position = section.transform.position;
            
            flippedSection.transform.localScale = new Vector3(
                -1 * flippedSection.transform.localScale.x,
                flippedSection.transform.localScale.y,
                flippedSection.transform.localScale.z);


            if (flipBlackAndWhite)
            {
                // Go through each child and flip colors
                foreach (Transform child in flippedSection.transform)
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

            lastFlippedSections.Add(flippedSection);
        }
    }


    public void DeleteFlippedLevel()
    {
        foreach (GameObject section in lastFlippedSections)
        {
            DestroyImmediate(section);
        }
    }
}
