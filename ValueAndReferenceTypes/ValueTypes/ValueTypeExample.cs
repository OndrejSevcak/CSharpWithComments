//C# TYPE SYSTEM - VALUE TYPES

// => are stored on the STACK MEMORY => have predictable lifetime
// => directly contain theit data
// => each variable has its own copy of the data

namespace ValueAndReferenceTypes.ValueTypes;

//STRUCT is a VALUE TYPE
public struct ValueTypeExample
{
    public int X { get; init; }
    public int Y { get; init; }

    public ValueTypeExample(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static void ValueTypes()
    {
        int valueTypeInt = 10;                  //-2,147,483,648 to 2,147,483,647   -   32bit
        byte valueTypeByte = 1;                 //0-255                             -   8 bit
        char valueTypeChar = (char)106;         //U+0000 to U+FFFF                  -   16bit
        float valueTypeFloat = 5.4f;            //6-9 digits precision
        double valueTypeDouble = 0.0010;        //15-17 digits precision
        decimal valueTypeDecimal = 2.1m;        //28-29 digits
        bool valueTypeBoolean = false;          //true / false

        Console.WriteLine($"{valueTypeInt},{valueTypeByte},{valueTypeChar},{valueTypeFloat},{valueTypeDouble},{valueTypeDecimal},{valueTypeBoolean}");
    }

    enum ValueTypesEnum
    {
        integralNumeric,        //sbyte, byte, short, int, uint, long, ulong, 
        floatingPointNumeric,   //float, double, deciaml
        boolType,               //bool
        charType,               //char
        enums,                  //user defined set of named constants
        structTypes,            //user deined strucure type that encapsulated functionality
        tupleTypes              //lightweight data structure
    }
}


