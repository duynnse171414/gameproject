using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpawner;
    private bool bossCalled =false;
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private CinemachineCamera cam;

    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);
        MainMenu();
        audioManager.StopAudioGame();
        cam.Lens.OrthographicSize = 5f;
    }


    public void AddEnergy()
    {
        if(bossCalled)
        {
            return; 
        }
        currentEnergy += 1;
        UpdateEnergyBar();
        if(currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }
    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true); 
        enemySpawner.SetActive(false);
        gameUI.SetActive(false);
        audioManager.PlayBossAudio();
        cam.Lens.OrthographicSize = 10f;
    }
    private void UpdateEnergyBar()
    {
        
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
       gameOverMenu.SetActive(false);
       pauseMenu.SetActive(false);
       winMenu.SetActive(false); 
        Time.timeScale = 0f;
    }
    public void GameOverMenu()
    {
        gameOverMenu.SetActive(true) ;
        mainMenu.SetActive(false) ;
        pauseMenu.SetActive(false) ;  
        winMenu.SetActive(false) ;
        Time.timeScale = 0f;
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false) ;
        mainMenu.SetActive(false) ;
        winMenu.SetActive(false) ;
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudio();
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        mainMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void WinGame()

    {
        
        winMenu.SetActive(true);
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false) ;
        Time.timeScale = 0f;
    }
}
