using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    [Range(1, 4)]
    public int Tanks;

    [Range(1, 100)]
    public int Width;

    [Range(1, 100)]
    public int Height;

    public Map map;

    public GameObject NewLine;

    public int PrefabLine;

    public List<LineRenderer> LinesRenders = new List<LineRenderer>();

    // Start is called before the first frame update
    void Start()
    {
        // -- Set by scene manager --
        Tanks = 2;
        Width = 10;
        Height = 10;
        // -- end --

        map = new Map(Tanks);
        map.ProceduralGenerate(Width, Height);

        // Render the lines
        //print("" + map.Lines.Count);
        //float xScale = Camera.allCameras[0].scaledPixelWidth / (float)map.Width;
        //float yScale = Camera.allCameras[0].scaledPixelHeight / (float)map.Height;
        //xScale = Mathf.Min(xScale, yScale);
        //yScale = Mathf.Min(xScale, yScale);
        float xScale = 0.5f;
        float yScale = 0.5f;
        xScale = Mathf.Min(xScale, yScale);
        yScale = Mathf.Min(xScale, yScale);

        for (int i = 0; i < map.Lines.Count; i++)
        {
            var linePos = map.Lines[i];
            float x1 = linePos.x1 * xScale;
            float x2 = linePos.x2 * xScale;
            float y1 = linePos.y1 * yScale;
            float y2 = linePos.y2 * yScale;

            LineRenderer line = NewLine.GetComponent<LineRenderer>();
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;

            //line.sharedMaterial.SetColor("_Color", Color.red);
            line.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));


            //line.startColor = Color.red;
            //line.endColor = Color.green;
            //line.SetColors(Color.red, Color.green);

            var g = line.colorGradient;
            g.mode = GradientMode.Fixed;
            g.colorKeys = new GradientColorKey[] { new GradientColorKey(Color.red, 1) };
            line.colorGradient = g;
            //g.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.red, 1f) },
            //    new GradientAlphaKey[] { new GradientAlphaKey(1f, 1f) });

            Vector3 Start = new Vector3(x1 - 2.5f, y1 - 2.5f);
            Vector3 End = new Vector3(x2 - 2.5f, y2 - 2.5f);
            line.SetPositions(new Vector3[] { Start, End });
            LinesRenders.Add(line);
            Instantiate(line);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
