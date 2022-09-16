using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Conversation", menuName = "Conversation/narration")]
public class Narration : ScriptableObject
{
    public string Titel;
    [UnityEngine.TextArea(10,25)]public string Narrations;
}
