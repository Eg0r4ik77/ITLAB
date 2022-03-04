using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    void Start()
    {
        PauseManager.Instance.TrySetPaused(true);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PauseManager.Instance.TrySetPaused(false);
        }   
    }

}
