using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _particleSystem;
    private GameObject _gameObject;
    private float side = 1;
    private void Awake()
    {
        _gameObject = GameObject.FindGameObjectWithTag("Player");
        if(_gameObject.transform.rotation.y == 1)
        {
            side = -1;
        }
        _particleSystem.Play();
        Destroy(this.gameObject,5);
    }
    void Update()
    {
        transform.position += transform.forward*Time.deltaTime*_speed*side;
    }
}
