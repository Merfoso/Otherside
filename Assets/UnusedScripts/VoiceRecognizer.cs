using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using Random = UnityEngine.Random;

public class VoiceRecognizer : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public GameObject ObjectToMove;
    public float speed = 1;

    private void Start()
    {
        actions.Add("Up", Up);
        actions.Add("Left", Down);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedVoice;
        keywordRecognizer.Start();

    }

    private void RecognizedVoice (PhraseRecognizedEventArgs voice)
    {
        actions[voice.text].Invoke();
        
    }
    private void Update()
    {
      /*  switch (actions)
        {
            case "Up":
                 += speed;
                break;
            case "down":
                 -= speed;
                break;
        }*/

    }

    private void Up()
    {
        transform.Translate(0, 2f *Time.deltaTime, 0);

    }

    private void Down()
    {
        transform.Rotate(0f, 0f, 5f);
    }


}
