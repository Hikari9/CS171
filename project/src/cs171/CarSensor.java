package cs171;

import cs171.ai.Sensor;

public interface CarSensor extends Sensor {
    double getDistance();
    double getSpeed();
    double getAcceleration();
    double getWidth();
    double getLength();
}
