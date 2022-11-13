using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.Mathematics;

public class AmongUsRoomManager : NetworkRoomManager
{
    public override void OnRoomServerConnect(NetworkConnectionToClient conn)
    {
        base.OnRoomServerConnect(conn);
        var spawnPos = FindObjectOfType<SpawnPositions>().GetSpawnPosition();
        var player = Instantiate(spawnPrefabs[0],spawnPos,quaternion.identity);
        NetworkServer.Spawn(player,conn);
    }
}
