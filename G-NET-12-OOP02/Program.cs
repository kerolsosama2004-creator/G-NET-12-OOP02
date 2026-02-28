using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G_NET_12_OOP02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 : Theoretical Questions

            #region Q1 : Consider the following class:
            //a) Two problems with this design(Encapsulation issues)

            //1- Public fields(Owner, Balance):
            //Both fields are declared as public, which means any other class can directly modify them:

            //account.Balance = -1000000;
            //account.Owner = "";

            //This breaks encapsulation because there is no control or validation over how the data is changed.

            //2-No validation in Withdraw method:

            //The Withdraw method subtracts the amount without checking:

            //If amount is negative

            //If there are sufficient funds

            //If amount is zero

            //This can result in invalid states(like negative balances).
            //=====================================================================================================================================
            //  b) How to fix the class (Following proper encapsulation)

            // To follow encapsulation principles:
            //1-Make fields private:

            //Change (Owner) and (Balance) to (private).

            //2-Expose properties instead of fields:

            //Use public properties with controlled access.
            //For example:

            //(Owner) could have (get) and possibly (set) with validation.

            //(Balance) should probably have a public (get) but a private (set).

            //3-Add validation inside methods

            //In (Withdraw), check:
            //amount > 0
            //amount <= Balance

            //Possibly throw an exception if the operation is invalid.

            //4-Optional improvement

            //Add a Deposit method with proper validation.
            //======================================================================================================================================
            //c) Why exposing public fields is bad practice in OOP

            //1-Breaks data protection
            //Encapsulation means bundling data with the methods that control it.Public fields allow uncontrolled access, violating this principle.

            //2-No validation control
            //You cannot enforce business rules if external code can freely modify the data.

            //3-Harder to maintain and change later
            //If you later need to:

            //Add validation
            //Add logging
            //Change internal representation
            //You cannot do it safely without breaking existing code.

            //4-Violates the principle of information hiding
            //Good OOP design hides internal implementation details and exposes only what is necessary.
            #endregion

            #region Q02

            //1) What is the difference between a field and a property in C#?

            //From the Field vs Property slide:

            //-Field:

            //Direct data storage

            //No validation

            //Breaks encapsulation

            //-Property:

            //Controlled access

            //Can validate

            //Enforces encapsulation

            // Rule: Always use Properties, never expose public fields.

            //So:

            //A field is just a variable inside a class.

            //A property provides controlled access to that field using get and set.

            //2) Can a property contain logic ?

            //Yes.

            //The slides show a Full Property that includes validation logic inside set:

            //    public int Age
            //{
            //    get { return age; }
            //    set
            //    {
            //        if (value >= 18)   // validation rule
            //            age = value;
            //    }
            //}

            //    3) Example of a read-only property that returns a calculated value

            // private int quantity;
            // private decimal unitPrice;

            //public decimal TotalPrice
            //{
            //    get { return quantity * unitPrice; }  // calculated on the fly
            //}

            //This property:

            // Has no backing field

            // Calculates the value every time it is read

            // Is read - only(no set)

            #endregion

            #region Q3 : Look at the following code and answer the questions below:

            //a) What is this[int index] called? Explain its purpose.

            //this[int index] is called an Indexer.

            //From the presentation:

            //An Indexer allows objects to be accessed like arrays.

            //Purpose:

            //It allows the object(StudentRegister) to behave like an array.

            //It provides controlled access to internal data(names array).

            //It improves readability and makes the class easier to use.

            //b) What happens if someone writes register[10] = "Ali"; ?

            //If someone writes:
            //register[10] = "Ali";

            //It will cause a runtime error:

            //IndexOutOfRangeException

            //Because index 10 does not exist in the array.

            //    How to make the indexer safer?

            //    Add validation inside the indexer:

            //    public string this[int index]
            //{
            //    get
            //    {
            //        if (index < 0 || index >= names.Length)
            //          throw new IndexOutOfRangeException();
            //        return names[index];
            //    }
            //    set
            //    {
            //        if (index < 0 || index >= names.Length)
            //            throw new IndexOutOfRangeException();
            //        names[index] = value;
            //    }
            //}


            //c) Can a class have more than one indexer?
            // Yes.

            //A class can have multiple indexers as long as they have different parameter types(overloading).
            //example:

            //   public string this[int index]   // access by number
            // {
            //   get { return names[index]; }
            //   set { names[index] = value; }
            // }

            //     public string this[string name]   // access by name
            // {
            //     get
            //     {
            //       foreach (var n in names)
            //       if (n == name)
            //         return n;
            //         return null;
            //      }
            // }   

            //When would this be useful?

            //Accessing students by ID(int)

            //Accessing students by Name(string)

            #endregion

            #region Q4 : Consider the following code and answer the questions below:

            //a) What does the static keyword mean on TotalOrders?

            //How is it different from the Item field ?

            //static means the member belongs to the class itself, not to individual objects.

            //There is only one shared copy of TotalOrders for all Order objects.

            //So:

            //TotalOrders → shared between all instances.

            //Item → belongs to each individual object (each order has its own item).

            //| Static Field(`TotalOrders`)        | Instance Field(`Item`)          |
            //| ---------------------------------- | ------------------------------- |
            //| Belongs to class                   | Belongs to object               |
            //| One copy only                      | Separate copy per object        |
            //| Accessed using `Order.TotalOrders` | Accessed using object reference |

            //b) Can a static method inside Order access the Item field directly? Why or why not?

            //No, it cannot access Item directly.

            //Reason:

            //-Item is an instance field.

            //-A static method belongs to the class, not to a specific object.

            //-Static methods do not have access to instance data because they do not operate on a specific object.

            #endregion

            #endregion
        }
    }
}
