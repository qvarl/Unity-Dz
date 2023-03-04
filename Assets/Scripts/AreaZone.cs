using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Movement>(out Movement movement))
        {
            _entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Movement>(out Movement movement))
        {
            _exited?.Invoke();
        }
    }
}
