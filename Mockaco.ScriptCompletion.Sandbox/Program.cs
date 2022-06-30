// See https://aka.ms/new-console-template for more information

using Bogus;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Text;
using Mockaco;

var host = MefHostServices.Create(MefHostServices.DefaultAssemblies);
var workspace = new AdhocWorkspace(host);

var scriptCode = "Faker.Random.WordsArray(";

var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
    usings: new[]
    {
        "System",
        "System.Linq",
        "System.Collections.Generic",
        "System.Text.RegularExpressions",
        typeof(Faker).Namespace!,
        "Mockaco",
        "Newtonsoft.Json",
        "Newtonsoft.Json.Linq"
    });

var scriptProjectInfo = ProjectInfo.Create(ProjectId.CreateNewId(), VersionStamp.Create(), "Script", "Script",
        LanguageNames.CSharp,
        isSubmission: true,
        hostObjectType: typeof(IScriptContext))
    .WithMetadataReferences(new[]
    {
        MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
        MetadataReference.CreateFromFile(typeof(Faker).Assembly.Location),
        MetadataReference.CreateFromFile(typeof(ScriptContext).Assembly.Location),

    })
    .WithCompilationOptions(compilationOptions);

var scriptProject = workspace.AddProject(scriptProjectInfo);
var scriptDocumentInfo = DocumentInfo.Create(
    DocumentId.CreateNewId(scriptProject.Id), "Script",
    sourceCodeKind: SourceCodeKind.Script,
    loader: TextLoader.From(TextAndVersion.Create(SourceText.From(scriptCode), VersionStamp.Create())));
var scriptDocument = workspace.AddDocument(scriptDocumentInfo);

var tree = await scriptDocument.GetSemanticModelAsync();
await PrintCompletionResults(scriptDocument, scriptCode.Length - 1, scriptProject);

Console.ReadLine();

static async Task PrintCompletionResults(Document document, int position, Project project)
{
    //https://stackoverflow.com/questions/65499548/c-sharp-roslyn-completionservice-where-to-get-method-overload-information
    var completionService = CompletionService.GetService(document);
    var results = await completionService.GetCompletionsAsync(document, position);
    var syntaxRoot = await document.GetSyntaxRootAsync();
    var semanticModel = await document.GetSemanticModelAsync();
    var methods = syntaxRoot.DescendantNodes().OfType<InvocationExpressionSyntax>();
    
    var allMethodRefs = new List<IEnumerable<ReferencedSymbol>>();

    foreach (var i in results.Items)
    {
        Console.WriteLine(i.DisplayText);

        foreach (var prop in i.Properties)
        {
            Console.Write($"{prop.Key}:{prop.Value}  ");
        }

        Console.WriteLine();
        foreach (var tag in i.Tags)
        {
            Console.Write($"{tag}  ");
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}