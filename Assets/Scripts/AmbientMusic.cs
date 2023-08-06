using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    void Start()
    {
        _audioSource.Play();
    }
}
