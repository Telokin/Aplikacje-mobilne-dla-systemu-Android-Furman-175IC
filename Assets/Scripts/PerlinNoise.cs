using System.Data;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;



    private void Update()
    {
       Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();

    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x =0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                
                texture.SetPixel(x, y, color);
            }
        }


        texture.Apply();
        return texture;
    }

    Color CalculateColor (int x, int y )
    {
        x = Random.Range(0, 255);
        y = Random.Range(0, 255);
        float xCoord = (float)x / width;
        float yCoord = (float)y / height;
       
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, 255);
    }
}
