using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelBuilder))]
public class LevelBuilderEditor : Editor
{
    SerializedProperty levelParentObject = null;
    SerializedProperty flipBlackAndWhite = null;
    SerializedProperty flippedLevel = null;

    private void OnEnable()
    {
        levelParentObject = serializedObject.FindProperty("levelParentObject");
        flipBlackAndWhite = serializedObject.FindProperty("flipBlackAndWhite");
        flippedLevel = serializedObject.FindProperty("flippedLevel");
    }


    public override void OnInspectorGUI()
    {
        // Update the representation of the properties
        serializedObject.Update();


        // Draw property fields
        EditorGUILayout.PropertyField(levelParentObject);
        EditorGUILayout.PropertyField(flipBlackAndWhite);
        EditorGUILayout.PropertyField(flippedLevel);
        
        EditorGUILayout.Space();
        EditorGUILayout.Space();


        // Draw buttons to run functions
        if (GUILayout.Button("Build Flipped Level"))
        {
            (serializedObject.targetObject as LevelBuilder).FlipLevel();
        }

        if (GUILayout.Button("Delete Flipped Level"))
        {
            (serializedObject.targetObject as LevelBuilder).DeleteFlippedLevel();
        }

        // Apply any changes to the inspector
        serializedObject.ApplyModifiedProperties();
    }
}
