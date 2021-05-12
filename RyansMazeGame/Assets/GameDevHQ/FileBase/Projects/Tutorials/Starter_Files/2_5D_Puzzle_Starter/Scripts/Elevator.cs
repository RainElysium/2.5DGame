using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Transform _pointA, _pointB;
    private bool _move;
    private float _speed = 2f;

    public void CallElevator()
    {
        if (transform.position == _pointA.position)
            _move = true;
        else if (transform.position == _pointB.position)
            _move = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_move)
            transform.position = Vector3.MoveTowards(transform.position, _pointB.position, _speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, _pointA.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = this.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = null;
    }
}
