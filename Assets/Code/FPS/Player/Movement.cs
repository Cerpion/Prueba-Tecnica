using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    private readonly float _speedMovement = 8;
    private readonly Rigidbody _rigidbody;
    private readonly Transform _myTransform;

    public Movement(float speedMovement, Rigidbody rigidbody, Transform myTransform)
    {
        _speedMovement = speedMovement;
        _rigidbody = rigidbody;
        _myTransform = myTransform;
    }

    public void DoMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") ;
        float vertical = Input.GetAxisRaw("Vertical") ;

        var inputs = new Vector2(horizontal, vertical);
        inputs = inputs.normalized * _speedMovement;

        Vector3 movement = (_myTransform.right * inputs.x) + (_myTransform.forward * inputs.y);

        //characterController.Move(movement * Time.deltaTime);
        _rigidbody.MovePosition(_myTransform.position + movement * Time.deltaTime);

    }


    

}


