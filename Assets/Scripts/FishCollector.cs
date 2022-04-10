using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollector : MonoBehaviour
{
    private int Fish1=0;
    private int Fish2=0;
    private int Fish3=0;
    private int score=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {      
        score = Fish1 + Fish2 + Fish3;
    }
    void OnTriggerEnter(Collider other)
      {
          // the name pickUp should be the same in the unity of the prefab in the tag
          if (other.gameObject.tag == "fish1") {
              other.gameObject.SetActive(false);
              score = 5 + score; // to make the score increasing by 5
              Destroy (other.gameObject);
          }
          if (other.gameObject.tag == "fish2") {
              other.gameObject.SetActive(false);
              score = 10 + score; // to make the score increasing by 10
              Destroy (other.gameObject);
          }
          if (other.gameObject.tag == "fish3") {
              other.gameObject.SetActive(false);
              score = 20 + score; // to make the score increasing by 20
              Destroy (other.gameObject);
          }
      }
    // Update is called once per frame
    void Update()
    {
        
    }
}
