using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren_Triggered : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _audio;
    private float _target;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _target = 1f;
        StartCoroutine(VolumeChanger(_target));
    }

    private void OnTriggerExit(Collider other)
    {
        _target = 0f;
        StartCoroutine(VolumeChanger(_target));
    }

   private IEnumerator VolumeChanger(float volume)
    {
        while (_audio.volume != volume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, volume, _duration * Time.deltaTime);
            yield return null;
        }
    }
}

