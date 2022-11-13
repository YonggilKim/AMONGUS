using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyChracterMover : ChracterMover
{
    public void CompleteSpawn()
    {
        if (hasAuthority)
        {
            isMoveable = true;
        }
    }

}
