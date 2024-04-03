using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Learn.Models;

public class UserAchievements
{
    public Achievement[] Achievements { get; set; }
    public int TotalCount { get; set; }
}

public class Achievement
{
    public string Category { get; set; }
    public string TypeId { get; set; }
    public string UserId { get; set; }
    public string Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Locale { get; set; }
    public bool Verified { get; set; }
    public string Source { get; set; }
    public DateTime GrantedOn { get; set; }
    public string Url { get; set; }
    public bool MilestoneEligible { get; set; }
    public int Version { get; set; }

    override public string ToString()
    {
        return $"{Title} ({Category}), {TypeId}, {GrantedOn}";
    }
}

