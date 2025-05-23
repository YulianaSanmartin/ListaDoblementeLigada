using DoubleList;

var list = new DoublyLinkedList<string>();
var opc = "0";

    do
    {
        opc = ShowMenu();
        Console.WriteLine();
        switch (opc)
        {
            case "1":
                Console.Write("Enter value to add: ");
                var value = Console.ReadLine();
                if (value != null) list.Add(value);
                break;

            case "2":
                Console.WriteLine("List (forward):");
                Console.WriteLine(list.GetForward());
                break;

            case "3":
                Console.WriteLine("List (backward):");
                Console.WriteLine(list.GetBackward());
                break;

            case "4":
                list.SortDescending();
                Console.WriteLine("List sorted in descending order.");
                break;

            case "5":
                var modes = list.GetModes();
                Console.WriteLine("Mode(s): " + string.Join(", ", modes));
                break;

            case "6":
                Console.WriteLine("Graph of occurrences:");
                Console.WriteLine(list.GetGraph());
                break;

            case "7":
                Console.Write("Enter value to check: ");
                var existsValue = Console.ReadLine();
                if (existsValue != null)
                    Console.WriteLine(list.Exists(existsValue) ? "Exists" : "Does not exist");
                break;

            case "8":
                Console.Write("Enter value to remove one occurrence: ");
                var removeOne = Console.ReadLine();
                if (removeOne != null) list.RemoveOne(removeOne);
                break;

            case "9":
                Console.Write("Enter value to remove all occurrences: ");
                var removeAll = Console.ReadLine();
                if (removeAll != null) list.RemoveAll(removeAll);
                break;

            case "0":
                Console.WriteLine("Exiting...");
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;
        }
        Console.WriteLine();
    } while (opc != "0");

    static string ShowMenu()
{
    Console.WriteLine("MENU");
    Console.WriteLine("1. Add (ascending order)");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show backward");
    Console.WriteLine("4. Sort descending");
    Console.WriteLine("5. Show mode(s)");
    Console.WriteLine("6. Show graph");
    Console.WriteLine("7. Check if value exists");
    Console.WriteLine("8. Remove one occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine() ?? "0";
}