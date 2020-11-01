using UnityEngine;

public class NavigationHandler : MonoBehaviour
{
    // Dependancies
    public GameObject player;
    public GameObject passengerSpawnPoint;
    public GameObject passengerDestination;

    // Scripts attached to dependancies
    private PlayerController _playerScript;
    private DeliveryPointController _spawnScript;
    private DeliveryPointController _destinationScript;

    // Components
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _playerScript = player.GetComponent<PlayerController>();
        _spawnScript = passengerSpawnPoint.GetComponent<DeliveryPointController>();
        _destinationScript = passengerDestination.GetComponent<DeliveryPointController>();

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!_playerScript.HavePassenger)
        {
            if (!_spawnScript.IsVisible)
            {
                _spriteRenderer.enabled = true;
                RotateTowards(passengerSpawnPoint.transform.position);
            }
            else
            {
                _spriteRenderer.enabled = false;
            }
        }
        else
        {
            if (!_destinationScript.IsVisible)
            {
                _spriteRenderer.enabled = true;
                RotateTowards(passengerDestination.transform.position);
            }

            else
            {
                _spriteRenderer.enabled = false;
            }
        }
    }

    private void RotateTowards(Vector3 position)
    {
        Vector3 forwardVector = transform.up * 2f;
        transform.up = position - transform.position;
        transform.position = player.transform.position + forwardVector;
        
    }
}
