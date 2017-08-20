using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIThings : MonoBehaviour
{
    public SaveLoadData saveLoadData;

    public Dropdown dropDown;

    //Don't really need these here
    private List<string> classes;
    private int index;

    public InputField playerName;

    public Slider health;
    public Text healthText;

    public Slider stamina;
    public Text staminaText;

    public Slider agility;
    public Text agilityText;

	// Use this for initialization
	void Start ()
    {
        saveLoadData = FindObjectOfType<SaveLoadData>();

        PopulateList();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Added a numerical representation for slider
        healthText.text = health.value.ToString();
        staminaText.text = stamina.value.ToString();
        agilityText.text = agility.value.ToString();
    }

    public void ifOnValueChanged()
    {
        string changedName = playerName.text;
        saveLoadData.playerStatistics.playerName = changedName;
    }

    public void ddValueIsChanged()
    {
        index = dropDown.value;
        saveLoadData.playerStatistics.playerClass = (PlayerClass)index;
    }

    public void healthOnValueChanged()
    {
        saveLoadData.playerStatistics.health = (int)health.value;
    }

    public void staminaOnValueChanged()
    {
        saveLoadData.playerStatistics.stamina = (int)stamina.value;
    }

    public void agilityOnValueChanged()
    {
        saveLoadData.playerStatistics.agility = (int)agility.value;
    }

    void PopulateList()
    {
        string[] enumNames = Enum.GetNames(typeof(PlayerClass));
        classes = new List<string> (enumNames);
        dropDown.AddOptions(classes);        
    }
}
