using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    private int _coinsRequired = 8;
    private bool _elevatorCalled = false;
    private MeshRenderer _mat;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>().Getcoins() == _coinsRequired)
            if (Input.GetKeyDown(KeyCode.E))
            {
                _mat = GameObject.Find("Call_Button").GetComponent<MeshRenderer>();

                if (_elevatorCalled == true)
                    _mat.material.color = Color.red;
                else
                {
                    _mat.material.color = Color.green;
                    _elevatorCalled = true;
                }

                Elevator elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
                elevator.CallElevator();

            }
    }
}
