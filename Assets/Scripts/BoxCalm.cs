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
        GameManager cameManager = GameManager.Instance;
        switch (GameManager.Instance.ItemName)
        {
            case "PhotoCalm":
            case "BearCalm":
            case "BallSmile":
                {
                    correctPartilce.Play();
                    cameManager.score++;
                    cameManager.isTakeItem = false;
                    int index = Random.Range(0, 4);
                    cameManager.SentenceDisplayUpdate(index);
                }
                break;
            case "PhotoHurt":
            case "BearHurt":
            case "BallAngry":
                {
                    inCorrectPartilce.Play();
                    cameManager.score--;
                    cameManager.LifeDown();
                    cameManager.isTakeItem = false;
                    int index = Random.Range(4, 8);
                    cameManager.SentenceDisplayUpdate(index);
                }
                break;
            default:
                break;
        }
    }
}
