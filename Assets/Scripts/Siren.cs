using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _audio;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    Coroutine _volumeChanged;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private IEnumerator VolumeChanger(float target)
    {
        while (_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, _duration * Time.deltaTime);
            yield return null;
        }
    }

    private void StartVolumeChanged(float target)
    {
        if (_volumeChanged != null)
        {
            StopCoroutine(_volumeChanged);
        }

        _volumeChanged = StartCoroutine(VolumeChanger(target));
    }

    public void VolumeUp()
    {
        StartVolumeChanged(_maxVolume);
    }

    public void VolumeDown()
    {
        StartVolumeChanged(_minVolume);
    }
}

