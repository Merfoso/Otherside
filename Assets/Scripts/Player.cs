using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Player: ScriptableObject
{  
    [SerializeField]
    private int tries;

    public int triesCount
    {
        get { return tries; }
        set { tries = value; }
    }

}
