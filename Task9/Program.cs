using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute:Attribute{}

public class A{
    public A(){
        Console.WriteLine("A class Constructor");
    }

    [Runnable]
    public void Method1(){
        Console.WriteLine("Custom attribute method of Class A");
    }
    public void Method2(){
        Console.WriteLine("Without attribute Method of Class A");
    }
}
public class B{
    public B(){
        Console.WriteLine("B class Constructor");
    }

    [Runnable]
    public void Method1(){
        Console.WriteLine("Custom attribute method of Class B");
    }

    public void Method2(){
        Console.WriteLine("Without attribute Method of Class B");
    }
}

public class Program{
    public static void Main(){
        Assembly assembly = Assembly.GetExecutingAssembly(); // Whole assembly which includes classes,metadata and everything
        
        // Type -  each classes in assembly
        foreach(Type type in assembly.GetTypes()){

            // checking of classes
            if (!type.IsClass || type.IsAbstract){ 
                continue;
            }

            // creating a instance for non static classes
            object? obj = Activator.CreateInstance(type);

            // Getting each methods of each class which is public or non-static
            foreach(MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance)){
                // listing methods which has custom runnableattribute
                var attr = method.GetCustomAttribute<RunnableAttribute>();
                if(attr != null){
                    Console.WriteLine($"Class Name : {type.Name} and Method Name : {method.Name}");
                    // invoking the method of object which is runnableattribute
                    method.Invoke(obj,null);
                }
            }
        }
    }
}