using System;
using System.Threading;

public delegate void ThresholdHandler(); // Custom delegate defined
class Counter{
    public event ThresholdHandler Threshold;  // Event defined
    int threshold_value,end;

    // Constructor
    public Counter(int th,int e){
        threshold_value = th;
        end = e;
    }
    public void Increment(int curr){
        Console.WriteLine(curr);
        if(curr==threshold_value || curr==end){
            Onthreshold(); // Call for the raiser function which Invoke the event
        }
    }

    protected virtual void Onthreshold (){
        // Raise the event
        // Can be defined in the Increment method itself but Want to encapsulate things
        Threshold?.Invoke();
    }
    
}

class Program{
    public static void ThresholdReachedHandler1(){
        Console.WriteLine("Handler1 : Threshold Reached...");
        Console.WriteLine();
    }
    public static void  ThresholdReachedHandler2(){
        Console.WriteLine("Handler2 : Count Finished...");
    }
    static void Main(){
        int threshold = 5,end = 10;
        Counter c = new Counter(threshold,end);
        c.Threshold += new ThresholdHandler(ThresholdReachedHandler1); // Subscribed Handler1

        for(int i=0;i<end;i++){
            c.Increment(i);
            Thread.Sleep(3000); // Stops the iteration by 1 sec 
        }

        c.Threshold -= new ThresholdHandler(ThresholdReachedHandler1);  // Unsubscribed Handler1
        c.Threshold += new ThresholdHandler(ThresholdReachedHandler2);  // Subscribed Handler2
        c.Increment(end);
    }
}