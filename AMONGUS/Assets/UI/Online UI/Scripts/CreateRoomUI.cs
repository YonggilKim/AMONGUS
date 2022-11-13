using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField] private List<Image> crewImages;
    [SerializeField] private List<Button> imposterCountButtons;
    [SerializeField] private List<Button> maxPlayerCountButtons;
    private CreateGameRoomData roomData;

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < crewImages.Count; i++)
        {
            Material materialInstance = Instantiate(crewImages[i].material);
            crewImages[i].material = materialInstance;
        }

        roomData = new CreateGameRoomData() { imposterCount = 1, maxPlayerCount = 10 };
        UpdatecrewImages();
    }

    private void UpdatecrewImages()
    {
        for (int i = 0; i < crewImages.Count; i++)
        {
            crewImages[i].material.SetColor("_PlayerColor",Color.white);
        }
        int impostercount = roomData.imposterCount;
        int idx = 0;
        while (impostercount != 0)
        {
            if (idx >= roomData.maxPlayerCount)
            {
                idx = 0;
            }
            if (crewImages[idx].material.GetColor("_PlayerColor") != Color.red && Random.Range(0, 5) == 0)
            {
                crewImages[idx].material.SetColor("_PlayerColor", Color.red);
                impostercount--;
            }
            idx++;
        }

        for (int i = 0; i < crewImages.Count; i++)
        {
            if (i < roomData.maxPlayerCount)
            {
                crewImages[i].gameObject.SetActive(true);
            }
            else
            {
                crewImages[i].gameObject.SetActive(false);
            }
        }
    }

    public void UpdateMaxPlayerCount(int count)
    {
        roomData.maxPlayerCount = count;
        for (int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            if (i == count - 4)
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                maxPlayerCountButtons[i].image.color = new Color(1f, 1f, 1f, 0f);
            }
        }
            UpdatecrewImages();

    }

    public void UpdateImposterCount(int count)
    {
        roomData.imposterCount = count;
        for (int i = 0; i < imposterCountButtons.Count; i++)
        {
            if (i == count - 1)
            {
                imposterCountButtons[i].image.color = new Color(1f, 1f, 1f, 1f);
            }
            else
            {
                imposterCountButtons[i].image.color = new Color(0f, 0f, 0f, 0f);
            }
        }

        int limitMaxPlayer = count == 1 ? 4 : count == 2 ? 7 : 9;
        if (roomData.maxPlayerCount < limitMaxPlayer)
        {
            UpdateMaxPlayerCount((limitMaxPlayer));
        }
        else
        {
            UpdateMaxPlayerCount((roomData.maxPlayerCount));
        }

        for (int i = 0; i < maxPlayerCountButtons.Count; i++)
        {
            var text = maxPlayerCountButtons[i].GetComponentInChildren<Text>();
            if (i < limitMaxPlayer - 4)
            {
                maxPlayerCountButtons[i].interactable = false;
                text.color = Color.gray;
            }
            else
            {
                maxPlayerCountButtons[i].interactable = true;
                text.color = Color.white;
            }
        }
    }
}

public class CreateGameRoomData
{
    public int imposterCount;
    public int maxPlayerCount;
}
