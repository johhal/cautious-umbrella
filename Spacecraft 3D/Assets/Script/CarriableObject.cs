
public abstract class CarriableObject : ActivableObject {

    //The player manager currently holding the object. Only one playermanager can hold an object.
    public PlayerManager playerManager;
    //Called when this object is picked up. Should set the playermanager to playermanager. Returns true if the object was successfully picked up.
    public abstract bool pickUp(PlayerManager playerManager);
    //Called when this object is dropped. Should set the playermanager to null. Returns true if the object was successfully dropped.
    public abstract bool drop();
}
