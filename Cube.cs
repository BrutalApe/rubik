using Godot;
using System;

public class Cube : Spatial
{
    //[Export]
    PackedScene new_piece;
    PackedScene new_side_select;

    Godot.Collections.Array piece_list = new Godot.Collections.Array();
    
    public float spacing_constant = 2.3f;

    Vector3 x_axis = new Vector3(1, 0, 0);
    Vector3 y_axis = new Vector3(0, 1, 0);
    Vector3 z_axis = new Vector3(0, 0, 1);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    public void makeCube(int size)
    {
        for (var i = 1; i<=size; i++)
        {
            for (var j = 1; j<=size; j++)
            {
                for (var k = 1; k<=size; k++)
                {
                    new_piece = (PackedScene)ResourceLoader.Load("res://Piece.tscn");
                    Area piece = (Area)new_piece.Instance();
                    piece.Call("addPiece", size, i, j, k);

                    Vector3 new_loc = new Vector3(i, j, k);
                    Vector3 new_rot = new Vector3(0, 0, 0);
                    
                    piece.Call("setOriginalLocVal", new_loc);
                    piece.Call("setLocVal", new_loc);
                    piece.Call("setOriginalRotVal", new_rot);
                    piece.Call("setRotVal", new_rot);
                    
                    AddChild(piece);
                    //test_loc = (Godot.Vector3)piece.Call("GetLocVal");

                    //GD.Print(test_loc);

                    new_loc.x = spacing_constant*i;
                    new_loc.y = spacing_constant*j;
                    new_loc.z = spacing_constant*k;
                    piece.Translate(new_loc);


                    // Vector3 box_vec = new Vector3(1, 1, 1);
                    // BoxShape box_shape = new BoxShape();
                    // box_shape.Extents = box_vec;

                    // var collision = new CollisionShape();
                    // collision.Shape = box_shape;
                    
                    // // give piece the collision shape
                    // piece.AddChild(collision);

                }
            }
        }

        // add all children to piece_list
        piece_list = GetChildren();
        // GD.Print("Children List (makeCube):");
        // GD.Print(piece_list);
    }

    // These three functions would be used for direct manipulation
    // of the pieces; hopefully, can use another method.
    // public void translatePiece(Area piece, Vector3 new_loc)
    // {
    //     piece.Translate(new_loc);
    //     piece.Call("setLocVal", new_loc);
    //     return;
    // }

    // public void rotatePiece(Area piece, Vector3 new_rot)
    // {
    //     piece.RotationDegrees = new_rot;
    //     piece.Call("setRotVal", new_rot);
    //     return;
    // }

    // public void movePiece(Area piece, Vector3 new_loc, Vector3 new_rot)
    // {
    //     translatePiece(piece, new_loc);
    //     rotatePiece(piece, new_rot);
    //     return;
    // }

    // https://godotengine.org/qa/45609/how-do-you-rotate-spatial-node-around-axis-given-point-space
    // func rotateAround(obj, point, axis, angle):
    //     var rot = angle + obj.rotation.y 
    //     var tStart = point
    //     obj.global_translate (-tStart)
    //     obj.transform = obj.transform.rotated(axis, -rot)
    //     obj.global_translate (tStart)

    public void rotateAround(Area obj, Vector3 point, Vector3 axis, float angle)
    {
        float rot = 0;

        if      (axis == x_axis){rot = angle + obj.Rotation.x;}
        else if (axis == y_axis){rot = angle + obj.Rotation.y;}
        else if (axis == z_axis){rot = angle + obj.Rotation.z;}
        else    {return;}

        var tStart = point;
        obj.GlobalTranslate (-tStart);
        obj.Transform = obj.Transform.Rotated(axis, -rot);
        obj.GlobalTranslate (tStart);

        return;
    }

    public void spinSide(int size, Vector3 side_select, int direction, int times)
    {
        var side = 0;
        float side_num = 0;
        Godot.Collections.Array spin_piece_list = new Godot.Collections.Array();
        Vector3 temp_piece_coord = new Vector3(0, 0, 0);

        // axis of rotation for side
        Vector3 axis = new Vector3(0, 0, 0);

        const int x_side = 1;
        const int y_side = 2;
        const int z_side = 3;

        // need more comprehensive error checking
        if      (side_select.x != 0){side = x_side; side_num = side_select.x; axis = x_axis;}
        else if (side_select.y != 0){side = y_side; side_num = side_select.y; axis = y_axis;}
        else if (side_select.z != 0){side = z_side; side_num = side_select.z; axis = z_axis;}
        else {return;}

        // GD.Print("Children List (spinSide)");
        // GD.Print(piece_list);
        
        // first, get list of pieces to be moved
        foreach (Area piece in piece_list)
        {
            // get coordinates of current piece
            temp_piece_coord = (Vector3)piece.Call("getLocVal");
            
            switch (side)
            {
                case x_side:
                    if (temp_piece_coord.x == side_num)
                    {
                        spin_piece_list.Add(piece);
                    }
                    break;

                case y_side:
                    if (temp_piece_coord.y == side_num)
                    {
                        spin_piece_list.Add(piece);
                    }
                    break;

                case z_side:
                    if (temp_piece_coord.z == side_num)
                    {
                        spin_piece_list.Add(piece);
                    }
                    break;

                default:
                    break;

            }
        }

        GD.Print(spin_piece_list);
        
        // rotation point always center of cube
        float cent_pnt = spacing_constant*(size-1);
        Vector3 point = new Vector3(cent_pnt, cent_pnt+1, cent_pnt);
        
        float angle = (float)Math.PI;

        foreach (Area piece in spin_piece_list)
        {
            rotateAround(piece, point, axis, angle);
        }

        // move each piece to location indicated by dir/side


        return;
    }

    // public override void _Process(float delta)
    // {
    // }
}

// These vectors will be decided by 'side' value

// new_side_select = (PackedScene)ResourceLoader.Load("res://SideSelect.tscn");
// Area side_select = (Area)new_side_select.Instance();
// side_select.Call("createBoundingBox", start_coord, end_coord);
// AddChild(side_select);

// Godot.Collections.Array pieces = side_select.GetOverlappingAreas();

// GD.Print(pieces);

// at end, remove side selector
//RemoveChild(side_select);   
