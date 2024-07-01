using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private GameObject _projectileSpawner;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _projectileLifeTime;
    [SerializeField] private float _reloadTime;
    private float cooldownTime;
    private bool isReadyShoot = true;

    private void Update()
    {
        if(_projectilePrefab != null && _inputManager.IsAttacking && isReadyShoot)
        {
            isReadyShoot=false;
            cooldownTime = _reloadTime;
            Instantiate(_projectilePrefab, _projectileSpawner.transform.position, Quaternion.identity);
        }
        if (isReadyShoot==false)
        {
            cooldownTime -= Time.fixedDeltaTime;
            if (cooldownTime < 0)
            {
               isReadyShoot=true;
            }
        }
    }
}
