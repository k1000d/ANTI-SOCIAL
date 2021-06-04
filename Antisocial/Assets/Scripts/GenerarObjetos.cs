using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarObjetos : MonoBehaviour
{
    [SerializeField]
    Object persona;
    [SerializeField]
    Vector3 posInicPersona;

    [SerializeField]
    float periodo;

    Timer alarma = new Timer();
    [SerializeField]
    int maxPersonas;

    int totalPersonas = 0;

    // Start is called before the first frame update
    void Start()
    {
        alarma.setAlarm(periodo);
    }

    // Update is called once per frame
    void Update()
    {
        if (alarma.isSounding())
        {
            //Calcular el siguiente periodo de tiempo a esperar para generar la siguiente persona
            alarma.resetAlarm();

        posInicPersona.x = Random.Range(-10, 10);
        posInicPersona.y = Random.Range(-10, 10);
        posInicPersona.z = Random.Range(-10, 10);

        Instantiate(persona, posInicPersona, Quaternion.identity);
            totalPersonas++;
            if (maxPersonas < totalPersonas) alarma.stopAlarm();
        }
    }
}

class Timer
{
    private static int NO_ALARM = -1;

    //Los tiempos se definen en segundos
    float alarm,       //Tiempo de espera hasta que se activa la alarma
          alarmSetAt;  //Tiempo en el que se fija la alarma. Si (TiempoActual-alarmSetAt) > alarm, la alarma suena

    // Crea una alarma
    public void setAlarm(float timeAmount)
    {
        alarm = timeAmount;
        alarmSetAt = Time.time;
    }
    // Nos dice si la alamrma está activa
    public bool isSounding()
    {
        return ((Time.time - alarmSetAt) > alarm) && (alarm != NO_ALARM);
    }

    // Inicializa la alarma
    public void resetAlarm()
    {
        alarmSetAt = Time.time;
    }

    //Para la alarma
    public void stopAlarm() { setAlarm(NO_ALARM); }

    public float getDelta() { return Time.time - alarmSetAt; }
}
