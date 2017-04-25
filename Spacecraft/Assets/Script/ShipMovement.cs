
public class ShipMovement {

    //keep track of ships speed and movement
    public double x_position;
    public double y_position;
    public double current_speed;
    public double direction;

    public ShipMovement(double x_position, double y_position)
    {
        this.x_position = x_position;
        this.y_position = y_position;
        current_speed = 1;
        direction = System.Math.PI / 4;
     }

    public void move()
    {
        //x-axel arccos
        x_position = x_position + System.Math.Cos(direction) * current_speed;

        //y-axel arcsin
        y_position = y_position + System.Math.Sin(direction) * current_speed;
    }
}
