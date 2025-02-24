using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{
    [SerializeField]
    private Movement _playerMovement;
    private Animator _animator = null;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _playerMovement.GetSpeed());
    }

}
