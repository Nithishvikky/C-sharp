using System;
class Person{
    private string name;
    private int age;
    public Person(){}
    public Person(string userName,int userAge){
        name = userName;
        age = userAge;
    }
    // Propeties, It's like getter setter but it's built-in keywords
    public string Name{
        get{return name;}
        set{name = value;}
    }
    public int Age{
        get{return age;}
        set{age = value;}
    }
    
    //Public method we can use it in all classes
    public void Introduce(){
        Console.WriteLine($"Welcome to the C# Class {age} year old {Name}");
    }
}
class Program{
    static void Main(){
        Person p1 = new Person("Nithish",20);
        Person p2 = new Person();
        Console.Write("Enter a person name : ");
        p2.Name = Console.ReadLine();
        Console.Write("Enter a person age : ");
        p2.Age = Convert.ToInt32(Console.ReadLine());
        p1.Introduce();
        p2.Introduce();
    }
}