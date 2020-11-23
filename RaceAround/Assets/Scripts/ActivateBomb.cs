using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ActivateBomb : MonoBehaviour
{
    [SerializeField] private new Collider collider;

    [SerializeField] private float timeToActivate = 2f;

    [SerializeField] private ParticleSystem particleSystem;

    [SerializeField] private Transform energyField;
    
    private Vector3 scaleUpTo = new Vector3(2, 2, 2);
    
    [SerializeField]
    private Color chargedColor;
    
    private void Awake()
    {
        collider.enabled = false;
        StartCoroutine(ScaleUpAndDown(energyField, scaleUpTo, timeToActivate));
    }

    IEnumerator ScaleUpAndDown(Transform transform, Vector3 upScale, float duration)
    {
        Vector3 initialScale = transform.localScale;
        
        yield return new WaitForSeconds(1f);
        //energyField.gameObject.GetComponent<MeshRenderer>().enabled = true;
 
        for(float time = 0 ; time < duration ; time += Time.deltaTime)
        {
            transform.localScale = Vector3.Lerp(initialScale, upScale, time);
            yield return null;
        }
        energyField.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", chargedColor);
        collider.enabled = true;
        particleSystem.Play();
    }
}
