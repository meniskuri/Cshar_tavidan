// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

StateConsumer bechdva = new();
bechdva.PrintState();


// shevqmnat klasebi modifikatorebit

class State
{
    // все равно, что private string defaultVar;
    string defaultVar = "default";
    // поле доступно только из текущего класса
    private string privateVar = "private";
    // доступно из текущего класса и производных классов, которые определены в этом же проекте
    protected private string protectedPrivateVar = "protected private";
    // доступно из текущего класса и производных классов
    protected string protectedVar = "protected";
    // доступно в любом месте текущего проекта
    internal string internalVar = "internal";
    // доступно в любом месте текущего проекта и из классов-наследников в других проектах
    protected internal string protectedInternalVar = "protected internal";
    // доступно в любом месте программы, а также для других программ и сборок
    public string publicVar = "public";

    // по умолчанию имеет модификатор private
    void Print() => Console.WriteLine(defaultVar);

    // метод доступен только из текущего класса
    private void PrintPrivate() => Console.WriteLine(privateVar);

    // доступен из текущего класса и производных классов, которые определены в этом же проекте
    protected private void PrintProtectedPrivate() => Console.WriteLine(protectedPrivateVar);

    // доступен из текущего класса и производных классов
    protected void PrintProtected() => Console.WriteLine(protectedVar);

    // доступен в любом месте текущего проекта
    internal void PrintInternal() => Console.WriteLine(internalVar);

    // доступен в любом месте текущего проекта и из классов-наследников в других проектах
    protected internal void PrintProtectedInternal() => Console.WriteLine(protectedInternalVar);

    // доступен в любом месте программы, а также для других программ и сборок
    public void PrintPublic() => Console.WriteLine(publicVar);
}


class StateConsumer
{
    public void PrintState()
    {
        State state = new State();

        // обратиться к переменной defaultVar у нас не получится,
        // так как она имеет модификатор private и класс StateConsumer ее не видит
        // Console.WriteLine(state.defaultVar); //Ошибка, получить доступ нельзя

        // то же самое относится и к переменной privateVar
        // Console.WriteLine(state.privateVar); // Ошибка, получить доступ нельзя

        // обратиться к переменной protectedPrivateVar не получится,
        // так как класс StateConsumer не является классом-наследником класса State
        // Console.WriteLine(state.protectedPrivateVar); // Ошибка, получить доступ нельзя

        // обратиться к переменной protectedVar тоже не получится,
        // так как класс StateConsumer не является классом-наследником класса State
        // Console.WriteLine(state.protectedVar); // Ошибка, получить доступ нельзя

        // переменная internalVar с модификатором internal доступна из любого места текущего проекта
        // поэтому можно получить или изменить ее значение
        Console.WriteLine(state.internalVar);

        // переменная protectedInternalVar так же доступна из любого места текущего проекта
        Console.WriteLine(state.protectedInternalVar);

        // переменная publicVar общедоступна
        Console.WriteLine(state.publicVar);
    }
}
