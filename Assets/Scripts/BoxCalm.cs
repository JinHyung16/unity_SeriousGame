using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCalm : MonoBehaviour
{
    public ParticleSystem correctPartilce;
    public ParticleSystem inCorrectPartilce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ItemCheck();
            GameManager.Instance.TakeItem("None");
        }
    }

    private void ItemCheck()
    {
        switch (GameManager.Instance.ItemName)
        {
            case "BallSmile":
                {
                    correctPartilce.Play();
                    GameManager.Instance.score++;
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(0, 4);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            case "BearCalm":
                {
                    correctPartilce.Play();
                    GameManager.Instance.score++;
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(0, 4);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            case "PhotoCalm":
                {
                    correctPartilce.Play();
                    GameManager.Instance.score++;
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(0, 4);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            case "BallAngry":
                {
                    inCorrectPartilce.Play();
                    GameManager.Instance.score--;
                    GameManager.Instance.LifeDown();
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(4, 8);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            case "BearHurt":
                {
                    inCorrectPartilce.Play();
                    GameManager.Instance.score--;
                    GameManager.Instance.LifeDown();
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(4, 8);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            case "PhotoHurt":
                {
                    inCorrectPartilce.Play();
                    GameManager.Instance.score--;
                    GameManager.Instance.LifeDown();
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(4, 8);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            default:
                break;
        }
    }
}
