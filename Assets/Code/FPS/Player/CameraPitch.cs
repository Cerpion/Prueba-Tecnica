using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPitch : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve;

    [SerializeField] private Rigidbody _player;
    [SerializeField] private Transform _pivot;

    [SerializeField] private Vector3 _initialPos;
    [SerializeField] private float _timefinalAnimation;

    [SerializeField] private float _cabeseoX;
    [SerializeField] private float _cabeseoY;

    [SerializeField] private float _intervaloX;
    [SerializeField] private float _intervaloY;
        
    [SerializeField] private float _multiplierX;
    [SerializeField] private float _multiplierY;

    private void Start()
    {
        _initialPos = _pivot.transform.localPosition;
        _timefinalAnimation = _animationCurve[_animationCurve.length - 1].time;
    }

    private void LateUpdate()
    {
       var velocityPlayer = _player.velocity;
        velocityPlayer.y = 0;

        var magnitude = velocityPlayer.magnitude;

        _cabeseoX += magnitude * Time.deltaTime / _intervaloX;
        _cabeseoY += magnitude * Time.deltaTime / _intervaloY;

        if (_cabeseoX > _timefinalAnimation)
        {
            _cabeseoX -= _timefinalAnimation;
        }

        if (_cabeseoY > _timefinalAnimation)
        {
            _cabeseoY -= _timefinalAnimation;
        }

        var xpos = _animationCurve.Evaluate(_cabeseoX) * _multiplierX;
        var ypos = _animationCurve.Evaluate(_cabeseoY) * _multiplierY;

        Vector3 movement = new Vector3(xpos, ypos,0);

        if (magnitude > 0.1f)
        {
            _pivot.transform.localPosition = _initialPos + movement;
        }else
        {
            _pivot.transform.localPosition = _initialPos;

        }
    }

}
