using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaZone : MonoBehaviour
{
    private Siren _siren;
    // Start is called before the first frame update
    void Start()
    {
        _siren = GetComponent<Siren>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _siren.VolumeUp();
    }

    private void OnTriggerExit(Collider other)
    {
        _siren.VolumeDown();
    }
}
