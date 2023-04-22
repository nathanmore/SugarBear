using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : Interactable
{
    [SerializeField] private GameObject lasers;

    void Start()
    {
        currentState = baseState;
        lasers.SetActive(currentState);
    }

    public override void trigger(bool state)
    {
        if (isToggle)
        {
            if (state)
            {
                currentState = !currentState;
                lasers.SetActive(currentState);
            }
        }
        else
        {
            lasers.SetActive(state ^ baseState);
        }
    }
}
