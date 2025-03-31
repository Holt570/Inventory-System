using System.Xml.Linq;

int current_id = 1;
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

    menu_input = Console.ReadLine();

    switch (menu_input)
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
            break;
        default:
            Console.WriteLine();
            Console.WriteLine("Input not recognised");
            Main_Menu(xml_path, current_id);
            break;
    }

}

static void View_Inventory(string xml_path, int current_id)
{
    Console.WriteLine();
    Main_Menu(xml_path, current_id);
}

static void Add_Item(string xml_path, int current_id)
{
    Console.WriteLine();
    Console.WriteLine("Please enter the name of the new item:");
    string item_name = Console.ReadLine();
    Console.WriteLine();

    Console.WriteLine("Please enter the type of the new item:");
    string item_type = Console.ReadLine();
    Console.WriteLine();

    Console.WriteLine("Please enter the qauntity of the new item:");
    string item_quantity = Console.ReadLine();
    Console.WriteLine();

    try
    {
        int int_quantity = Convert.ToInt16(item_quantity);
    }
    catch
    {
        Console.WriteLine("Invalid quantity entered. Setting quantity to 0");
        Console.WriteLine();
        item_quantity = "0";
    }

    XElement inventory_tree = XElement.Load(xml_path); //loads current contents of xml file into a new xml tree
    XElement new_item = new XElement("Item"); //adds new "Item" element into xml tree

    new_item.SetAttributeValue("id", current_id.ToString());
    new_item.SetElementValue("Name", item_name);
    new_item.SetElementValue("Type", item_type);
    new_item.SetElementValue("Name", item_quantity);

    Console.WriteLine("New item added sucessfully");

    inventory_tree.Add(new_item);
    inventory_tree.Save(xml_path);

    current_id++;
    Main_Menu(xml_path, current_id);
}

static void Edit_Item(string xml_path, int current_id)
{
    Console.WriteLine();
    Main_Menu(xml_path, current_id);
}

static void Delete_Item(string xml_path, int current_id)
{
    Console.WriteLine();
    Main_Menu(xml_path, current_id);
}

Main_Menu(inventory_path, current_id);
