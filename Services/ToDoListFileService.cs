using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

public static class ToDoListFileService
{
    // Hardcoded file path
    private static string _jsonFileName = 
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
        "Avalonia.ToDoList", "MyToDoList.json");

    // Stores the information to a hardcoded file on the disk
    public static async Task SaveToFileAsync(IEnumerable<ToDoItem> itemsToSave)
    {
        // Create the directory if it doesn't exist
        Directory.CreateDirectory(Path.GetDirectoryName(_jsonFileName)!);

        using (var fs = File.Create(_jsonFileName))
        {
            await JsonSerializer.SerializeAsync(fs, itemsToSave);
        }
    }

    // Loads the file from disk and returns the items stored inside
    public static async Task<IEnumerable<ToDoItem>?> LoadFromFileAsync()
    {
        try
        {
            using (var fs = File.OpenRead(_jsonFileName))
            {
                return await JsonSerializer.DeserializeAsync<IEnumerable<ToDoItem>>(fs);
            }
        }
        catch (Exception e) when (e is FileNotFoundException || e is DirectoryNotFoundException)
        {
            // Return null if the file isn't found
            return null;
        }
    }
}