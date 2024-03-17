using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolvedPuzzleEffect : MonoBehaviour
{
    public static SolvedPuzzleEffect Instance;

    public ParticleSystem particleSystem;
    private void Awake()
    {
        // Set up the singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public void PlayPieceSolvedEffect()
    { 
        particleSystem.Play();

    }

    
}
