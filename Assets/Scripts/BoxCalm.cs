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
                correctPartilce.Play();
                GameManager.Instance.score++;
                GameManager.Instance.isTakeItem = false;
                break;
            case "BearCalm":
                correctPartilce.Play();
                GameManager.Instance.score++;
                GameManager.Instance.isTakeItem = false;
                break;
            case "PhotoCalm":
                correctPartilce.Play();
                GameManager.Instance.score++;
                GameManager.Instance.isTakeItem = false;
                break;
            case "BallAngry":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                GameManager.Instance.isTakeItem = false;
                break;
            case "BearHurt":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                GameManager.Instance.isTakeItem = false;
                break;
            case "PhotoHurt":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                GameManager.Instance.isTakeItem = false;
                break;
            default:
                break;
        }
    }
}
