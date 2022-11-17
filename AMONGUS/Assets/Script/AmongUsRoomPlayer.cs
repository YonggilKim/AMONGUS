using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;

public class AmongUsRoomPlayer : NetworkRoomPlayer
{
    #region 변수
    private static AmongUsRoomPlayer myRoomPlayer;
    public static AmongUsRoomPlayer MyRoomPlayer
    {
        get
        {
            if (myRoomPlayer == null)
            {
                var players = FindObjectsOfType<AmongUsRoomPlayer>();
                foreach (var player in players)
                {
                    if (player.hasAuthority)
                    {
                        myRoomPlayer = player;
                    }
                }
            }
            return myRoomPlayer;
        }
    }
    [SyncVar(hook = nameof(SetPlayerColor_hook))] 
    public EPlayerColor playerColor;

    public void SetPlayerColor_hook(EPlayerColor oldColor, EPlayerColor newColor)
    {
        LobbyUIManager.Instance.CustomizeUI.UpdateUnselectColorButton(oldColor);
        LobbyUIManager.Instance.CustomizeUI.UpdateSelectColorButton(newColor);
    }

    public ChracterMover lobbyPlayerChracter;
    #endregion 변수
    public void Start()
    {
        base.Start();
        if (isServer)
        {
            SpawnLobbyPlayerChracter();
        }
    }

    private void OnDestroy()
    {
        if (LobbyUIManager.Instance != null)
        {
            LobbyUIManager.Instance.CustomizeUI.UpdateUnselectColorButton(playerColor);
        }
    }

    [Command]
    public void CmdSetPlayerColor(EPlayerColor color)
    {
        playerColor = color;
        lobbyPlayerChracter.playerColor = color;
    }

    private void SpawnLobbyPlayerChracter()
    {
        var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;
        EPlayerColor color = EPlayerColor.Red;
        for (int i = 0; i < (int)EPlayerColor.Lime + 1; i++)
        {
            bool isFindeSameColor = false;
            foreach (var roomPlayer in roomSlots)
            {
                var amongUsRoomPlayer = roomPlayer as AmongUsRoomPlayer;
                if (amongUsRoomPlayer.playerColor == (EPlayerColor)i && roomPlayer.netId != netId)
                {
                    isFindeSameColor = true;
                    break;
                }
            }

            if (!isFindeSameColor)
            {
                color = (EPlayerColor)i;
                break;
            }
        }

        playerColor = color;

        Vector3 spawnPos = FindObjectOfType<SpawnPositions>().GetSpawnPosition();
        var playerChracter= Instantiate(AmongUsRoomManager.singleton.spawnPrefabs[0],spawnPos,Quaternion.identity).GetComponent<LobbyChracterMover>();
        playerChracter.transform.localScale = index < 5 ? new Vector3(0.5f, 0.5f, 1f) : new Vector3(-0.5f, 0.5f, 1f);
        NetworkServer.Spawn(playerChracter.gameObject, connectionToClient);
        playerChracter.ownerNetId = netId;
        playerChracter.playerColor = color;
    }
}
