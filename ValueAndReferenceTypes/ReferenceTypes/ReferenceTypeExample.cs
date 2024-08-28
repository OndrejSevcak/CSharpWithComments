//C# TYPE SYSTEM - REFERENCE TYPES

// => are stored on the HEAP MEMORY => are garbage collected
// => contain only the references(address) to their data(object)
// => two variables can reference the same object, operation on one variable can affect another variable

namespace ValueAndReferenceTypes.ReferenceTypes;

//CLASS is a REFERENCE type
public class ReferenceTypeExample
{
    public int X { get; init; }
    public int Y { get; init; }

    public ReferenceTypeExample(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static void BuildInReferenceTypes()
    {
        object objectReference = "all types in C# unified type system inherits from System.Object";

        dynamic dynamicReference = "this can be of any type, behaves like object in most cases";

        string stringReference = "string is also a reference type, but has overloaded the == operator";
    }

    //User-defined reference types
    public class MyCustomObjectClass { }                        //class type
    public interface IMyCustomObjecInterface { }                //interface type

    public delegate int DelegateReferenceType(int x, int y);    //delegate type
    public record MyRecord { }                                  //record types (immutable by default, behave like value type when comparing equality)
}


