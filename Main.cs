using Godot;
using System;

public class Main : Node
{

    PackedScene new_cube;
    PackedScene new_cam;

    private Camera cameraMain;
    private Spatial cube;

    public float spacing_constant = 2.3f;

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Input.SetMouseMode(Input.MouseMode.Captured);

        int cube_size = 3;

        cube = addCube(cube_size);        
        cameraMain = addCamera(cube_size);
        
        Vector3 edge_select = new Vector3(0, 0, 1);

        //twistCube(cube, cube_size, edge_select, 1, 1);
    }

    public Camera addCamera(int cube_size)
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

        return camera;
    }

    public Spatial addCube(int cube_size)
    {
        new_cube = (PackedScene)ResourceLoader.Load("res://Cube.tscn");
        Spatial cube = (Spatial)new_cube.Instance();
        cube.Call("makeCube", cube_size, spacing_constant);
        AddChild(cube);

        return cube;
    }

    public void twistCube(Spatial cube, int size, Vector3 side_select, int direction, int times)
    {
        cube.Call("spinSide", size, side_select, direction, times);
    }

    public void rotateCamera_x(int key_x)
    {
        cube.RotateX(key_x/(float)Math.PI/10);

        return;
    }

    public void rotateCamera_y(int key_y)
    {
        cube.RotateY(key_y/(float)Math.PI/10);

        return;
    }

    public void rotateCamera_z(int key_z)
    {
        cube.RotateZ(key_z/(float)Math.PI/10);

        return;
    }

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if ((KeyList)keyEvent.Scancode == KeyList.W)
            {
                rotateCamera_x(1);
            }
            if ((KeyList)keyEvent.Scancode == KeyList.S)
            {
                rotateCamera_x(-1);
            }
            
            if ((KeyList)keyEvent.Scancode == KeyList.A)
            {
                rotateCamera_y(1);
            }
            if ((KeyList)keyEvent.Scancode == KeyList.D)
            {
                rotateCamera_y(-1);
            }
            
            if ((KeyList)keyEvent.Scancode == KeyList.E)
            {
                rotateCamera_z(1);
            }
            if ((KeyList)keyEvent.Scancode == KeyList.Q)
            {
                rotateCamera_z(-1);
            }
        }

        return;
    } 

    private void ProcessInput(float delta)
    {
        //     if (Input.IsActionJustPressed("ui_cancel"))
        // {
        //     if (Input.GetMouseMode() == Input.MouseMode.Visible)
        //         Input.SetMouseMode(Input.MouseMode.Captured);
        //     else
        //         Input.SetMouseMode(Input.MouseMode.Visible);
        // }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        ProcessInput(delta);
    }
}
