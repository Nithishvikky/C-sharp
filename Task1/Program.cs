using System;

class Factorial{
    static int Fact(int n){
        if(n>=1){
            return n*Fact(n-1);
        }
        else{
            return 1;
        }
    }
    static void Main(){
        Console.Write("Enter a number : ");
        int num = Convert.ToInt32(Console.ReadLine());

        if(num>=0){
            Console.WriteLine($"{num}! = {Fact(num)} by recursion");
            int res=1;
            for(int i=1;i<=num;i++){
                res*=i;
            }
            Console.WriteLine($"{num}! = {res} by loop");
        }
        else{
            Console.WriteLine("Enter valid number");
        }
    }
}