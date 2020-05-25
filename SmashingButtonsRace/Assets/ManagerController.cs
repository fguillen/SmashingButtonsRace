using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerController : MonoBehaviour
{
  public static ManagerController instance;

  public GameObject ballFloating;
  public Transform ballFloatingContactPoint;
  public Transform boxContactPoint;
  public GameObject ballFloatingDirectionArrow;
  public GameObject ballFloatingDistanceArrow;
  public float ballFloatingDistance;
  public Text ballFloatingDistanceText;
  public float ballFloatingAppliedForce = 1f;

  public GameObject ballRunning;
  public GameObject ballRunningVelocityArrow;
  public Text ballRunningVelocityText;
  public float ballRunningVelocity;
  public float ballRunningActualVelocity;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.Space))
    {
      ballFloating.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, ballFloatingAppliedForce, 0f));
    }

    CalculateBallFloatingDistance();
    CalculateBallRunningVelocity();
  }

  public void EndRace()
  {
    Debug.Log("Race ends");
  }

  void CalculateBallFloatingDistance()
  {
    ballFloatingDistance = ballFloatingContactPoint.transform.position.y - boxContactPoint.transform.position.y;
    ballFloatingDistanceText.text = ballFloatingDistance.ToString();
  }

  void CalculateBallRunningVelocity()
  {
    ballRunningActualVelocity = ballFloatingDistance * ballRunningVelocity;
    ballRunning.GetComponent<Rigidbody2D>().velocity = new Vector3(ballRunningActualVelocity, 0f, 0f);

    ballRunningVelocityText.text = ballRunningActualVelocity.ToString();
  }
}
