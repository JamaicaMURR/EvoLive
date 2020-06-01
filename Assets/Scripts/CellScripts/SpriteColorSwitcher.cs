using UnityEngine;
using System.Collections;

public class SpriteColorSwitcher : MonoBehaviour
{
	public SpriteRenderer target;
    public SpriteRenderer follower;

	public Color inDark;
	public Color inLight;

	public void Switch ()
	{
		if (target.color.grayscale < 0.5f)
			follower.color = inDark;
		else
			follower.color = inLight;
	}
}
