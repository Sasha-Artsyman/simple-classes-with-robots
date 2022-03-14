internal class Robot
{
    // Данные состояния
    public int CurrentPower { get; set; }
    public int MaxPower { get; set; } = 100;
    public string PetName { get; set; }
    // Исправен ли робот
    private bool RobotlsDead;
    // Конструкторы класса
    public Robot() { }
    public Robot(string name, int maxPw, int currPw)
    {
        CurrentPower = currPw;
        MaxPower = maxPw;
        PetName = name;
    }
    // Определить тип делегата
    public delegate void RobotEngineHandler(string msgForCaller);
    // Определить переменную-член этого типа делегата
    private RobotEngineHandler listOfHandlers;
    // Добавить регистрационную функцию для вызывающего кода
    public void RegisterWithRobotEngine(RobotEngineHandler methodToCall)
    {
        listOfHandlers += methodToCall;
    }
    // Реализовать метод Accelerate () 
    public void Accelerate(int delta)
    {
        // Если этот робот сломан, то отправить сообщение об этом
        if (RobotlsDead)
        {
            if (listOfHandlers != null)
                listOfHandlers("Ouch, this Robot is dead...");
        }
        else
        {
            CurrentPower += delta;
            // Робот на грани поломки
            if (10 == (MaxPower - CurrentPower) && listOfHandlers != null)
            {
                listOfHandlers("Roboteful buddy! Dangerously!");
            }
            if (CurrentPower >= MaxPower)
                RobotlsDead = true;
            else
                Console.WriteLine("CurrentSpeed = {0}", CurrentPower);
        }
    }
    public void UnRegisterWithRobotEngine(RobotEngineHandler methodToCall)
    {
        listOfHandlers -= methodToCall;
    }
}