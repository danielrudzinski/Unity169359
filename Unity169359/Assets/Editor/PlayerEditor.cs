using UnityEngine;
using UnityEditor; 

[CustomEditor(typeof(PlayerManager))]
public class PlayerEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        PlayerManager myTarget = (PlayerManager)target;

        EditorGUILayout.LabelField("Ustawienia Postaci", EditorStyles.boldLabel);
        
        myTarget.playerName = EditorGUILayout.TextField("Nazwa Gracza", myTarget.playerName);

        myTarget.health = EditorGUILayout.IntField("Punkty Życia", myTarget.health);
        
        myTarget.strength = EditorGUILayout.IntSlider("Siła", myTarget.strength, 0, 100);

        EditorGUILayout.Space(15);

        if (GUILayout.Button("Zresetuj Statystyki (HP=100, STR=10)"))
        {
            myTarget.ResetStats();
        }
    }
}