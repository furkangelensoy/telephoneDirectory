using System.Collections;
using System.Linq.Expressions;

public class TelephoneDirectory{

    List<string> directory =new List<string>();

    public TelephoneDirectory(){
        directory.Add("John Smith 5568465235");
        directory.Add("Noah Wilson 5948236488");
        directory.Add("Julia Royal 5764469213");
        directory.Add("Charlotte Anderson 5642248547");
        directory.Add("Cameron Green 5946632913");
    }



    public void Menu(){
        Console.WriteLine("     *****   MENU    *****      ");
        Console.WriteLine("1- Add person to directory \n" + 
                    "2- Delete the person from directory \n" + 
                    "3- Update the person from directory \n" +
                    "4- Search the person in directory \n" + 
                    "5- List directory A-Z \n" + 
                    "6- List directory Z-A \n" + 
                    "7- Exit");
        Console.WriteLine("     *****           *****      ");
        Console.Write("Your choice: ");
        int x = int.Parse(Console.ReadLine());
        switch (x)
        {

            case 1:
            
                bool save = false;
                while(save==false){
                    int count = directory.Count;
                    Console.WriteLine("Please enter the information about person!");
                    Console.Write("First Name: ");
                    string firstname = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Telephone: ");
                    string number = Console.ReadLine();
                    SaveNumber(firstname,lastName,number);
                    if(count == directory.Count){
                        Console.WriteLine("1- Try again \n" + "2- Back to main menu");
                        Console.Write("Your choice: ");
                        int selection = int.Parse(Console.ReadLine());
                        if (selection == 1){
                            save = false;
                        }else if(selection == 2){
                            save = true;
                            Menu();
                        }else{
                            Console.WriteLine("You entered invalid value so you have been directed to the main menu! ");
                            save = true;
                            Menu();
                        }


                    }else{

                        Console.WriteLine("You have successfully added new person!");
                        save = true;
                        Menu();
                    }
                    
                }
               
                break;


            case 2:

                bool success = false;

                while(success == false){
                    int count = directory.Count();
                    Console.WriteLine("Please enter the name or last name of the person you want to delete!");
                    Console.Write("Name or lastname: ");
                    string selected = Console.ReadLine();
                    DeleteNumber(selected);
                    if(count == directory.Count()){
                        Console.WriteLine("You entered wrong value so the person cannot be found or you cancelled the process!");
                        Console.WriteLine("1- Try again \n" + "2- Back to main menu");
                        Console.Write("Your choice: ");
                        int  selection = int.Parse(Console.ReadLine());
                        switch (selection)
                        {
                            case 1:
                                success = false;
                                break;


                            case 2:
                                success = true;
                                Menu();
                                break;

                            default:

                                Console.WriteLine("You entered invalid value so you have been directed to the main menu!");
                                success = true; 
                                Menu();
                                break;
                        }

                    }else{

                        Menu();
                        
                    }
                    
                    

                }

                break;


            case 3:
                Console.WriteLine("Please enter the name or last name of the person you want to update!");
                Console.Write("Name or lastname: ");
                string update = Console.ReadLine();
                UpdateNumber(update);
                break;


            case 4:

                SearchPerson();
                Menu();
                break;


            case 5:

                ListDirectory();
                Menu();
                break;

            case 6:

                ListDirectoryReverse();
                Menu();
                break;

            case 7:


                break;

            
            default:
                Console.WriteLine("You entered invalid value so you have been directed to the main menu!");
                Menu();
                break;
        }
    }




    public void SearchPerson(){
        int i = 0;
        Console.WriteLine("Please enter the name or last name of the person you want to search!");
        Console.Write("Name or lastname: ");
        string search = Console.ReadLine();

        foreach (var item in directory){
            string[] items = item.Split(' ');
            if(items[0].Equals(search) || items[1].Equals(search)){
                i++;
                Console.WriteLine("The person found: " + item);
                break;
            }
        }
        if(i == 0){

            Console.WriteLine("The person can not be found!" +"\n1-Try again" + "\n2-Back to main menu");
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());
            if(choice == 1){
                SearchPerson();
            }else{
                Menu();
            }

        }
        
    }


    public void SaveNumber(string firstName, string lastName, string number){

            string person = firstName + " " + lastName + " " + number;
        
            directory.Add(person);


    }

    public void DeleteNumber(string selected){

        foreach (var item in directory)
        {
            string[] items = item.Split(' ');
            if(items[0].Equals(selected) || items[1].Equals(selected)){
                Console.Write("The person found: " + item + "\nAre you sure want to delete (y/n): ");
                string question = Console.ReadLine();
                if(question == "y"){

                    directory.Remove(item);
                    Console.WriteLine("You have successfully deleted the person: " + item);
                    break;

                }else{
                    break;
                }
                
                
            }
        }

    }

    public void UpdateNumber(string selected){
        int i = 0;
        foreach(var item in directory){
            string[] items = item.Split(' ');
            if(items[0].Equals(selected) || items[1].Equals(selected) ){

                Console.WriteLine("The person found: " + item);

                Console.WriteLine("Please select which do you want to update! \n" +
                "1- Name \n" +
                "2- Last name \n" +
                "3- Telephone");
                Console.Write("Your choice: ");
                int choice = int.Parse(Console.ReadLine()); 
                switch(choice){
                    case 1:
                        Console.Write("New Name: ");
                        items[0] = Console.ReadLine();
                        directory[i] = items[0] + " " + items[1] + " " + items[2];
                        Console.WriteLine("The person has been updated succesfully: " + directory[i]);
                        Menu();
                        break;

                    case 2:
                        Console.Write("New Last Name: ");
                        items[1] = Console.ReadLine();
                        directory[i] = items[0] + " " + items[1] + " " + items[2];
                        Console.WriteLine("The person has been updated succesfully: " + directory[i]);
                        Menu();
                        break;

                    case 3:
                        Console.Write("New Telephone: ");
                        items[2] = Console.ReadLine();
                        directory[i] = items[0] + " " + items[1] + " " + items[2];
                        Console.WriteLine("The person has been updated succesfully: " + directory[i]);
                        Menu();
                        break;

                    default:
                        break;
                }

            }else{
                i++;
                continue;
            }

            break;


        }


        
    }


    public void ListDirectory(){
        directory.Sort();
        Console.WriteLine("         -----Directory-----       ");
        foreach (var item in directory)
        {
            string[] items = item.Split(' ');
            Console.WriteLine("Name: " + items[0] + "\t\t Lastname: " + items[1] + "\t Telephone: " + items[2]);
        }
        Console.WriteLine("         -----Directory-----       ");
    }

    public void ListDirectoryReverse(){
        directory.Sort();
        directory.Reverse();
        Console.WriteLine("         -----Directory-----       ");
        foreach (var item in directory)
        {
            string[] items = item.Split(' ');
            Console.WriteLine("Name: " + items[0] + "\t\t Lastname: " + items[1] + "\t Telephone: " + items[2]);
        }
        Console.WriteLine("         -----Directory-----       ");
    }


}