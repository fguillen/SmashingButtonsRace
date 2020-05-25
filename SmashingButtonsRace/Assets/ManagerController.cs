using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerController : MonoBehaviour
{
  public GameObject ballFloating;
  public GameObject ballFloatingDirection;
  public GameObject ballFloatingScale;
  public Text ballFloatingScaleText;
  public float ballFloatingAppliedForce = 1f;

  public GameObject ballRunning;
  public GameObject ballRunningVelocity;
  public Text ballRunninngVelocity;

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.Space))
    {
      ballFloating.GetComponent<Rigidbody>().AddForce(new Vector3(0f, ballFloatingAppliedForce, 0f));
    }
  }
}
