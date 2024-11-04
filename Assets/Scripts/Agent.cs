using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public List<string> actions = new List<string>();
    List<Room> rooms;
    int currentRoomIndex;

    public void StartGame(int howManyTimes, List<Room> rooms, float dirtyRate)
    {
        //Hangi odadan başlayacağımızı seçiyoruz
        int currentRoomIndex = 0;
        if (Random.Range(0, rooms.Count) % 2 == 0)
        {
            currentRoomIndex = 1;
        }

        this.currentRoomIndex = currentRoomIndex;
        this.rooms = rooms;

        //Setup bitti döngüyü başlatıyoruz
        StartCoroutine(Next(howManyTimes, dirtyRate));
    }

    IEnumerator Next(int howManyTimes, float randomness)
    {
        GoNext();
        while (howManyTimes > actions.Count)
        {
            yield return new WaitForSeconds(1);
            MakeRandomDirty(randomness);
            if (CheckIfClean())
                GoNext();
            else Clean();
        }
    }

    private void MakeRandomDirty(float randomness)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (i == currentRoomIndex) continue;

            float random = Random.Range(0f, 1f);

            if (random <= randomness)
            {
                rooms[i].MakeItDirty();
            }
        }
    }

    public void GoNext()
    {
        currentRoomIndex++;
        currentRoomIndex %= rooms.Count;
        Room nextRoom = rooms[currentRoomIndex];
        updateList("Moving to " + nextRoom.RoomName);

        transform.DOJump(nextRoom.CenterPoint.position, 3, 1, 1, false);
    }

    bool CheckIfClean()
    {
        return !rooms[currentRoomIndex].IsDirty;
    }


    private void Clean()
    {
        rooms[currentRoomIndex].CleanTheRoom();
        updateList("Cleaning");

        transform.DOShakePosition(1, new Vector3(1, 0, 1));
    }

    void updateList(string newActions)
    {
        actions.Add(newActions);
        textMeshProUGUI.text +=  newActions + " => ";
    }
}

