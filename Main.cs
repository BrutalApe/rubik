using Godot;
using System;

public class Main : Node
{

    PackedScene new_cube;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        int cube_size = 3;

        Spatial cube = addCube(cube_size);
        
        addCamera(cube_size);
        
        Vector3 edge_select = new Vector3(0, 0, 1);

        twistCube(cube, cube_size, edge_select, 1, 1);
    }

    public void addCamera(int cube_size)
    {
        Camera camera = new Camera{};
        AddChild(camera);

        camera.Current = true;

        Vector3 new_loc = new Vector3();
        Vector3 new_rot = new Vector3();

        // all values should change for translation depending on size
        new_loc.x = -5;
        new_loc.y = ((cube_size+2) * 2.2f);
        new_loc.z = -5;
        new_rot.x = -30f;
        new_rot.y = -135f;
        new_rot.z = 0f;

        camera.Translate(new_loc);
        camera.RotationDegrees = new_rot;
    }

    public Spatial addCube(int cube_size)
    {
        new_cube = (PackedScene)ResourceLoader.Load("res://Cube.tscn");
        Spatial cube = (Spatial)new_cube.Instance();
        cube.Call("makeCube", cube_size);
        AddChild(cube);

        return cube;
    }

    public void twistCube(Spatial cube, int size, Vector3 side_select, int direction, int times)
    {
        cube.Call("spinSide", size, side_select, direction, times);
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
