using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danoAtaque;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;

    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1")&& tiempoSiguienteAtaque <=0)
        {
            Ataque();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

    // Start is called before the first frame update
    private void Ataque()
    {
        playerAnimator.SetTrigger("Ataque");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Villian"))
            {
                colisionador.transform.GetComponent<Enemigo>().TomarDano(danoAtaque);

            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
