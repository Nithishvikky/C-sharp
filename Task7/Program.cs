using System;
using System.Threading.Tasks;
using System.Collections.Generic;
class Program{
    static async Task Main(){
        List<Person> ListOfPerson = new List<Person>(){
            new Person(){Name="Nithish",Age=20},
            new Person(){Name="Ajay",Age=20},
            new Person(){Name="Abrar",Age=20}
        };
        
        List<Task<string>> res = new List<Task<string>>();

        foreach (Person p in ListOfPerson)
        {
            res.Add(PersonDetails(p)); // Adding to List of Task<string> to get the result in one attempt
        }

        try{

            string[] result = await Task.WhenAll(res); // This aggregates the rasult and wait for it to complete
            foreach (string i in result)
            {
                Console.WriteLine(i);   
            }
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }
    public static async Task<String> PersonDetails(Person p){
        await Task.Delay(3000); // 3 second custom delay to mimic API processing
        string message = $"Name : {p.Name} Age : {p.Age}";
        return message;
    }
}

class Person{
    public string Name{ get; set; }
    public int Age{ get; set;}
}