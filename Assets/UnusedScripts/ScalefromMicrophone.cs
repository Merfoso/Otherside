using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalefromMicrophone : MonoBehaviour
{
    public AudioSource source;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        if (loudness < threshold)
        {
            loudness = 0;
        }


    }
}
