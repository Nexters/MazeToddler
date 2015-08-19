using System.Collections;
using UnityEngine;

//namespace UnityStandardAssets.ImageEffects
//{
[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Displacement/Twirl")]
public class Twirl : ImageEffectBase
{
    public Vector2 radius = new Vector2(0.3F,0.3F);
    public float angle = 50;
    public Vector2 center = new Vector2 (0.5F, 0.5F);

	bool renderImageCalled = false;
	bool lerping = false;
	bool distortToNegative = true;
	float timer;
	//RenderTexture _source;
	//RenderTexture _destination;

    // Called by camera to apply image effect
    void OnRenderImage (RenderTexture source, RenderTexture destination)
    {
		//_source = source;
		//_destination = destination;
		renderImageCalled = true;
		if (!lerping) {
			if(distortToNegative)
				StartCoroutine (DistortToNegative());
			else
				StartCoroutine (DistortToPositive());
		}

		ImageEffects.RenderDistortion (material, source, destination, angle, center, radius);
    }

	IEnumerator DistortToNegative() {
		lerping = true;
		timer = 0f;
		float _angle = angle;
		while (true) {
			renderImageCalled = false;
			timer += Time.deltaTime * 0.3f;
			angle = Mathf.Lerp (_angle, -4f, timer);
			//ImageEffects.RenderDistortion (material, _source, _destination, angle, center, radius);
			while(!renderImageCalled)
				yield return null;
			if(angle <= -4f)
				break;
		}
		lerping = false;
		distortToNegative = false;
	}

	IEnumerator DistortToPositive() {
		lerping = true;
		timer = 0f;
		float _angle = angle;
		while (true) {
			renderImageCalled = false;
			timer += Time.deltaTime * 0.3f;
			angle = Mathf.Lerp (_angle, 4f, timer);
			//ImageEffects.RenderDistortion (material, _source, _destination, angle, center, radius);
			while(!renderImageCalled)
				yield return null;
			if(angle >= 4f)
				break;
		}
		lerping = false;
		distortToNegative = true;
	}
}
//}
