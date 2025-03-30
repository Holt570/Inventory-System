// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;

static void Main_Menu(){
    string menu_input = "";

    Console.WriteLine("Please enter a number to select one of the following options:");
    Console.WriteLine("1. View current inventory");
    Console.WriteLine("2. Add new inventory item");
    Console.WriteLine("3. Edit inventory item");
    Console.WriteLine("4. Delete inventory item");
    Console.WriteLine("5. Exit");

    menu_input = Console.ReadLine();

    switch (menu_input){
        case "1":
            View_Inventory();
            break;
        case "2":
            Add_Item();
            break;
        case "3":
            Edit_Item();
            break;
        case "4":
            Delete_Item();
            break;
        case "5":
            Console.WriteLine("Exiting program...");
            break;
        default:
            Console.WriteLine("Input not recognised");
            Console.WriteLine();
            Main_Menu();
            break;
    }

}

static void View_Inventory(){
    Main_Menu();
}

static void Add_Item(){
    Main_Menu();
}

static void Edit_Item(){
    Main_Menu();
}

static void Delete_Item(){
    Main_Menu();
}

Main_Menu();