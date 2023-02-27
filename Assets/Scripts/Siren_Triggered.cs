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
        StartCoroutine(VolumeChanger());
    }

    private void OnTriggerExit(Collider other)
    {
        _target = 0f;
        StartCoroutine(VolumeChanger());
    }

   private IEnumerator VolumeChanger()
    {
        while (_audio.volume != _target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _target, _duration * Time.deltaTime);
            yield return null;
        }
    }
}

