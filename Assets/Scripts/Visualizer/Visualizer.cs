using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour {
    public float Distance;
    [SerializeField]
    private readonly int sampleSize = 1024;

    [SerializeField]
    private GameObject visualizerLine;

    [SerializeField]
    private float spectrumPercentage = 0.5f;
    [SerializeField]
    private float maxLineScale = 25.0f;
    [SerializeField]
    private float visualizerStrenght = 20.0f;
    [SerializeField]
    private float smoothSpeed = 10.0f;

    [SerializeField]
    private float rmsValue;
    [SerializeField]
    private float dbValue;
    [SerializeField]
    private float pitchValue;

    private AudioSource source;
    private float[] samples;
    private float[] spectrum;
    private float samplerate;

    private Transform[] lineListL;
    private Transform[] lineListR;
    private float[] lineScale;
    [SerializeField]
    private int lineAmount = 128;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        samples = new float[sampleSize];
        spectrum = new float[sampleSize];
        samplerate = AudioSettings.outputSampleRate;
        SpawnLine();
    }

    private void SpawnLine()
    {
        lineScale = new float[lineAmount];
        lineListL = new Transform[lineAmount];
        lineListR = new Transform[lineAmount];
        GameObject masterVisualizer = new GameObject("Visualizer");
        GameObject L = new GameObject("Left Visualizer"); L.transform.parent = masterVisualizer.transform;
        GameObject R = new GameObject("Right Visualizer"); R.transform.parent = masterVisualizer.transform;

        for (int i = 0; i < lineAmount; i++)
        {
            //GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;

            // instantiate Left bars
            GameObject go = Instantiate(visualizerLine);
            go.transform.parent = L.transform;
            go.name = "VisualizerL" + i;
            lineListL[i] = go.transform;
            lineListL[i].position = new Vector3(-Distance, 0,(0.4f * i));

            // instantiate Right bars
            go = Instantiate(visualizerLine);
            go.transform.parent = R.transform;
            go.name = "VisualizerR" + i;
            lineListR[i] = go.transform;
            lineListR[i].position = new Vector3(Distance,0,(0.4f * i));
        }
    }

    private void Update()
    {
        AnalyzeSpectrum();
        UpdateVisualiser();
    }

    private void UpdateVisualiser()
    {
        int visualIndex = 0;
        int spectrumIndex = 0;
        int averageSize = (int)((sampleSize * spectrumPercentage) / lineAmount);

        while (visualIndex < lineAmount)
        {
            int j = 0;
            float sum = 0;
            while (j < averageSize)
            {
                sum += spectrum[spectrumIndex];
                spectrumIndex++;
                j++;
            }

            float scaleY = sum / averageSize * visualizerStrenght;
            lineScale[visualIndex] -= Time.deltaTime * smoothSpeed;
            if (lineScale[visualIndex] < scaleY)
                lineScale[visualIndex] = scaleY;

            if (lineScale[visualIndex] > maxLineScale)
                lineScale[visualIndex] = maxLineScale;

            lineListR[visualIndex].localScale = new Vector3(0.2f, 2 * lineScale[visualIndex], 0.2f);
            lineListL[visualIndex].localScale = new Vector3(0.2f, 2 * lineScale[visualIndex], 0.2f);
            visualIndex++;
        }
    }


    // Get the audio spectrum from whatever audio the audio emitter is playing
    private void AnalyzeSpectrum()
    {
        source.GetOutputData(samples, 0);

        // get rmsValue
        float sum = 0;
        for (int i = 0; i < sampleSize; i++)
        {
            sum += samples[i] * samples[i];
        }
        rmsValue = Mathf.Sqrt(sum / sampleSize);

        // get dbValue
        dbValue = 20 * Mathf.Log10(rmsValue / 0.1f);

        // get sound spectrum
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        // get pitch
        float maxV = 0;
        var maxN = 0;
        for (int i = 0; i < sampleSize; i++)
        {
            if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
                continue;
            maxV = spectrum[i];
            maxN = i;
        }

        // get frequency
        float freqN = maxN;
        if (maxN > 0 && maxN < sampleSize -1)
        {
            var dL = spectrum[maxN - 1] / spectrum[maxN];
            var dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchValue = freqN * (samplerate / 2) / sampleSize;
    }


    // function to use values in other scripts
    public Dictionary<string, float> getAudioData()
    {
        Dictionary<string, float> dict = new Dictionary<string, float>();

        dict.Add("rms", rmsValue);
        dict.Add("db", dbValue);
        dict.Add("pitch", pitchValue);

        return dict;
    }
}
