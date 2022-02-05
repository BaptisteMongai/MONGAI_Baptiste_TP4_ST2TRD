# MONGAI_Baptiste_TP5_ST2TRD

## Part 1

Answers in "Part1.txt"

## Part 2

####  Question : What is the benefit of adding tests here ?

The advantage of doing tests is to be able to change the code while being sure to respect basics instructions.

## Part 3

To improve the code, I choose to create a Factory Pattern.
I first created an "IUpdate" interface which contains the "Update" method. All items (Aged Bries, Sulfuras,...) all have different ways of updating and to represent them I created classes (SulfurasUpdate, BackstagePassesUpdate, ...) which inherit from the "IUpadte" interface and which must therefore implement the "Update" method.
The factory (UpdateFactory) allows, depending on the name of the 'item', to instantiate the appropriate "...Update" class.

I modified a test because I realized that it was too permissive.

## Part 4

I think my code has good scalability because if you want to add new special items, it's very simple,
just create a new class that inherits the interface with the appropriate 'Update' method, then add the following code portion in the UpdateFactory :

else if (item.Name.Contains("NewItem"))
{
    return new NewItemUpdate();
}
