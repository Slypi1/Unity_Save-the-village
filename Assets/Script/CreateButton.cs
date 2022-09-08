using UnityEngine;
using UnityEngine.UI;
using GameLogic;
public class CreateButton : MonoBehaviour
{
    public static event OnCharacter Create—haracterbool;
    public delegate void OnCharacter(int time);

    private int idButton;  
    public void CreateWarrior()
    {
        idButton = 0;
        Create—haracterbool(idButton);       
    }
    public void CreatePeasant()
    {
        idButton = 1;
        Create—haracterbool(idButton);      
    }  
}

