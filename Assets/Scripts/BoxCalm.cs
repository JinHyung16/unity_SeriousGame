using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCalm : MonoBehaviour
{
    public ParticleSystem correctPartilce;
    public ParticleSystem inCorrectPartilce;

    private void ParticlePlay()
    {
        switch (GameManager.Instance.ItemName)
        {
            case "BallSmile":
                correctPartilce.Play();
                GameManager.Instance.score++;
                break;
            case "BearCalm":
                correctPartilce.Play();
                GameManager.Instance.score++;
                break;
            case "PhotoCalm":
                correctPartilce.Play();
                GameManager.Instance.score++;
                break;
            case "BallAngry":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                break;
            case "BearHurt":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                break;
            case "PhotoHurt":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ParticlePlay();
        }
    }
}
