using Godot;
using System;

public class SideSelect : Area
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void createBoundingBox(Vector3 start, Vector3 end)
    {
        // this vector should change depending on pieces being rotated
        Vector3 box_vec = new Vector3(3, 1, 1);
        BoxShape box_shape = new BoxShape();
        box_shape.Extents = box_vec;

        var select_box = new CollisionShape();
        select_box.Shape = box_shape;
        // give side_select the collision child
        AddChild(select_box);

        GD.Print("Bounding Box created");
    }

    // public delegate void SideCollideDelegate()
    // public event GotSide


 // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
     
 }
}
