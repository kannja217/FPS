using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif
using StarterAssets;

#if ENABLE_INPUT_SYSTEM
[RequireComponent(typeof(PlayerInput))]
#endif
public class PlayerShot : MonoBehaviour
{
#if ENABLE_INPUT_SYSTEM
    private PlayerInput _playerInput;
#endif
    private StarterAssetsInputs _input;

    // Start is called before the first frame update
    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM
        _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif
    }

    // Update is called once per frame
    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if(_input.GetFireState)
            Debug.Log("Fire‚ª‰Ÿ‚³‚ê‚Ü‚µ‚½");
    }
}
