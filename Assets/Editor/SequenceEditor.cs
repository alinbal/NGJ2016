using UnityEngine;
using System.Collections;
using UnityEditor;

public class SequenceEditor : EditorWindow
{
    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/Sequence Editor")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        SequenceEditor window = (SequenceEditor)GetWindow(typeof(SequenceEditor));
        window.Show();
    }

    void OnGUI()
    {

    }
}
