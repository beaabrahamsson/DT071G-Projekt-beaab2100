
namespace MindfulNote.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class EntryPage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "entries.txt");
    public EntryPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.entries.txt";

        LoadEntry(Path.Combine(appDataPath, randomFileName));
    }

    //Save function
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Entry entry)
            File.WriteAllText(entry.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    //Delete function
    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Entry entry)
        {
            // Delete the file.
            if (File.Exists(entry.Filename))
                File.Delete(entry.Filename);
        }

        //Naigate to Guestbook Page
        await Shell.Current.GoToAsync("..");
    }

    //Load Entry function
    private void LoadEntry(string fileName)
    {
        //Declaring an object of type Entry
        Models.Entry entryModel = new Models.Entry();
        //Object Filename is fileName
        entryModel.Filename = fileName;

        //Check if fileName exists
        if (File.Exists(fileName))
        {
            //Get date of creation
            entryModel.Date = File.GetCreationTime(fileName);
            //Read all fext in file
            entryModel.Text = File.ReadAllText(fileName);
        }

        //Binding context
        BindingContext = entryModel;
    }

    public string ItemId
    {
        set { LoadEntry(value); }
    }
}