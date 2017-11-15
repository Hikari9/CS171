package cs171.ai;

public interface Actuator<ReturnType> {
    ReturnType act(Agent agents[], Sensor sensors[]);
}
