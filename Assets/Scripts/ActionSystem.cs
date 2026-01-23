using UnityEngine;

public class ActionSystem : MonoBehaviour
{
    public static ActionSystem Instance { get; private set; }

    public ActionList Actions { get; private set; } = new ActionList();

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;


    }

    private void Update()
    {
        Actions.Tick(Time.deltaTime);
    }
}
