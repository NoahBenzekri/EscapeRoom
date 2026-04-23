using NUnit.Framework;
using UnityEngine;

public class PaintingChangerTests
{
    private GameObject testObject;
    private PaintingChanger changer;

    [SetUp]
    public void Setup()
    {
        // Create a GameObject with a Renderer (required by PaintingChanger)
        testObject = new GameObject();

        // Add a Cube primitive which has a Renderer by default
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "PaintingObject";

        // Move our PaintingChanger to that cube
        changer = cube.AddComponent<PaintingChanger>();

        // Create fake materials
        changer.Paintings = new Material[3];
        for (int i = 0; i < 3; i++)
        {
            changer.Paintings[i] = new Material(Shader.Find("Standard"));
        }
        changer.Speed = 1f;

        // Store reference for cleanup
        testObject = cube;
    }

    [TearDown]
    public void TearDown()
    {
        UnityEngine.Object.DestroyImmediate(testObject);
    }

    [Test]
    public void Stop_SetsIsStoppedToTrue()
    {
        changer.Stop();
        Assert.IsTrue(changer.IsStopped());
    }

    [Test]
    public void Resume_SetsIsStoppedToFalse()
    {
        changer.Stop();
        changer.Resume();
        Assert.IsFalse(changer.IsStopped());
    }
}