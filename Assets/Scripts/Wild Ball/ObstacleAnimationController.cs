using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimationController : MonoBehaviour
{
    [SerializeField]
    string[] _animationNames;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayRandomAnimation();
    }

    private void PlayRandomAnimation()
    {
        if (_animationNames.Length == 0)
        {
            Debug.LogWarning("No animations specified.");
            return;
        }

        int randomIndex = Random.Range(0, _animationNames.Length);
        string randomAnimation = _animationNames[randomIndex];

        _animator.Play(randomAnimation);

        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;

        Invoke("PlayRandomAnimation", animationDuration);
    }


}
