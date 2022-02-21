using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    private void OnTriggerEnter2D(Collider2D other) 
    {       
        if (other.gameObject.tag == "Enemy")
        {
             Instantiate(_effectPrefab, transform.position, Quaternion.Euler(0,0,0));
            Destroy(other.gameObject); 
            Destroy(gameObject);
        }         
    }
}
