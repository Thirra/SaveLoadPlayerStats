using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml.Serialization;
using System.IO;

public class SaveLoadData : MonoBehaviour
{
    public static SaveLoadData Instance;
    public PlayerStats playerStatistics;

    public GameObject UIStuff;

    private void Awake()
    {
        //Pseudo-singleton functionality 
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        //Open a new XML file
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerStats));

        //Creating a file over-writes anything that exists there - check the path first
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/player_data.xml", FileMode.Create);

        //This is where it's taking the information from the class and putting it into the xml file
        serializer.Serialize(stream, playerStatistics);

        stream.Close();
    }

    public void LoadData()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerStats));
        FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/player_data.xml", FileMode.Open);
        playerStatistics = (PlayerStats)serializer.Deserialize(stream);

        stream.Close();

        //UI things
        int index = (int)playerStatistics.playerClass;
        UIStuff.GetComponent<UIThings>().dropDown.value = index;
        UIStuff.GetComponent<UIThings>().playerName.text = playerStatistics.playerName;
        UIStuff.GetComponent<UIThings>().health.value = playerStatistics.health;
        UIStuff.GetComponent<UIThings>().stamina.value = playerStatistics.stamina;
        UIStuff.GetComponent<UIThings>().agility.value = playerStatistics.agility;
    }
}

[System.Serializable]
public class PlayerStats
{
    public string playerName;
    public PlayerClass playerClass;
    public int health;
    public int stamina;
    public int agility;
}

public enum PlayerClass
{
    Mage,
    Warrior,
    Warlock,
    Paladin,
    Priest
}

