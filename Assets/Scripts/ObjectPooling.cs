using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed class ObjectPooling : MonoBehaviour
{
    #region SignleTon
    private static ObjectPooling instance;
    public static ObjectPooling Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            Setting();
            Pooling();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public GameObject ballSmilePrefab;
    public GameObject ballAngryPrefab;
    public GameObject bearCalmPrefab;
    public GameObject bearHurtPrefab;
    public GameObject photoCalmPrefab;
    public GameObject photoHurtPrefab;

    GameObject[] ballSmiles;
    GameObject[] ballAngries;
    GameObject[] bearCalms;
    GameObject[] bearHurts;
    GameObject[] photoCalms;
    GameObject[] photoHurts;

    GameObject[] targets;

    private void Setting()
    {
        ballSmiles = new GameObject[10];
        ballAngries = new GameObject[10];
        bearCalms = new GameObject[10];
        bearHurts = new GameObject[10];
        photoCalms = new GameObject[10];
        photoHurts = new GameObject[10];
    }

	private void Pooling()
    {
        for (int i = 0; i < ballSmiles.Length; i++)
        {
            ballSmiles[i] = Instantiate(ballSmilePrefab);
            ballSmiles[i].name = "BallSmile";
            ballSmiles[i].SetActive(false);

            DontDestroyOnLoad(ballSmiles[i]);
        }
        for (int i = 0; i < ballAngries.Length; i++)
        {
            ballAngries[i] = Instantiate(ballAngryPrefab);
            ballAngries[i].name = "BallAngry";
            ballAngries[i].SetActive(false);

            DontDestroyOnLoad(ballAngries[i]);
        }
        for (int i = 0; i < bearCalms.Length; i++)
        {
            bearCalms[i] = Instantiate(bearCalmPrefab);
            bearCalms[i].name = "BearCalm";
            bearCalms[i].SetActive(false);

            DontDestroyOnLoad(bearCalms[i]);
        }
        for (int i = 0; i < bearHurts.Length; i++)
        {
            bearHurts[i] = Instantiate(bearHurtPrefab);
            bearHurts[i].name = "BearHurt";
            bearHurts[i].SetActive(false);

            DontDestroyOnLoad(bearHurts[i]);
        }
        for (int i = 0; i < photoCalms.Length; i++)
        {
            photoCalms[i] = Instantiate(photoCalmPrefab);
            photoCalms[i].name = "PhotoCalm";
            photoCalms[i].SetActive(false);

            DontDestroyOnLoad(photoCalms[i]);
        }
        for (int i = 0; i < photoHurts.Length; i++)
        {
            photoHurts[i] = Instantiate(photoHurtPrefab);
            photoHurts[i].name = "PhotoHurt";
            photoHurts[i].SetActive(false);

            DontDestroyOnLoad(photoHurts[i]);
        }
    }

    public GameObject MakeItem(string name)
    {
        switch(name)
        {
            case "ballSmile":
                targets = ballSmiles;
                break;
            case "ballAngry":
                targets = ballAngries;
                break;
            case "bearCalm":
                targets = bearCalms;
                break;
            case "bearHurt":
                targets = bearHurts;
                break;
            case "photoCalm":
                targets = photoCalms;
                break;
            case "photoHurt":
                targets = photoHurts;
                break;
        }

        for (int i = 0; i < targets.Length; i++)
        {
            if (!targets[i].activeSelf)
            {
                targets[i].SetActive(true);
                return targets[i];
            }
        }
        return null;
    }

    public void ResetItem()
    {
        for (int i = 0; i < ballSmiles.Length; i++)
        {
            ballSmiles[i].SetActive(false);
        }
        for (int i = 0; i < ballAngries.Length; i++)
        {
            ballAngries[i].SetActive(false);
        }
        for (int i = 0; i < bearCalms.Length; i++)
        {
            bearCalms[i].SetActive(false);
        }
        for (int i = 0; i < bearHurts.Length; i++)
        {
            bearHurts[i].SetActive(false);
        }
        for (int i = 0; i < photoCalms.Length; i++)
        {
            photoCalms[i].SetActive(false);
        }
        for (int i = 0; i < photoHurts.Length; i++)
        {
            photoHurts[i].SetActive(false);
        }
    }
}