using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHurt : MonoBehaviour
{
    public ParticleSystem correctPartilce;
    public ParticleSystem inCorrectPartilce;

    private void ParticlePlay()
    {
        switch(GameManager.Instance.ItemName)
        {
			case "BallSmile":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                break;
			case "BearCalm":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                break;
            case "PhotoCalm":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                break;
            case "BallAngry":
                correctPartilce.Play();
                GameManager.Instance.score++;
                break;
            case "BearHurt":
                correctPartilce.Play();
                GameManager.Instance.score++;
                break;
			case "PhotoHurt":
                correctPartilce.Play();
                GameManager.Instance.score++;
                break;
            default:
                break;
		}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ParticlePlay();
        }
    }
}
