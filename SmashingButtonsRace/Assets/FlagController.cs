using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
  private Animator animator;

  private void Awake()
  {
    animator = GetComponent<Animator>();
  }
  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("RunningBall"))
    {
      animator.SetTrigger("moveFlag");
      ManagerController.instance.EndRace();
    }
  }
}
