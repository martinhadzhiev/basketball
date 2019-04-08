using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    public GameObject text;

    public void OnTriggerExit(Collider colider)
    {
        var result = int.Parse(text.GetComponent<Text>().text) + 1;

        text.GetComponent<Text>().text = result.ToString();
    }
    
}
