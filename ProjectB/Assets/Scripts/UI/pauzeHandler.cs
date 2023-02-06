using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pauzeHandler : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] private MonoBehaviour[] pausedComponents;

    bool blocked = false;
    // Start is called before the first frame update
    void Start()
    {
    }


    void OnEnable()
    {
        blocked = true;
        StartCoroutine(unblock());
    }

    void OnDisable()
    {
       blocked = true;

    }

    IEnumerator unblock()
    {

        yield return new WaitForSecondsRealtime(0.2f);
        blocked = false;
        Debug.Log("thid");
    }

    public void pauzeGame(InputAction.CallbackContext context){
        if(!context.started)
            return;
        input = GetComponent<PlayerInput>();
        gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;

        foreach(MonoBehaviour component in pausedComponents)
            component.enabled = false;

        input.actions.FindActionMap("ingame").Disable();
        input.actions.FindActionMap("UI").Enable();

    }

    public void unPauze(){

        Debug.Log("try");
        if(blocked) return;
        Debug.Log("succeed");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1;
        
        input.actions.FindActionMap("ingame").Enable();
        input.actions.FindActionMap("UI").Disable();
        gameObject.SetActive(false);

    }

    private void Update()
    {
        print(blocked);
    }

    /// <summary>
    /// seperate unpauze function for when a context is given
    /// </summary>
    /// <param name="context"></param>
    public void unPauze(InputAction.CallbackContext context){
        if(!context.started)
            return;

        unPauze();
    }
}
