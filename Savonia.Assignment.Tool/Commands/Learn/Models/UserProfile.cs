using System.CommandLine;
using System.IO.Compression;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Savonia.Assignment.Tool.Commands.Learn.Models;

public class UserProfile
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string DisplayName { get; set; }
    // public string avatarUrl { get; set; }
    // public string avatarThumbnailUrl { get; set; }
    // public bool isPrivate { get; set; }
    // public bool isMicrosoftUser { get; set; }
    // public bool isMvp { get; set; }
    // public string qnaUserId { get; set; }
    // public int followerCount { get; set; }
    // public int followingCount { get; set; }
    // public int answersAccepted { get; set; }
    // public int reputationPoints { get; set; }
    public string CreatedOn { get; set; }
}

