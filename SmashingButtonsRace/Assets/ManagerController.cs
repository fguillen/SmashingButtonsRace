using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerController : MonoBehaviour
{
  public static ManagerController instance;

  // Ball floating
  public GameObject ballFloating;
  public Transform ballFloatingContactPoint;
  public Transform boxContactPoint;
  public float ballFloatingSpringConstant;
  private float ballFloatingSpringForce;
  private float ballFloatingDistance;
  public Text ballFloatingSpringForceText;
  public Text ballFloatingDistanceText;
  public float ballFloatingAppliedForce;

  // Ball running
  public GameObject ballRunning;
  public Text ballRunningVelocityText;
  public float ballRunningVelocity;
  public float ballRunningActualVelocity;

  private string state;
  private float startTime;


  private void Awake()
  {
    instance = this;
    state = "idle";
  }

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {

    StartRace();
    AddFloatingForce();
    CalculateBallFloatingDistance();
    CalculateBallRunningVelocity();
    CalculateFloatingBallSpringForce();
  }

  void StartRace()
  {
    if(state == "idle" && Input.GetKeyDown(KeyCode.Space))
    {
      state = "playing";
      startTime = Time.time;
    }
  }

  public void EndRace()
  {
    state = "end";
    Debug.Log("Race ends");
    UIController.instance.ShowResult(CalculateRaceTime());
  }

  void AddFloatingForce()
  {
    if (state == "playing" && Input.GetKeyDown(KeyCode.Space))
    {
      ballFloating.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, ballFloatingAppliedForce, 0f));
    }
  }

  float CalculateRaceTime()
  {
    return Time.time - startTime;
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


  // F=kx
  // - https://en.wikipedia.org/wiki/Hooke's_law
  void CalculateFloatingBallSpringForce()
  {
    ballFloatingSpringForce = ballFloatingSpringConstant * ballFloatingDistance;
    ballFloating.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, ballFloatingSpringForce * -1, 0f));

    ballFloatingSpringForceText.text = ballFloatingSpringForce.ToString();
  }
}
