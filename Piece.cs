using Godot;
using System;

public class Piece : Area
{
    public Vector3 original_coord = new Vector3(0, 0, 0);
    public Vector3 current_coord = new Vector3(0, 0, 0);
    public Vector3 original_rot = new Vector3(0, 0, 0);
    public Vector3 current_rot = new Vector3(0, 0, 0);

    public Color color_red      = new Color(1,0,0);
    public Color color_yellow   = new Color(1,1,0);
    public Color color_orange   = new Color(128,1,0);
    public Color color_blue     = new Color(0,0,1);
    public Color color_white    = new Color(1,1,1);
    public Color color_green    = new Color(0,1,0);
    public Color color_black    = new Color(0,0,0);

    private const int side_top    = 0;
    private const int side_bottom = 1;
    private const int side_left   = 2;
    private const int side_right  = 3;
    private const int side_back   = 4;
    private const int side_front  = 5;


    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
     
    }

    // set starting location of piece
    public void setOriginalLocVal(Vector3 coord)
    {
        original_coord = coord;
        return;
    }

    public Vector3 getOriginalLocVal()
    {
        return original_coord;
    }

    public void setOriginalRotVal(Vector3 rot)
    {
        original_rot = rot;
        return;
    }

    public Vector3 getOriginalRotVal()
    {
        return original_rot;
    }

    public void setLocVal(Vector3 coord)
    {
        current_coord = coord;
        return;
    }

    public Vector3 getLocVal()
    {
        return current_coord;
    }

    public void setRotVal(Vector3 rot)
    {
        current_rot = rot;
        return;
    }

    public Vector3 getRotVal()
    {
        return current_rot;
    }

    // will also need to color faces
    public void addPiece(int size, int x_crd, int y_crd, int z_crd)
    {
        // add piece; color comes after
        MeshInstance p_box = new MeshInstance{};
        p_box.Mesh = new CubeMesh{};
        AddChild(p_box);
        var material_box = new SpatialMaterial{};
        material_box.AlbedoColor = color_black;
        p_box.SetSurfaceMaterial(0, material_box);

        // depending on coordinate, paint side specific color
        for (var f = 0; f < 6; f++)
        {
            MeshInstance p = addPlane(f);
            
            var material = new SpatialMaterial{};
            // default color is black for plane
            material.AlbedoColor = color_black;

            switch (f)
            {
                case side_top:
                    if (y_crd == size)
                    {
                        material.AlbedoColor = color_white; 
                    }
                    break;

                case side_bottom:

                    if (y_crd == 1)
                    {
                        material.AlbedoColor = color_yellow; 
                    }
                    break;
                case side_left:

                    if (x_crd == size)
                    {
                        material.AlbedoColor = color_green; 
                    }
                    break;
                case side_right:

                    if (x_crd == 1)
                    {
                        material.AlbedoColor = color_blue; 
                    }
                    break;
                case side_back:

                    if (z_crd == size)
                    {
                        material.AlbedoColor = color_orange; 
                    }
                    break;

                case side_front:
                    if (z_crd == 1)
                    {
                        material.AlbedoColor = color_red; 
                    }
                    break;
            }


            p.SetSurfaceMaterial(0, material);

            p_box.AddChild(p);
        }
    }

    // create faces for each piece, so each can be colored 
    // individually
    Vector3 new_scale = new Vector3(0.9f, 0.9f, 0.9f);

    public MeshInstance addPlane(int side)
    {
        MeshInstance p = new MeshInstance{};
        p.Mesh = new PlaneMesh{};
        
        Vector3 new_loc = new Vector3(0, 0, 0);
        Vector3 new_rot = new Vector3(0, 0, 0);

        var spread = 1.15f;

        switch (side)
        {
            case side_top:
                new_loc.y = spread;
                break;

            case side_bottom:
                new_rot.x = 180f;
                new_loc.y = -spread;
                break;

            case side_left:
                new_rot.z = -90f;
                new_loc.x = spread;
                break;

            case side_right:
                new_rot.z = 90f;
                new_loc.x = -spread;
                break;

            case side_back:
                new_rot.x = 90f;
                new_loc.z = spread;
                break;

            case side_front:
                new_rot.x = -90f;
                new_loc.z = -spread;
                break;
        }

        p.Scale = new_scale;
        p.Translate(new_loc);
        p.RotationDegrees = new_rot;

        return p;        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}


