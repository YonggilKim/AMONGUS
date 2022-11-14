    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Mirror;
    using Unity.VisualScripting;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class CustomizeUI : MonoBehaviour
    {
        [SerializeField] private Image chracterPreview;
        
        [SerializeField] private List<ColorSelectButton> colorSelectButtons;
        
        private void OnEnable()
        {
            UpdateColorButton();
        
            var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;
            foreach (var player in roomSlots)
            {
                var aPlayer = player as AmongUsRoomPlayer;
                if (aPlayer.isLocalPlayer)
                {
                    UpdatePreviewColor(aPlayer.playerColor);
                    break;
                }
            }
        }
        
        void Start()
        {
            var inst = Instantiate(chracterPreview.material);
            chracterPreview.material = inst;
        }
        
        public void UpdateColorButton()
        {
            var roomSlots = (NetworkManager.singleton as AmongUsRoomManager).roomSlots;
        
            for (int i = 0; i < colorSelectButtons.Count; i++)
            {
                colorSelectButtons[i].SetIntertactable(true);
            }
        
            foreach (var player in roomSlots)
            {
                var aPlayer = player as AmongUsRoomPlayer;
                colorSelectButtons[(int)aPlayer.playerColor].SetIntertactable(false);
        
            }
        }
        
        public void UpdatePreviewColor(EPlayerColor color)
        {
            chracterPreview.material.SetColor("_PlayerColor", PlayerColor.GetColor(color));
        }

        public void onClickColorButton(int index)
        {
            if (colorSelectButtons[index].isInteractable)
            {
                AmongUsRoomPlayer.MyRoomPlayer.CmdSetPlayerColor(((EPlayerColor)index));
                UpdatePreviewColor((EPlayerColor)index);
            }
        }

        public void Open()
        {
            AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerChracter.isMoveable = false;
            gameObject.SetActive((true));
        }

        public void Close()
        {
            AmongUsRoomPlayer.MyRoomPlayer.lobbyPlayerChracter.isMoveable = true;
            gameObject.SetActive((false));
        }
    }
