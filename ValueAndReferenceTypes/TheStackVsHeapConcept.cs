//HEAP  - reference types are allocated on the HEAP memory
//STACK - value types are allocaed on the STACK memory

//System.ValueType - ensures that derived type is allocated on the STACK memory
//                 - data allocated on STACK can be created and destoryed very fast
//                 - STACK allocated data have defined lifetime by their defining scope
//                 - overrides virual method of System.Object
//                 - data directy contain their values

using System.Drawing;
using ValueAndReferenceTypes.ReferenceTypes;

namespace ValueAndReferenceTypes;

public static class TheStackVsHeapConcept
{   
    //STACK object lifetime
    public static void StackLifeTime()
    {
        Point myPointStruct = new Point(5, 2);  //Point struct value type is created on the stack in the scope of this method

    }//here myPointStruct is deleted from Stack


    //Assigning one value type to another => copy of the data is created
    public static void ValueTypeAssignmenttDemo()
    {
        int a = 20;
        int b = a;  //value of 20 if copied into variable b, two separate values exists in each variable

        Console.WriteLine(a);   //20
        Console.WriteLine(b);   //20

        a = 35;

        Console.WriteLine(a);   //35
        Console.WriteLine(b);   //20 -> b has not changed because it contains its own copy of the data
    }

    //Assigning one reference type to another = copy of the reference address pointing to the same object is created
    public static void ReferenceTypeAssignmentDemo()
    {
        Car bmw1 = new Car("BMW", 2020);
        Car bmw2 = bmw1;                 //only the HEAP object reference(address) is copied to the new variable, but it is still pointing to the same object

        Console.WriteLine(bmw1.ToString());      //BMW model year 2020
        Console.WriteLine(bmw2.ToString());     //BMW model year 2020

        bmw1.ModelYear = 1998;

        Console.WriteLine(bmw1.ToString());      //BMW model year 1998
        Console.WriteLine(bmw2.ToString());     //BMW model year 1998   -> bmw2 has changed too, becase it points to the same object as bmw1
    }
}
