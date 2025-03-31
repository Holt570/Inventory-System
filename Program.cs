using System.Xml.Linq;

int current_id = 0;
string inventory_path = "<xml filepath>";

static void Main_Menu(string xml_path, int current_id)
{
    string menu_input;

    Console.WriteLine();
    Console.WriteLine("Please enter a number to select one of the following options:");
    Console.WriteLine("1. View current inventory");
    Console.WriteLine("2. Add new inventory item");
    Console.WriteLine("3. Edit inventory item");
    Console.WriteLine("4. Delete inventory item");
    Console.WriteLine("5. Exit");

    menu_input = Console.ReadLine(); //gets user input for menu selection

    switch (menu_input) //checks user input and calls corresponding function
    {
        case "1":
            View_Inventory(xml_path, current_id);
            break;
        case "2":
            Add_Item(xml_path, current_id);
            break;
        case "3":
            Edit_Item(xml_path, current_id);
            break;
        case "4":
            Delete_Item(xml_path, current_id);
            break;
        case "5":
            Console.WriteLine("Exiting program...");
            break; //ends program as no further function is called
        default:
            Console.WriteLine();
            Console.WriteLine("Input not recognised");
            Main_Menu(xml_path, current_id); //recurrs main menu if invalid input is made
            break;
    }

}

static void View_Inventory(string xml_path, int current_id) //displays current contents of inventory xml file
{
    Console.WriteLine();
    Main_Menu(xml_path, current_id); //returns to main menu
}

static void Add_Item(string xml_path, int current_id) //adds new item to inventory xml file based on user inputted data
{
    current_id++; //increments current_id by 1 to set id for new item to next available number

    Console.WriteLine();
    Console.WriteLine("Please enter the name of the new item:");
    string item_name = Console.ReadLine(); //get user input for item name
    Console.WriteLine();

    Console.WriteLine("Please enter the type of the new item:");
    string item_type = Console.ReadLine(); //get user input for item type
    Console.WriteLine();

    Console.WriteLine("Please enter the qauntity of the new item:");
    string item_quantity = Console.ReadLine(); //get user input for item quantity
    Console.WriteLine();

    try //checks if quantity input is a valid integer
    {
        int int_quantity = Convert.ToInt16(item_quantity); 
    }
    catch //sets quantity to 1 if input is not an integer
    {
        Console.WriteLine("Invalid quantity entered. Setting quantity to 1");
        Console.WriteLine();
        item_quantity = "1";
    }

    XElement inventory_tree = XElement.Load(xml_path); //loads current contents of xml file into a new xml tree
    XElement new_item = new XElement("Item"); //adds new "Item" element into xml tree

    new_item.SetAttributeValue("id", current_id.ToString()); //sets id for item to next available value
    new_item.SetElementValue("Name", item_name); //adds child elements to new item element based on user inputs
    new_item.SetElementValue("Type", item_type);
    new_item.SetElementValue("Quantity", item_quantity);

    inventory_tree.Add(new_item); //adds newly created item element to existing xml tree
    inventory_tree.Save(xml_path); //updates xml file to match new xml tree with new item

    Console.WriteLine("New item added sucessfully");

    Main_Menu(xml_path, current_id); //returns to main menu
}

static void Edit_Item(string xml_path, int current_id) //allows user to edit values of an existing item
{
    Console.WriteLine();
    Main_Menu(xml_path, current_id); //returns to main menu
}

static void Delete_Item(string xml_path, int current_id) //allows user to delete an existing item
{
    Console.WriteLine();
    Main_Menu(xml_path, current_id); //returns to main menu
}

XElement id_check_tree = XElement.Load(inventory_path);

foreach (XElement e in id_check_tree.Elements()) //updates current_id to match highest id value in existing inventory
{
    if (Convert.ToInt16(e.Attribute("id").Value) > current_id)
    {
        current_id = Convert.ToInt16(e.Attribute("id").Value);
    }
} 

Main_Menu(inventory_path, current_id);
