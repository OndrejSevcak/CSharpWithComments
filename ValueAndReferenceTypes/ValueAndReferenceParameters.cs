using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ValueAndReferenceTypes
{
    public class DemoReferenceType { }

    public static class ValueAndReferenceParameters
    {
        public static void PassingReferenceParameterByValueVsByReference()
        {
                        
            var demo = new DemoReferenceType();
            //demo is a class => which is reference type and will be used as a parameter
            //the value of demo is a reference number like (0x2AB54BC) to the actual object created on the HEAP memory

            //A parameter declared without a ref or out modifier is a VALUE PARAMETER (can be used with reference types).
            // - The "value" of a REFERENCE type is the reference itself. When passed BY VALUE, a COPY of the REFERENCE "number" is made and used by the invoked method
            void TestMethodPassingReferenceByValue(DemoReferenceType g) { g = null; }   //g is a parameter passed by value

            TestMethodPassingReferenceByValue(demo);
            //when we call the function, the reference address(0x2AB54BC) is COPIED to a new storage location(new place on STACK)
            //now g and demo have same reference adressed(0x2AB54BC was copied) so they point to the same location
            //if we use g to mutate the existing intance, also the instance pointed by demo would be also mutated
            //when we assiign g to null, g is now pointing to null but demo is still pointing to the original object 

            //A parameter declared with a "ref" modifier is a REFERENCE PARAMATER.
            // - a reference parameter does not create a new storage location.
            // - instead, a reference parameter represents the same storage location as the variable given as the argument in the function member or anonymous function invocation
            void TestMethodPassingReferenceByReference(ref DemoReferenceType g) { g = null; }  //here g is a parameter passed by reference

            TestMethodPassingReferenceByReference(ref demo);
            //here the SAME storage location is used for g as we already have for demo
            //the reference value(0x2AB54BC) is NOT copied
            //when you assign g = null, the original 0x2AB54BC is overwritten by 0x000000
            //so inside the method we change demo to point to new place (0x000000)
        }

        public static void PassingValueParametersByValueVsByReference()
        {
            // - The value of a VALUE type is the actual VALUE(data), When passed BY VALUE, a COPY of the VALUE is created on the stack
            // - Value types in C# include simple types like int, float, bool, structs, and enums.
            // - By default, when you pass a value type to a method, it is passed by value, meaning a copy of the value is passed to the method. Any changes made to the parameter inside the method do not affect the original value outside the method.
            int a = 5;
            void TestMethodPassingValueTypebyValue(int a)
            {
                a += 1;
            }

            TestMethodPassingValueTypebyValue(a);
            Console.WriteLine(a);   //5

            // - To pass a VALUE TYPE by REFERENCE, you use the ref, out, or in modifiers.
            // - This allows the method to operate directly on the original variable rather than a copy.

            //ref modifier is used when the parameter needs to be both read and modified inside the method.
            void TestMethodPassingValueTypeByReference(ref int a)
            {
                a += 1;
            }

            TestMethodPassingValueTypeByReference(ref a);
            Console.WriteLine(a);   //6

            //out Modifier: Used when the parameter is only intended to output data from the method.
            void TestMethodPassingValueTypeByReference2(out int outputNumber)
            {
                //the method now must assign the value of outputNumber parameter before it exists
                //This assigned value will be available to the caller after the method returns
                outputNumber = 15;
            }

            TestMethodPassingValueTypeByReference2(out int testNumber);
            Console.WriteLine(testNumber);  //15


            //in Modifier: Used when the parameter is passed by reference, but only to be read(not modified).
            void TestMethodPassingValueTypeByReference3(in int insideNumber)
            {
                //we can only read the parameter but can not modify
                Console.WriteLine(insideNumber);    
            }

            int constantValue = 20;
            TestMethodPassingValueTypeByReference3(constantValue); //20
        }
    }
}
