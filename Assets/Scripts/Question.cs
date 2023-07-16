using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Question")]
public class Question : ScriptableObject
{
    public Sprite image;
    public string[] answer;
    public int correctAnswer;
}
