using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositionOrder : MonoBehaviour
{
    [SerializeField] private List<Composite> _order;

    private void Awake()
    {
        foreach (var composite in _order)
        {
            composite.Compose();
            composite.enabled = true;
        }
    }
}
