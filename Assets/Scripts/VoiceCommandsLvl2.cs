using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

public class VoiceCommandsLvl2 : MonoBehaviour
{
    public string[] keywords = new string[] { "up", "down", "left", "right", "bridge"};
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public float speed = 1;

    public GameObject platformVerticalA;
    public GameObject platformVerticalB;
    public GameObject platformVerticalC;

    public bool isPlaying = true;
    public static bool disabled = true;

    public GameObject apprearingBridge;

    public GameObject platformHorizontalA;
    public GameObject platformHorizontalB;
    public GameObject platformHorizontalC;

    protected PhraseRecognizer recognizer;
    protected string word = "right";

     void Start()
    {
        StartCoroutine(AudioCoroutine(FindObjectOfType<AudioManager>()));

        platformVerticalC.SetActive(false);

        if (keywords != null)
        {
            apprearingBridge.SetActive(false);
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

        var x = platformHorizontalA.transform.position.x;
        var x2 = platformHorizontalB.transform.position.x;
        var x3 = platformHorizontalC.transform.position.x;

        var y = platformVerticalA.transform.position.y;
        var y2 = platformVerticalB.transform.position.y;
        var y3 = platformVerticalC.transform.position.y;

        switch (word)
        {
            case "Arriba":
                y += speed;
                y2 += speed;
                y3 += speed;
                break;

            case "Abajo":
                y -= speed;
                y2 -= speed;
                y3 -= speed;
                break;

            case "Derecha":
                x += speed;
                x2 += speed;
                x3 += speed;
                break;

            case "Izquierda":
                x -= speed;
                x2 -= speed;
                x3 -= speed;
                break;

            case "Puente":
                if (disabled)
                {
                    apprearingBridge.SetActive(true);
                }
                break;
        }

        platformVerticalA.transform.position = new Vector3 (-0.25f, Mathf.Clamp(y + Time.deltaTime * speed, 2.12f, 4f), 0f);
        platformVerticalB.transform.position = new Vector3 (-8.3f, Mathf.Clamp(y2 + Time.deltaTime * speed, -0.1f, 2.03f), 0f);
        platformVerticalC.transform.position = new Vector3 (6.5f, Mathf.Clamp(y3 + Time.deltaTime * speed, -3.5f, 4.32f), 0f);

        platformHorizontalA.transform.position = new Vector3 (Mathf.Clamp(x + Time.deltaTime * speed, -7.47f, -5.12f), 2.05f, 0f);
        platformHorizontalB.transform.position = new Vector3 (Mathf.Clamp(x2 + Time.deltaTime * speed, -7.47f, -2.11f), -0.14f, 0f);
        platformHorizontalC.transform.position = new Vector3 (Mathf.Clamp(x3 + Time.deltaTime * speed, -4.63f, 1.95f), -3.52f, 0f);

    }

    IEnumerator AudioCoroutine(AudioManager audio) 
    { 
        if (isPlaying)
        {
            audio.Play("Nivel2Intro");         
        }

        yield return new WaitForSeconds(12);
        audio.Play("PuentesTip");
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
