using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SCREEN
{
    MAINMENU,
    PASSWORD,
    WIN
}
public class Hacker : MonoBehaviour
{
    string password;
    System.Random random = new System.Random();
    const string menuHint = "You may type menu at any time";
    string[] level1Password = {"books","aisle","self","password","borrow","font"};
    string[] level2Password = { "prisoner", "handcuffs", "holster", "uniform", "arrest", "police" };
    string[] level3Password = { "uranus", "shootingstar", "jupiter", "saturn", "area51", "alien" };

    int level;
    SCREEN currentScreen;

    void Start()
    {
        currentScreen = SCREEN.MAINMENU;
        MainMenuScreen();  
    }
    
    void MainMenuScreen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
        Terminal.WriteLine("");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("Game Closed");
            Application.Quit();
        }
        else if (currentScreen == SCREEN.MAINMENU)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == SCREEN.PASSWORD)
        {
            CheckPassword(input);
        }
    }

     void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");

        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
       
        else if (input == "007") //easter egg
        {
            Terminal.WriteLine("Please choose a level agent 007:");
            Terminal.WriteLine("\n" + menuHint + "\n");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level:");
            Terminal.WriteLine("\n" + menuHint + "\n");
        }
    }

    private void ShowMainMenu()
    {
        currentScreen = SCREEN.MAINMENU;
        MainMenuScreen();
    }

    void AskForPassword()
    {
        currentScreen = SCREEN.PASSWORD;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter password, hint: " + password.Anagram());
        Terminal.WriteLine("\n"+menuHint+"\n");
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Password[random.Next(level1Password.Length)];//Random.Range is not working as well as this
                break;
            case 2:
                password = level2Password[random.Next(level2Password.Length)];
                break;
            case 3:
                password = level3Password[random.Next(level3Password.Length)];
                break;
            default:
                Debug.LogError("Please enter your password");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
        
    }

    void DisplayWinScreen()
    {
        currentScreen = SCREEN.WIN;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Congrats!!-<3-!!");
                Terminal.WriteLine("\n" + menuHint + "\n");
                break;

            case 2:
                Terminal.WriteLine("Congrats!!-<3-!!");
                Terminal.WriteLine("\n" + menuHint + "\n");
                break;
            case 3:
                Terminal.WriteLine("Congrats!!-<3-!!");
                Terminal.WriteLine("\n" + menuHint + "\n");
                break;

            default:
                Debug.LogError("Something went wrong");
                Terminal.WriteLine("\n" + menuHint + "\n");
                break;
        }
       
    }
}
