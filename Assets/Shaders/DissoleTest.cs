using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissoleTest : MonoBehaviour
{
    [SerializeField] private Material _dissolveMaterial;

    private float _dissolveAmount;
    private bool _isActive;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isActive = true;
        }

        if (_isActive)
        {
            _dissolveAmount = Mathf.Clamp01(_dissolveAmount + Time.deltaTime); 
            _dissolveMaterial.SetFloat("_DissolveAmount", _dissolveAmount);
            
            if (_dissolveAmount >= 1.0f)
            {
                _dissolveAmount = 0.0f;
            }
        }
    }
}
