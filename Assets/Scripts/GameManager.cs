using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{
    int howManyTurn = 10;
    [SerializeField] TMP_InputField turnInputField;
    [SerializeField] Slider slider;

    [SerializeField] Agent agent;

    [SerializeField] List<Room> rooms;

    public void StartGame()
    {

        Application.targetFrameRate = 61;

        //Başlangıçta iki odanın kirliliğini de random olarak belirliyoruz
        foreach (var room in rooms)
        {
            room.CleanInstant();
            if (Random.Range(0f, 1f) <= slider.value)
                room.MakeItDirty();
        }

        howManyTurn = int.Parse(turnInputField.text);

        agent.StartGame(howManyTurn, rooms, slider.value);
    }



}
