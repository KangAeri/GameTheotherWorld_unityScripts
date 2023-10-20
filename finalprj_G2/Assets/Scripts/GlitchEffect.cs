//using System.Collelctions;
//using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/GlitchEffect")]
[RequireComponent(typeof(Camera))]
public class GlitchEffect : MonoBehaviour
{
	public AudioClip gs;
	AudioSource audioSource;// = gameObject.GetComponent<AudioSource>();
	public Texture2D displacementMap;
	public Shader Shader;
	[Header("Glitch Intensity")]

	[Range(0, 1)]
	public float inten;

	[Range(0, 1)]
	public float flipInten;

	[Range(0, 1)]
	public float colorInten;
	//
	public float duration = 2.0f;
	public float citydur = 2.0f;
	public float gametocity = 6.0f;
	//

	private float _glitchup;
	private float _glitchdown;
	private float flicker;
	private float _glitchupTime = 0.05f;
	private float _glitchdownTime = 0.05f;
	private float _flickerTime = 0.5f;
	private Material _material;
	//
	private float gtimer;
	private float intimer;
	private bool glitchflag;

	[Range(0, 1)]
	private float intensity;

	[Range(0, 1)]
	private float flipIntensity;

	[Range(0, 1)]
	private float colorIntensity;

	void Start()
	{
		
		//gs=Resources.Load<AudioClip>("Glitch Sound Effects");
		_material = new Material(Shader);
		//
		gtimer = gametocity-duration;
		intimer = duration+citydur;
		glitchflag = false;
		
	}
	void Awake()
    {
		audioSource = GetComponent<AudioSource>();

    }
	void Update()
	{
		gtimer -= Time.deltaTime;
		if (gtimer <= 0)
		{
			glitchflag = true;
			
			//Debug.Log("glitch true");
			intimer -= Time.deltaTime;
			if (intimer <= 0)
			{
				
				gtimer = gametocity - duration;
				glitchflag = false;
				intimer = duration+citydur;
			}
		}
	}

	// Called by camera to apply image effect
	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (glitchflag == true)
		{
			audioSource.Play();
			//Debug.Log("glitch called");
			intensity = inten;
			flipIntensity = flipInten;
			colorIntensity = colorInten;
        }
        else
        {
			audioSource.Stop();
			//Debug.Log("glitch f called");
			intensity = 0.0f;
			colorIntensity = 0.0f;
			flipIntensity = 0.0f;
		}

			_material.SetFloat("_Intensity", intensity);
			_material.SetFloat("_ColorIntensity", colorIntensity);
			_material.SetTexture("_DispTex", displacementMap);

			flicker += Time.deltaTime * colorIntensity;
			if (flicker > _flickerTime)
			{
				_material.SetFloat("filterRadius", Random.Range(-3f, 3f) * colorIntensity);
				_material.SetVector("direction", Quaternion.AngleAxis(Random.Range(0, 360) * colorIntensity, Vector3.forward) * Vector4.one);
				flicker = 0;
				_flickerTime = Random.value;
			}

			if (colorIntensity == 0)
				_material.SetFloat("filterRadius", 0);

			_glitchup += Time.deltaTime * flipIntensity;
			if (_glitchup > _glitchupTime)
			{
				if (Random.value < 0.1f * flipIntensity)
					_material.SetFloat("flip_up", Random.Range(0, 1f) * flipIntensity);
				else
					_material.SetFloat("flip_up", 0);

				_glitchup = 0;
				_glitchupTime = Random.value / 10f;
			}

			if (flipIntensity == 0)
				_material.SetFloat("flip_up", 0);

			_glitchdown += Time.deltaTime * flipIntensity;
			if (_glitchdown > _glitchdownTime)
			{
				if (Random.value < 0.1f * flipIntensity)
					_material.SetFloat("flip_down", 1 - Random.Range(0, 1f) * flipIntensity);
				else
					_material.SetFloat("flip_down", 1);

				_glitchdown = 0;
				_glitchdownTime = Random.value / 10f;
			}

			if (flipIntensity == 0)
				_material.SetFloat("flip_down", 1);

			if (Random.value < 0.05 * intensity)
			{
				_material.SetFloat("displace", Random.value * intensity);
				_material.SetFloat("scale", 1 - Random.value * intensity);
			}
			else
				_material.SetFloat("displace", 0);

			Graphics.Blit(source, destination, _material);

        


		
	}
}