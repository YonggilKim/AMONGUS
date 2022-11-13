using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : MonoBehaviour
{
    [SerializeField] private Transform[] positions;

    private int index;
    // Start is called before the first frame update
    public Vector3 GetSpawnPosition()
    {
        Vector3 pos = positions[index++].position;
        if (index >= positions.Length)
        {
            index = 0;
        }
        return pos;
    }
}
