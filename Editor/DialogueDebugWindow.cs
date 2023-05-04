using Monomite.Common.Dialogue;
using Monomite.Common.MessageBus;
using UnityEditor;
using UnityEngine;

public class DialogueDebugWindow : EditorWindow
{
    private MessageBus<DialogueEvent, DialogueState> MessageBus;

    private string node = string.Empty;

    // Add menu item named to the Window menu
    [MenuItem("Window/Dialogue Debug Window")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(DialogueDebugWindow));
    }

    private void OnGUI()
    {
        // Chose MessageBus
        EditorGUILayout.BeginHorizontal();
        MessageBus = (MessageBus<DialogueEvent, DialogueState>)EditorGUILayout.ObjectField(MessageBus, typeof(MessageBus<DialogueEvent, DialogueState>), false);
        EditorGUILayout.EndHorizontal();

        if (MessageBus != null)
        {
            GUILayout.Space(1f);

            GUILayout.BeginVertical();
            /*if (GUILayout.Button("Nodo Simple"))
            {
                MessageBus.EmitEvent(new StartDialogue("Simple"));
            }
            if (GUILayout.Button("Nodo Estilos individuales"))
            {
                MessageBus.EmitEvent(new StartDialogue("Estilos_individuales"));
            }
            if (GUILayout.Button("Nodo Estilos globales"))
            {
                MessageBus.EmitEvent(new StartDialogue("Estilos_globales"));
            }
            if (GUILayout.Button("Nodo Estilos"))
            {
                MessageBus.EmitEvent(new StartDialogue("Estilos"));
            }
            if (GUILayout.Button("Nodo Opciones"))
            {
                MessageBus.EmitEvent(new StartDialogue("Opciones"));
            }
            if (GUILayout.Button("Nodo Comandos"))
            {
                MessageBus.EmitEvent(new StartDialogue("Comandos"));
            }
            if (GUILayout.Button("Nodo Funciones"))
            {
                MessageBus.EmitEvent(new StartDialogue("Funciones"));
            }*/
            node = GUILayout.TextField(node);
            if (GUILayout.Button("Start dialogue") && !string.IsNullOrEmpty(node))
            {
                Debug.Log(node);
                MessageBus.EmitEvent(new StartDialogue(node));
            }

            GUILayout.Space(1f);

            if (GUILayout.Button("Continue dialogue"))
            {
                MessageBus.EmitEvent(new ContinueDialogue());
            }
            if (GUILayout.Button("End dialogue"))
            {
                MessageBus.EmitEvent(new EndDialogue());
            }
            GUILayout.EndVertical();
        }
    }
}