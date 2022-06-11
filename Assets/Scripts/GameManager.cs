using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

sealed class GameManager : MonoBehaviour
{
	#region SingleTon
	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null)
			{
				return null;
			}

			return instance;
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;

			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
	#endregion

	AudioSource audio;

	public AudioClip bgmClip;

	// public ObjectPooling poolManager;
	public TextReader textReader;

	public GameObject boxCalm;
	public GameObject boxHurt;

	public Transform[] boxSpawnPos = new Transform[2];

	[SerializeField] private float playTime = 60.2f; // game play time
	private float startTime;

	[SerializeField] private float spawnTime = 5.5f;
	[SerializeField] private float boxChangeTime = 7.5f;

	private string[] itemNames = { "ballSmile", "ballAngry", "bearCalm", "bearHurt", "photoCalm", "photoHurt" };

	[HideInInspector] public string ItemName;

	public int score = 0;
	public int life = 3;

	public int itemIndex = -1;

	public bool isTakeItem = false;

	public Sprite[] itemSprites;

	// about UI
	public GameObject startPanel;
	public GameObject resultPanel;

	public Button startButton;
	public Button restartButton;

	public Image invenImg;
	public Image[] lifeImgs;

	public Text sentenceText;
	public Text timerText;
	public Text scoreText;
	public Text resultText;

    private void Start()
    {
		audio = GetComponent<AudioSource>();

		Time.timeScale = 0;

		startTime = Time.time;

		startPanel.SetActive(true);
		resultPanel.SetActive(false);

		startButton.onClick.AddListener(GameStart);
		restartButton.onClick.AddListener(ReStart);

		if(life != 3)
        {
			life = 3;
		}

		score = 0;
		itemIndex = -1;
	}

    private void Update()
    {
		Timer();
		InvenSetting();
		ScoreDisplayUpdate();
	}

	IEnumerator SpawnItem()
    {
		while(true)
        {
			int index = Random.Range(0, 6);
			int xPos = Random.Range(-7, 8);
			int zPos = Random.Range(-2, 4);

			if((xPos == 0 && zPos == 0))
            {
				xPos = Random.Range(-7, 8);
				zPos = Random.Range(-2, 4);
			}

			GameObject item = ObjectPooling.Instance.MakeItem(itemNames[index]);
			item.transform.position = new Vector3(xPos - 0.5f, -1, zPos - 0.5f);
			item.SetActive(true);
			yield return Cashing.YieldInstruction.WaitForSeconds(spawnTime);
        }
    }

	IEnumerator BoxPosition()
    {
		while(true)
        {
			int posOne = Random.Range(0, 2);
			int posTwo = -1;

			if(posOne == 0)
            {
				posTwo = posOne + 1;
			}
			else if(posOne == 1)
            {
				posTwo = posOne - 1;

			}

			boxCalm.transform.position = boxSpawnPos[posOne].position;
			boxHurt.transform.position = boxSpawnPos[posTwo].position;
			yield return Cashing.YieldInstruction.WaitForSeconds(boxChangeTime);
		}
    }

	private void InitItemSpawn()
    {
		// init spawn
		for (int i = 0; i < 12; i++)
		{
			int index = i % 6;
			GameObject item = ObjectPooling.Instance.MakeItem(itemNames[index]);
			int xPos = Random.Range(-6, 8);
			int zPos = Random.Range(-2, 3);
			item.transform.position = new Vector3(xPos, -1, zPos);
			item.SetActive(true);
		}
	}

	private void Timer()
    {
		playTime -= (Time.deltaTime - startTime);
		timerText.text = playTime.ToString("F2"); // 소수점 2번째 자리까지 표시

		if(playTime < 0.0f)
        {
			GameOver();
			playTime = 0.2f;
		}
	}

	private void GameStart()
    {
		InitItemSpawn();
		startPanel.SetActive(false);
		resultPanel.SetActive(false);
		sentenceText.text = " ";

		BGMPlay();

		StartCoroutine(SpawnItem());
		StartCoroutine(BoxPosition());

		Time.timeScale = 1;
	}

	private void ReStart()
    {
		SceneManager.LoadScene(0);

		startPanel.SetActive(false);
		resultPanel.SetActive(false);

		sentenceText.text = " ";

		itemIndex = -1;
		score = 0;
		life = 3;
		playTime = 60.2f;
		isTakeItem = false;

		for (int i = 0; i < lifeImgs.Length; i++)
		{
			lifeImgs[i].color = new Color(1, 1, 1, 1);
		}

		InvenSetting();
		InitItemSpawn();
		BGMPlay();

		Time.timeScale = 1;
	}

	private void GameOver()
    {
		startPanel.SetActive(false);
		resultPanel.SetActive(true);

		resultText.text = sentenceText.text;

		ObjectPooling.Instance.ResetItem();
		audio.Stop();

		Time.timeScale = 0;
    }

	private void ScoreDisplayUpdate()
    {
		if(score <= 0)
        {
			score = 0;
        }
		scoreText.text = score.ToString();
	}

	private void InvenSetting()
    {
		switch(itemIndex)
        {
			case 0:
				invenImg.sprite = itemSprites[itemIndex];
				break;
			case 1:
				invenImg.sprite = itemSprites[itemIndex];
				break;
			case 2:
				invenImg.sprite = itemSprites[itemIndex];
				break;
			case 3:
				invenImg.sprite = itemSprites[itemIndex];
				break;
			case 4:
				invenImg.sprite = itemSprites[itemIndex];
				break;
			case 5:
				invenImg.sprite = itemSprites[itemIndex];
				break;
			default:
				invenImg.sprite = itemSprites[6];
				break;
		}
    }

	private void BGMPlay()
    {
		audio.clip = bgmClip;
		audio.Play();
    }
	public void SentenceDisplayUpdate(int index)
	{
		sentenceText.text = textReader.TextReturn(index);
	}

	public void LifeDown()
    {
		if(0 < life)
        {
			life--;
			lifeImgs[life].color = new Color(0, 0, 0, 0);
        }

		if (life == 0)
		{
			lifeImgs[0].color = new Color(0, 0, 0, 0);
			GameOver();
		}
    }

	public void TakeItem(string name)
    {
		switch(name)
        {
			case "BallSmile":
				ItemName = name;
				itemIndex = 0;
				break;
			case "BallAngry":
				ItemName = name;
				itemIndex = 1;
				break;
			case "BearCalm":
				ItemName = name;
				itemIndex = 2;
				break;
			case "BearHurt":
				ItemName = name;
				itemIndex = 3;
				break;
			case "PhotoCalm":
				ItemName = name;
				itemIndex = 4;
				break;
			case "PhotoHurt":
				ItemName = name;
				itemIndex = 5;
				break;
			default:
				ItemName = name;
				itemIndex = -1;
				isTakeItem = false;
				break;
		}
    }
}
