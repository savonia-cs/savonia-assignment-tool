using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands;

public class AnswersCommand : Command
{
    public AnswersCommand() : base("answers", "Work with multiple solutions sent as answers")
    {
        AddCommand(new AnswersUnpackCommand());
    }
}

