using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<AudioClip> musicClips;
    private AudioSource gameMusic;
    public TextMeshProUGUI killText;
    public int Kills;
    public bool isGame;

    public GameObject spawnWaveObject;
    public GameObject PlayerShip;
    public GameObject menuPanel;
    public GameObject mainImage;
    public GameObject easyImage;
    public GameObject mediumImage;
    public GameObject hardImage;
    public GameObject inGamePanel;

    public GameObject pauseScreen;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        gameMusic = GetComponent<AudioSource>();
        MusicSystem();
        UpdateKills(0);
        isGame = false;
        mainImage.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }

    }
    public void EasyDifficulty()
    {
        mainImage.gameObject.SetActive(false);
        easyImage.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
        spawnWaveObject.gameObject.SetActive(true);
        PlayerShip.gameObject.SetActive(true);
        inGamePanel.gameObject.SetActive(true);
    }
    public void MediumDifficulty()
    {
        mainImage.gameObject.SetActive(false);
        mediumImage.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
        spawnWaveObject.gameObject.SetActive(true);
        PlayerShip.gameObject.SetActive(true);
        inGamePanel.gameObject.SetActive(true);
    }
    public void HardDifficulty()
    {
        mainImage.gameObject.SetActive(false);
        hardImage.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
        spawnWaveObject.gameObject.SetActive(true);
        PlayerShip.gameObject.SetActive(true);
        inGamePanel.gameObject.SetActive(true);
    }
    private void MusicSystem()
    {
        int songNum = Random.Range(0, musicClips.Count);
        gameMusic.clip = musicClips[songNum];
        gameMusic.volume = 0.5f;
        gameMusic.Play();
    }
    public void UpdateKills(int killToAdd)
    {
        Kills += killToAdd;
        killText.text = "Kills: " + Kills;
    }
    private void GamePause()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);   
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
