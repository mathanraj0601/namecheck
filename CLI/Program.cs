//// See https://aka.ms/new-console-template for more information




using CLI.FileReader;
using CLI.Model.TemplateRules;
using CLI.Seperator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.CommandLine;
using System.Text.Json;

TemplateRule templateRule = new TemplateRule("Default");
FileReader fileReader = new FileReader();
int count = 0;
var rootCommand = new RootCommand("Sample app for System.CommandLine");

var templateOption = new Option<string>(
    aliases: new[] { "--template", "-t" },
     description: "Template file path and name"
   );

rootCommand.AddOption(templateOption);
rootCommand.SetHandler(handler =>
{

});

var fileOption = new Option<string>(
           aliases: new[] { "--file", "-f" },
           description: "First file path"
       );


var AllFilesOption = new Option<string>(
    aliases: new[] { "--all", "-a" },
    description: "Second file path"
);

var RecursiveOption = new Option<string>(
    aliases: new[] { "--recursive", "-r" },
    description: "Second file path"
);

rootCommand.AddOption(fileOption);
rootCommand.AddOption(RecursiveOption);
rootCommand.AddOption(AllFilesOption);

rootCommand.SetHandler((template, file, recursive, all) =>
{
    if (file != null && recursive == null && all == null)
    {
        fileReader.ReadFileByFullPath(file);
        if(fileReader.files.Count == 0)
        {
            Console.WriteLine("File does not exist");
            return;
        }
    }
    else if (file == null && recursive != null && all == null)
    {
        if (!Directory.Exists(recursive))
        {
            Console.WriteLine("Directory does not exist");
            return;
        }
        fileReader.ReadFilesByDirectoryRecursively(recursive);
        if (fileReader.files.Count == 0)
        {
            Console.WriteLine("File does not exist");
            return;
        }
    }
    else if(file == null && recursive == null && all != null)
    {
        if (!Directory.Exists(all))
        {
            Console.WriteLine("Directory does not exist");
            return;
        }
        Console.WriteLine(Directory.GetCurrentDirectory()+"cd");
        fileReader.ReadFilesByDirectory(all);
        if (fileReader.files.Count == 0)
        {
            Console.WriteLine("File does not exist");
            return;
        }
    }
    else
    {
        Console.WriteLine("Invalid option please use anyone of ( -r, -a,-f)");
        return;
    }

    if(template != null && File.Exists(template))
    {
        templateRule = JsonSerializer.Deserialize<TemplateRule>(File.ReadAllText(template)) ?? new TemplateRule("default");

    }


    CheckNamingConvention();

},templateOption, fileOption,RecursiveOption,AllFilesOption);


void CheckNamingConvention()
{
    foreach(var file in fileReader.files)
    {
        string sourceCode = File.ReadAllText(file);
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
        var root = syntaxTree.GetRoot();
        TempleteSeperator templeteSeperator = new TempleteSeperator(templateRule);
        templeteSeperator.Visit(root);
        var filename  = file.Split("\\");
        Console.WriteLine($"Filename : \x1b[1m{filename[filename.Length - 1]}\x1b[0m"); // Bold text
        Console.WriteLine("");
        // Displaying the class level naming conventions
        DisplayResult(templeteSeperator.FollowingList.ClassLister.PublicNames,
            templeteSeperator.ViolatingList.ClassLister.PublicNames, "Class", "Public",templateRule.ClassRule.PublicConvention);
        DisplayResult(templeteSeperator.FollowingList.ClassLister.PrivateNames,
            templeteSeperator.ViolatingList.ClassLister.PrivateNames, "Class", "Private",templateRule.ClassRule.PrivateConvention);
        DisplayResult(templeteSeperator.FollowingList.ClassLister.ProtectedNames,
            templeteSeperator.ViolatingList.ClassLister.ProtectedNames, "Class", "Protected", templateRule.ClassRule.ProtectedConvention);
        DisplayResult(templeteSeperator.FollowingList.ClassLister.InternalNames,
            templeteSeperator.ViolatingList.ClassLister.InternalNames, "Class", "Internal",templateRule.ClassRule.InternalConvention);

        // Displaying the constant level naming conventions
        DisplayResult(templeteSeperator.FollowingList.ConstantLister.Names,
                       templeteSeperator.ViolatingList.ConstantLister.Names, "Constant","Any", templateRule.ConstantRule.Convention);

        // Displaying the delegate level naming conventions
        DisplayResult(templeteSeperator.FollowingList.DelegateLister.PublicNames,
                                  templeteSeperator.ViolatingList.DelegateLister.PublicNames, "Delegate","Public", templateRule.DelegateRule.PublicConvention);
        DisplayResult(templeteSeperator.FollowingList.DelegateLister.InternalNames,
            templeteSeperator.ViolatingList.DelegateLister.InternalNames, "Delegate", "Internal", templateRule.DelegateRule.InternalConvention);

        // Displaying the enum level naming conventions
        DisplayResult(templeteSeperator.FollowingList.EnumLister.Names,
                       templeteSeperator.ViolatingList.EnumLister.Names, "Enum", "Public", templateRule.EnumRule.Convention);

        // Displaying the Field level naming conventions
        DisplayResult(templeteSeperator.FollowingList.FieldLister.PublicNames,
    templeteSeperator.ViolatingList.FieldLister.PublicNames, "Field", "Public", templateRule.FieldRule.PublicConvention);
        DisplayResult(templeteSeperator.FollowingList.FieldLister.PrivateNames,
            templeteSeperator.ViolatingList.FieldLister.PrivateNames, "Field", "Private", templateRule.FieldRule.PrivateConvention);
        DisplayResult(templeteSeperator.FollowingList.FieldLister.ProtectedNames,
            templeteSeperator.ViolatingList.FieldLister.ProtectedNames, "Field", "Protected", templateRule.FieldRule.ProtectedConvention);
        DisplayResult(templeteSeperator.FollowingList.FieldLister.InternalNames,
            templeteSeperator.ViolatingList.FieldLister.InternalNames, "Field", "Internal", templateRule.FieldRule.InternalConvention);

        // Displaying the Interface level naming conventions
        DisplayResult(templeteSeperator.FollowingList.InterfaceLister.PublicNames,
                       templeteSeperator.ViolatingList.InterfaceLister.PublicNames, "Interface", "Public", templateRule.InterfaceRule.PublicConvention);
        DisplayResult(templeteSeperator.FollowingList.InterfaceLister.InternalNames,
            templeteSeperator.ViolatingList.InterfaceLister.InternalNames, "Interface", "Internal", templateRule.InterfaceRule.InternalConvention);

        // Displaying the Method level naming conventions
        DisplayResult(templeteSeperator.FollowingList.MethodLister.PublicNames,
                                  templeteSeperator.ViolatingList.MethodLister.PublicNames, "Method", "Public", templateRule.MethodRule.PublicConvention);
        DisplayResult(templeteSeperator.FollowingList.MethodLister.PrivateNames,
            templeteSeperator.ViolatingList.MethodLister.PrivateNames, "Method", "Private", templateRule.MethodRule.PrivateConvention);
        DisplayResult(templeteSeperator.FollowingList.MethodLister.ProtectedNames,
            templeteSeperator.ViolatingList.MethodLister.ProtectedNames, "Method", "Protected", templateRule.MethodRule.ProtectedConvention);
        DisplayResult(templeteSeperator.FollowingList.MethodLister.InternalNames,
            templeteSeperator.ViolatingList.MethodLister.InternalNames, "Method", "Internal", templateRule.MethodRule.InternalConvention);

        //Displaying the Namespace level naming conventions
        DisplayResult(templeteSeperator.FollowingList.NameSpaceLister.Names,
                                  templeteSeperator.ViolatingList.NameSpaceLister.Names, "Namespace", "Any", templateRule.NameSpaceRule.Convention);

        // Displaying the Property level naming conventions
        DisplayResult(templeteSeperator.FollowingList.PropertyLister.PublicNames,
                                  templeteSeperator.ViolatingList.PropertyLister.PublicNames, "Property", "Public", templateRule.PropertyRule.PublicConvention);
        DisplayResult(templeteSeperator.FollowingList.PropertyLister.PrivateNames,
            templeteSeperator.ViolatingList.PropertyLister.PrivateNames, "Property", "Private", templateRule.PropertyRule.PrivateConvention);
        DisplayResult(templeteSeperator.FollowingList.PropertyLister.ProtectedNames,
            templeteSeperator.ViolatingList.PropertyLister.ProtectedNames, "Property", "Protected", templateRule.PropertyRule.ProtectedConvention);
        DisplayResult(templeteSeperator.FollowingList.PropertyLister.InternalNames,
            templeteSeperator.ViolatingList.PropertyLister.InternalNames, "Property", "Internal", templateRule.PropertyRule.InternalConvention);

        // Displaying the record level naming conventions
        DisplayResult(templeteSeperator.FollowingList.RecordLister.PublicNames,
            templeteSeperator.ViolatingList.RecordLister.PublicNames, "Record", "Public", templateRule.RecordRule.PublicConvention);
        DisplayResult(templeteSeperator.FollowingList.RecordLister.InternalNames,
            templeteSeperator.ViolatingList.RecordLister.InternalNames, "Record", "Internal", templateRule.RecordRule.InternalConvention);

        // Displaying the Struct level naming conventions
        DisplayResult(templeteSeperator.FollowingList.StructLister.PublicNames,
                                             templeteSeperator.ViolatingList.StructLister.PublicNames, "Struct", "Public", templateRule.StructRule.PublicConvention);
        DisplayResult(templeteSeperator.FollowingList.StructLister.InternalNames,
            templeteSeperator.ViolatingList.StructLister.InternalNames, "Struct", "Internal", templateRule.StructRule.InternalConvention);


        // Displaying the Variable level naming conventions
        DisplayResult(templeteSeperator.FollowingList.VariableLister.Names,
                                             templeteSeperator.ViolatingList.VariableLister.Names, "Variable", "Public", templateRule.VariableRule.Convention);


        Console.WriteLine("");
        Console.WriteLine("");

    }

    if (count > 0)
    {
        Console.WriteLine("\x1b[31mXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
        Console.WriteLine($"\x1b[31mValidation failed. {count} {(count == 1 ? "file is" : "files are")} violating the template rule");
        Console.WriteLine("\x1b[31mXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\x1b[0m");
    }
    else
    {
        Console.WriteLine("\x1b[32m-----------------------------------------------------");
        Console.WriteLine("\x1b[32mValidation passed. All files are following the template rule");
        Console.WriteLine("\x1b[32m-----------------------------------------------------\x1b[0m");
    }

}

void DisplayResult(List<string> following, List<string> violating, string dataStructure,string level, string convention)
{

    var followingCnt = following.Count;
    var violatingCnt = violating.Count;
    if (followingCnt == 0 && violatingCnt == 0)
    {
        return;
    }
    else
    {
        Console.WriteLine($"\t{dataStructure} : {level} level - {convention} conventions");
        Console.WriteLine();
        if (following.Count > 0)
        {
            Console.WriteLine("\t\tFollowing the naming convention");
            foreach (var name in following)
            {
                Console.WriteLine($"\t\t\t\x1b[32m{name}\x1b[0m"); // Green text
            }
        }
        if (violating.Count > 0)
        {
            Console.WriteLine("\t\tViolating the naming convention");
            foreach (var name in violating)
            {
                Console.WriteLine($"\t\t\t\x1b[31m{name}\x1b[0m"); // Red text
            }
        }

        count += violatingCnt;
        Console.WriteLine($"Total Count = {followingCnt + violatingCnt} (\x1b[32m\x1b[2m{followingCnt}\x1b[0m + \x1b[31m\x1b[2m{violatingCnt}\x1b[0m )");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("");
    }

}


return await rootCommand.InvokeAsync(args);
