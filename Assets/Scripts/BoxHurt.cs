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
                {
                    inCorrectPartilce.Play();
                    GameManager.Instance.score--;
                    GameManager.Instance.LifeDown();
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(4, 8);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
			case "BearCalm":
                {
                    inCorrectPartilce.Play();
                    GameManager.Instance.score--;
                    GameManager.Instance.LifeDown();
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(4, 8);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            case "PhotoCalm":
                {
                    inCorrectPartilce.Play();
                    GameManager.Instance.score--;
                    GameManager.Instance.LifeDown();
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(4, 8);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            case "BallAngry":
                {
                    correctPartilce.Play();
                    GameManager.Instance.score++;
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(0, 4);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            case "BearHurt":
                {
                    correctPartilce.Play();
                    GameManager.Instance.score++;
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(0, 4);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
			case "PhotoHurt":
                {
                    correctPartilce.Play();
                    GameManager.Instance.score++;
                    GameManager.Instance.isTakeItem = false;
                    int index = Random.Range(0, 4);
                    GameManager.Instance.SentenceDisplayUpdate(index);
                }
                break;
            default:
                break;
		}
    }
}
