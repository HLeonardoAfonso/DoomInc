using UnityEngine;
using System.Collections;

public class DeathEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem popParticles;
    [SerializeField] float growDuration = 0.3f;
    [SerializeField] float maxScale = 2.5f;
    [SerializeField] AnimationCurve growCurve;

    public void PlayDeathEffect()
    {
        StartCoroutine(GrowAndPop());
    }

    IEnumerator GrowAndPop()
    {
        float elapsed = 0f;
        Vector3 originalScale = transform.localScale;

        while (elapsed < growDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / growDuration;
            float curveValue = growCurve.Evaluate(t); // gives non-linear feel
            transform.localScale = originalScale * Mathf.Lerp(1f, maxScale, curveValue);
            yield return null;
        }

        // Snap to max scale then pop
        transform.localScale = originalScale * maxScale;
        popParticles.transform.SetParent(null); // detach so it survives destroy
        popParticles.Play();
        Destroy(gameObject);
    }
}