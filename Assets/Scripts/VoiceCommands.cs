using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

public class VoiceCommands : MonoBehaviour
{
    public string[] keywords = new string[] { "up", "down", "left", "right" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public float speed = 1;
    public GameObject platformVertical;
    public GameObject platformHorizontal;
    protected PhraseRecognizer recognizer;
    protected string word = "right";
    [SerializeField]
    private Player Ball;

    private void Start()
    {
        if (Ball.triesCount == 1 && FindObjectOfType<elevatorCollider>().choco == false)
        {
            FindObjectOfType<AudioManager>().Play("Provocar");
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("Introduccion");
        }

        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            Debug.Log(recognizer.IsRunning);
        }

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
    }

    private void Update()
    {
        var x = platformHorizontal.transform.position.x;
        var y = platformVertical.transform.position.y;

        switch (word)
        {
            case "Arriba":
                y += speed;
                break;
            case "Abajo":
                y -= speed;
                break;
            case "Derecha":
                x += speed;
                break;
            case "Izquierda":
                x -= speed;
                break;
        }

        platformVertical.transform.position = new Vector3(-3.03f, Mathf.Clamp(y + Time.deltaTime * speed, -4.855f, 4.67f),0f);
        platformHorizontal.transform.position = new Vector3(Mathf.Clamp(x + Time.deltaTime * speed, -0.53f, 1.67f), 1.86f, 0f);

    }

    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }

}
