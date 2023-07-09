using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    [SerializeField] PostProcessVolume post_process;
    private Bloom bloom;
    private ChromaticAberration chromatic_effect;
    // Start is called before the first frame update
    private void Start()
    {
        post_process.profile.TryGetSettings(out bloom);
        post_process.profile.TryGetSettings(out chromatic_effect);
    }
    public void bloom_toggle(bool on)
    {
        bloom.enabled.value = on;
    }
    public void chromatic_toggle(bool on)
    {
        chromatic_effect.enabled.value = on;
    }
}
