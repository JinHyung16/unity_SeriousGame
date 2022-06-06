using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHurt : MonoBehaviour
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
        switch(GameManager.Instance.ItemName)
        {
			case "BallSmile":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                GameManager.Instance.isTakeItem = false;
                break;
			case "BearCalm":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                GameManager.Instance.isTakeItem = false;
                break;
            case "PhotoCalm":
                inCorrectPartilce.Play();
                GameManager.Instance.score--;
                GameManager.Instance.LifeDown();
                GameManager.Instance.isTakeItem = false;
                break;
            case "BallAngry":
                correctPartilce.Play();
                GameManager.Instance.score++;
                GameManager.Instance.isTakeItem = false;
                break;
            case "BearHurt":
                correctPartilce.Play();
                GameManager.Instance.score++;
                GameManager.Instance.isTakeItem = false;
                break;
			case "PhotoHurt":
                correctPartilce.Play();
                GameManager.Instance.score++;
                GameManager.Instance.isTakeItem = false;
                break;
            default:
                break;
		}
    }
}
