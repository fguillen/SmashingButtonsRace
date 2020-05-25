using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIController : MonoBehaviour
{
  public static UIController instance;
  public Text resultText;

  private void Awake()
  {
    instance = this;
  }
  // Start is called before the first frame update
  void Start()
  {
    resultText.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  public void ShowResult(float seconds)
  {
    seconds = Mathf.Round(seconds * 100) / 100f;
    resultText.text = "Finished on " + seconds + " seconds";
    resultText.gameObject.SetActive(true);
  }
}
