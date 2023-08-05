using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private float _scale;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent(typeof(Player)))
        {
            if (_scale <= 0)
            {
                Debug.LogError("Назначьте масштаб для уменьшения объекта. Масштаб не может быть меньше или равен нулю");
                _scale = 0.5f;
            }

            other.gameObject.transform.localScale = new Vector3(_scale, _scale, _scale);
        }
    }
}
