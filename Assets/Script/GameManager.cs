using UnityEngine;
using UnityEngine.UI;
using Timers;
namespace GameLogic
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public static event OnGameOver GameOver;
        public delegate void OnGameOver(int IdGameOver);

        [SerializeField] private Text _resourcesText;
        [SerializeField] private Text _raidText;
        [SerializeField] private Text _gameOverText;

        [SerializeField] private ImageTimer _harvestTimer;
        [SerializeField] private ImageTimer _eatimgTimer;
        [SerializeField] private ImageTimer _raidTimer;

        [HideInInspector] public int allWarrior;
        [HideInInspector] public int allWheat;
        [HideInInspector] public int raidDisplay;
        [HideInInspector] public int noCreate;
        [HideInInspector] public int numberRaid;

        public int peasantCount;
        public int peasant;

        public int warriorCount;

        public int wheatVictory;
        public int wheatCount;
        public int wheatPerPeasant;
        public int wheatToPeasant;
        public int wheatToWarrios;
               
        public int numberEnemies;
              
        private int _warrior;
        private int _idGameOver;       
        void Awake()
        {
            Time.timeScale = 1;
            AudioListener.volume = 1;
            instance = GetComponent<GameManager>();
        }
        void Update()
        {
            GameOwerOptions();
            WheatCalculation();
            NoCreateOprions();
            Raid();
            UpdateText();
        }
        void OnEnable()
        {
            CreateButton.Create—haracterbool += CreateCharecter;
        }
        void OnDisable()
        {
            CreateButton.Create—haracterbool -= CreateCharecter;
        }
        void CreateCharecter(int create)
        {
            if (create == 0)
                CreateWarrior();
            else CreatePeasant();
        }
        void CreateWarrior()
        {
            if (peasantCount < 25)
            {
                _warrior = 1;
                Warrior(_warrior);
            }
            else if (peasantCount > 25 & peasantCount < 50)
            {
                _warrior = 3;
                Warrior(_warrior);
            }
            else
            {
                _warrior = 5;
                Warrior(_warrior);
            }
            wheatCount -= _warrior * wheatToWarrios;
        }
        void Warrior(int numberWarrior)
        {
            warriorCount += numberWarrior;
        }
        void CreatePeasant()
        {
            peasantCount += peasant;
            wheatCount -= peasant * wheatToPeasant;
        }
        void WheatCalculation()
        {
            if (_harvestTimer.startTime)
            {
                wheatCount += peasantCount * wheatPerPeasant;
                allWheat += peasantCount * wheatPerPeasant;
            }
            if (_eatimgTimer.startTime)
                wheatCount -= warriorCount * wheatToWarrios;
        }
        void Raid()
        {
            if (_raidTimer.startTime)
            {            
                numberRaid += 1;
                if (numberRaid == 2)
                    raidDisplay = 0;
                else if (numberRaid >= 3)
                {
                    allWarrior += numberEnemies;
                    warriorCount -= numberEnemies;
                    raidDisplay = numberEnemies;
                    if (numberEnemies < 5)
                    {
                        numberEnemies += numberEnemies;
                        raidDisplay = numberEnemies;
                    }
                    else
                    {
                        numberEnemies += 2;
                        raidDisplay = numberEnemies;
                    }
                }
            }         
        }
        void GameOwerOptions()
        {
            if (wheatCount < 0)            
                GameOver(_idGameOver = 0);
            else if (wheatCount >= wheatVictory)
                GameOver(_idGameOver = 2);
            if (warriorCount < 0)
                GameOver(_idGameOver = 1);                      
        }
        void NoCreateOprions()
        {
            noCreate = wheatCount - warriorCount * wheatToWarrios - wheatToWarrios;
        }
        void UpdateText()
        {
            _resourcesText.text = peasantCount + "\n" + instance.warriorCount + "\n\n" + instance.wheatCount;
            _raidText.text = raidDisplay.ToString();
            _gameOverText.text = numberRaid - 3 + "\n" + allWheat + "\n" + peasantCount + "\n" + allWarrior;
        }
    }  
}
