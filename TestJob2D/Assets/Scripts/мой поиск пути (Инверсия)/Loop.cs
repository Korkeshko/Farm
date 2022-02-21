using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    [SerializeField] private float _secondsPerUpdate;

    private IEnumerable<ICustomUpdate> _updatables;
    private float _lastUpdateTime;

    private void Start()
    {
        _updatables = GetComponentsInChildren<ICustomUpdate>();
        _lastUpdateTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _lastUpdateTime >= _secondsPerUpdate)
        {
            foreach (var updatable in _updatables)
                updatable.CustomUpdate();

            _lastUpdateTime = Time.time;    
        }    
    }
}
