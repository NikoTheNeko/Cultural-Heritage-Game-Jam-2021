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
        DrawDefaultInspector();
        
        EditorGUILayout.Space();
        EditorGUILayout.Space();


        // Draw buttons to run functions
        if (GUILayout.Button("Build Flipped Level(s)"))
        {
            (serializedObject.targetObject as LevelBuilder).FlipLevel();
        }

        if (GUILayout.Button("Delete Flipped Level(s)"))
        {
            (serializedObject.targetObject as LevelBuilder).DeleteFlippedLevel();
        }
    }
}
