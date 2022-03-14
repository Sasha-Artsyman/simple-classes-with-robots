using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("*********************************");
        // Создать объект Robot
        Robot r0 = new Robot("SlugBug", 100, 10);

        // Зарегистрировать несколько обработчиков событий
        r0.RegisterWithRobotEngine(new Robot.RobotEngineHandler(OnRobotEngineEvent));
        r0.RegisterWithRobotEngine(new Robot.RobotEngineHandler(OnRobotEngineEvent0));

        Robot.RobotEngineHandler handler2 = new Robot.RobotEngineHandler(OnRobotEngineEvent0);
        r0.RegisterWithRobotEngine(handler2);
        // Отменить регистрацию второго обработчика
        r0.UnRegisterWithRobotEngine(handler2);

        // Увеличить мощности / инициация событий
        Console.WriteLine("***** Power up *****");
        for (int i = 0; i < 6; i++)
            r0.Accelerate(20);
        Console.ReadLine();
    }
    public static void OnRobotEngineEvent(string msg)
    {
        Console.WriteLine("=> {0}", msg);
    }
    public static void OnRobotEngineEvent0(string msg)
    {
        Console.WriteLine("=> {0}", msg.ToUpper());
    }
}
